// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using TerraFX.Interop.DirectX;
using TerraFX.Interop.Windows;
using static TerraFX.Interop.Windows.Windows;
using static TerraFX.Interop.DirectX.DirectX;
using static TerraFX.Interop.DirectX.DXGI;
using static TerraFX.Interop.DirectX.DXGI_ADAPTER_FLAG;
using static TerraFX.Interop.DirectX.D3D_FEATURE_LEVEL;
using static TerraFX.Interop.DirectX.DXGI_FEATURE;
using static TerraFX.Interop.DirectX.D3D12_FEATURE;
using static TerraFX.Interop.DirectX.D3D12;
using static TerraFX.Interop.DirectX.D3D12_RENDER_PASS_TIER;
using static TerraFX.Interop.DirectX.D3D12_RAYTRACING_TIER;
using static TerraFX.Interop.DirectX.D3D12_MESSAGE_SEVERITY;
using static TerraFX.Interop.DirectX.D3D12_MESSAGE_ID;
using static TerraFX.Interop.DirectX.D3D12_RLDO_FLAGS;
using static TerraFX.Interop.DirectX.D3D12_COMMAND_LIST_TYPE;
using static TerraFX.Interop.DirectX.D3D12_FENCE_FLAGS;
using static Vortice.Graphics.D3DUtilities;
using System.Diagnostics;

namespace Vortice.Graphics;

public sealed unsafe class D3D12GraphicsDevice : GraphicsDevice
{
    private static readonly Lazy<bool> s_isSupported = new(CheckIsSupported);
    private readonly GraphicsDeviceCaps _caps;
    private readonly ComPtr<IDXGIFactory4> _factory;
    private readonly ComPtr<ID3D12Device5> _d3dDevice;
    private readonly ComPtr<ID3D12CommandQueue> _graphicsQueue;
    private readonly ComPtr<ID3D12Fence> _graphicsFence;

    public D3D12GraphicsDevice(
            ValidationMode validationMode = ValidationMode.Disabled,
            GpuPowerPreference powerPreference = GpuPowerPreference.HighPerformance)
    {
        if (!s_isSupported.Value)
        {
            throw new InvalidOperationException("Vulkan is not supported");
        }

        uint dxgiFactoryFlags = 0;

        if (validationMode != ValidationMode.Disabled)
        {
            dxgiFactoryFlags = 0x1; // DXGI_CREATE_FACTORY_DEBUG

            using ComPtr<ID3D12Debug> d3D12Debug = default;

            if (D3D12GetDebugInterface(__uuidof<ID3D12Debug>(), d3D12Debug.GetVoidAddressOf()).SUCCEEDED)
            {
                d3D12Debug.Get()->EnableDebugLayer();

                if (validationMode == ValidationMode.GPU)
                {
                    using ComPtr<ID3D12Debug1> d3D12Debug1 = default;
                    if (d3D12Debug.CopyTo(d3D12Debug1.GetAddressOf()).SUCCEEDED)
                    {
                        d3D12Debug1.Get()->SetEnableGPUBasedValidation(true);
                        d3D12Debug1.Get()->SetEnableSynchronizedCommandQueueValidation(true);
                    }

                    using ComPtr<ID3D12Debug2> d3d12Debug2 = default;

                    if (d3D12Debug.CopyTo(d3d12Debug2.GetAddressOf()).SUCCEEDED)
                    {
                        d3d12Debug2.Get()->SetGPUBasedValidationFlags(D3D12_GPU_BASED_VALIDATION_FLAGS.D3D12_GPU_BASED_VALIDATION_FLAGS_NONE);
                    }
                }
            }
            else
            {
                Debug.WriteLine("WARNING: Direct3D Debug Device is not available\n");
            }
        }

        ThrowIfFailed(CreateDXGIFactory2(dxgiFactoryFlags, __uuidof<IDXGIFactory4>(), _factory.GetVoidAddressOf()));

        // Determines whether tearing support is available for fullscreen borderless windows.
        {
            BOOL allowTearing = false;

            using ComPtr<IDXGIFactory5> dxgiFactory5 = default;

            HRESULT hr = S_FALSE;
            if (_factory.CopyTo(dxgiFactory5.GetAddressOf()).SUCCEEDED)
            {
                hr = dxgiFactory5.Get()->CheckFeatureSupport(DXGI_FEATURE_PRESENT_ALLOW_TEARING, &allowTearing, sizeof(BOOL));
            }

            if (hr.FAILED || !allowTearing)
            {
                TearingSupported = false;
                Debug.WriteLine("WARNING: Variable refresh rate displays not supported");
            }
            else
            {
                TearingSupported = true;
            }
        }

        {
            Span<D3D_FEATURE_LEVEL> s_featureLevels = new D3D_FEATURE_LEVEL[]
            {
                D3D_FEATURE_LEVEL_12_2,
                D3D_FEATURE_LEVEL_12_1,
                D3D_FEATURE_LEVEL_12_0,
                D3D_FEATURE_LEVEL_11_1,
                D3D_FEATURE_LEVEL_11_0,
            };

            bool queryByPreference = false;
            using ComPtr<IDXGIFactory6> dxgiFactory6 = default;

            if (_factory.CopyTo(dxgiFactory6.GetAddressOf()).SUCCEEDED)
            {
                queryByPreference = true;
            }

            DXGI_GPU_PREFERENCE gpuPreference = ToDXGI(powerPreference);

            HRESULT NextAdapter(uint index, IDXGIAdapter1** ppAdapter)
            {
                if (queryByPreference)
                    return dxgiFactory6.Get()->EnumAdapterByGpuPreference(index, gpuPreference, __uuidof<IDXGIAdapter1>(), (void**)ppAdapter);
                else
                    return _factory.Get()->EnumAdapters1(index, ppAdapter);
            };

            using ComPtr<IDXGIAdapter1> dxgiAdapter = default;
            DXGI_ADAPTER_DESC1 adapterDesc = default;
            for (uint adapterIndex = 0; NextAdapter(adapterIndex, dxgiAdapter.ReleaseAndGetAddressOf()) != DXGI_ERROR_NOT_FOUND; ++adapterIndex)
            {
                ThrowIfFailed(dxgiAdapter.Get()->GetDesc1(&adapterDesc));

                // Don't select the Basic Render Driver adapter.
                if ((adapterDesc.Flags & DXGI_ADAPTER_FLAG_SOFTWARE) != 0)
                {
                    continue;
                }

                for (int i = 0; i < s_featureLevels.Length; ++i)
                {
                    D3D_FEATURE_LEVEL featurelevel = s_featureLevels[i];
                    if (D3D12CreateDevice((IUnknown*)dxgiAdapter.Get(), featurelevel, __uuidof<ID3D12Device5>(), (void**)_d3dDevice.GetAddressOf()).SUCCEEDED)
                    {
                        break;
                    }
                }

                if (_d3dDevice.Get() != null)
                    break;
            }

            ThrowIfFailed(_d3dDevice.Get()->SetName("AlimerDevice"));

            if (validationMode != ValidationMode.Disabled)
            {
                // Configure debug device (if active).
                using ComPtr<ID3D12InfoQueue> infoQueue = default;
                if (_d3dDevice.CopyTo(infoQueue.GetAddressOf()).SUCCEEDED)
                {
                    infoQueue.Get()->SetBreakOnSeverity(D3D12_MESSAGE_SEVERITY_CORRUPTION, true);
                    infoQueue.Get()->SetBreakOnSeverity(D3D12_MESSAGE_SEVERITY_ERROR, true);

                    // These severities should be seen all the time
                    uint severitiesCount = 4;
                    if (validationMode == ValidationMode.Verbose)
                    {
                        // Verbose only filters
                        severitiesCount = 5;
                    }

                    D3D12_MESSAGE_SEVERITY* enabledSeverities = stackalloc D3D12_MESSAGE_SEVERITY[5]
                    {
                        D3D12_MESSAGE_SEVERITY_CORRUPTION,
                        D3D12_MESSAGE_SEVERITY_ERROR,
                        D3D12_MESSAGE_SEVERITY_WARNING,
                        D3D12_MESSAGE_SEVERITY_MESSAGE,
                        // Verbose only filters
                        D3D12_MESSAGE_SEVERITY_INFO
                    };

                    uint disabledMessagesCount = 6;
                    D3D12_MESSAGE_ID* disabledMessages = stackalloc D3D12_MESSAGE_ID[6]
                    {
                        D3D12_MESSAGE_ID_CLEARRENDERTARGETVIEW_MISMATCHINGCLEARVALUE,
                        D3D12_MESSAGE_ID_CLEARDEPTHSTENCILVIEW_MISMATCHINGCLEARVALUE,
                        D3D12_MESSAGE_ID_MAP_INVALID_NULLRANGE,
                        D3D12_MESSAGE_ID_UNMAP_INVALID_NULLRANGE,
                        D3D12_MESSAGE_ID_EXECUTECOMMANDLISTS_WRONGSWAPCHAINBUFFERREFERENCE,
                        D3D12_MESSAGE_ID_RESOURCE_BARRIER_MISMATCHING_COMMAND_LIST_TYPE
                    };


#if VORTICE_DX12_USE_PIPELINE_LIBRARY
                    disabledMessages.Add(D3D12_MESSAGE_ID_LOADPIPELINE_NAMENOTFOUND);
                    disabledMessages.Add(D3D12_MESSAGE_ID_STOREPIPELINE_DUPLICATENAME);
#endif

                    D3D12_INFO_QUEUE_FILTER filter = new D3D12_INFO_QUEUE_FILTER();
                    filter.AllowList.NumSeverities = severitiesCount;
                    filter.AllowList.pSeverityList = enabledSeverities;
                    filter.DenyList.NumIDs = disabledMessagesCount;
                    filter.DenyList.pIDList = disabledMessages;

                    // Clear out the existing filters since we're taking full control of them
                    infoQueue.Get()->PushEmptyStorageFilter();

                    ThrowIfFailed(infoQueue.Get()->AddStorageFilterEntries(&filter));
                    //ThrowIfFailed(infoQueue.Get()->AddApplicationMessage(D3D12_MESSAGE_SEVERITY_MESSAGE, "D3D12 Debug Filters setup"));
                }
            }

            ThrowIfFailed(dxgiAdapter.Get()->GetDesc1(&adapterDesc));

            // Init capabilites.
            VendorId = (GpuVendorId)adapterDesc.VendorId;
            AdapterId = (uint)adapterDesc.DeviceId;

            if ((adapterDesc.Flags & DXGI_ADAPTER_FLAG_SOFTWARE) != 0)
            {
                AdapterType = GpuAdapterType.CPU;
            }
            else
            {
                D3D12_FEATURE_DATA_ARCHITECTURE1 architecture1 = _d3dDevice.Get()->CheckFeatureSupport<D3D12_FEATURE_DATA_ARCHITECTURE1>(D3D12_FEATURE_ARCHITECTURE1);
                AdapterType = architecture1.UMA ? GpuAdapterType.IntegratedGPU : GpuAdapterType.DiscreteGPU;
                IsCacheCoherentUMA = architecture1.CacheCoherentUMA;
            }

            //AdapterName = adapterDesc.Description;
            D3D12_FEATURE_DATA_D3D12_OPTIONS1 featureDataOptions1 = _d3dDevice.Get()->CheckFeatureSupport<D3D12_FEATURE_DATA_D3D12_OPTIONS1>(D3D12_FEATURE_D3D12_OPTIONS1);
            D3D12_FEATURE_DATA_D3D12_OPTIONS5 featureDataOptions5 = _d3dDevice.Get()->CheckFeatureSupport<D3D12_FEATURE_DATA_D3D12_OPTIONS5>(D3D12_FEATURE_D3D12_OPTIONS5);

            SupportsRenderPass = false;
            if (featureDataOptions5.RenderPassesTier > D3D12_RENDER_PASS_TIER_1
                && adapterDesc.VendorId != (uint)GpuVendorId.Intel)
            {
                SupportsRenderPass = true;
            }

            _caps = new GraphicsDeviceCaps()
            {
                Features = new GraphicsDeviceFeatures
                {
                    IndependentBlend = true,
                    ComputeShader = true,
                    TessellationShader = true,
                    MultiViewport = true,
                    IndexUInt32 = true,
                    MultiDrawIndirect = true,
                    FillModeNonSolid = true,
                    SamplerAnisotropy = true,
                    TextureCompressionETC2 = false,
                    TextureCompressionASTC_LDR = false,
                    TextureCompressionBC = true,
                    TextureCubeArray = true,
                    Raytracing = featureDataOptions5.RaytracingTier >= D3D12_RAYTRACING_TIER_1_0
                },
                Limits = new GraphicsDeviceLimits
                {
                    MaxVertexAttributes = 16,
                    MaxVertexBindings = 16,
                    MaxVertexAttributeOffset = 2047,
                    MaxVertexBindingStride = 2048,
                    MaxTextureDimension1D = D3D12_REQ_TEXTURE1D_U_DIMENSION,
                    MaxTextureDimension2D = D3D12_REQ_TEXTURE2D_U_OR_V_DIMENSION,
                    MaxTextureDimension3D = D3D12_REQ_TEXTURE3D_U_V_OR_W_DIMENSION,
                    MaxTextureDimensionCube = D3D12_REQ_TEXTURECUBE_DIMENSION,
                    MaxTextureArrayLayers = D3D12_REQ_TEXTURE2D_ARRAY_AXIS_DIMENSION,
                    MaxColorAttachments = D3D12_SIMULTANEOUS_RENDER_TARGET_COUNT,
                    MaxUniformBufferRange = D3D12_REQ_CONSTANT_BUFFER_ELEMENT_COUNT * 16,
                    MaxStorageBufferRange = uint.MaxValue,
                    MinUniformBufferOffsetAlignment = D3D12_CONSTANT_BUFFER_DATA_PLACEMENT_ALIGNMENT,
                    MinStorageBufferOffsetAlignment = 16u,
                    MaxSamplerAnisotropy = D3D12_MAX_MAXANISOTROPY,
                    MaxViewports = D3D12_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE,
                    MaxViewportWidth = D3D12_VIEWPORT_BOUNDS_MAX,
                    MaxViewportHeight = D3D12_VIEWPORT_BOUNDS_MAX,
                    MaxTessellationPatchSize = D3D12_IA_PATCH_MAX_CONTROL_POINT_COUNT,
                    MaxComputeSharedMemorySize = D3D12_CS_THREAD_LOCAL_TEMP_REGISTER_POOL,
                    MaxComputeWorkGroupCountX = D3D12_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION,
                    MaxComputeWorkGroupCountY = D3D12_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION,
                    MaxComputeWorkGroupCountZ = D3D12_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION,
                    MaxComputeWorkGroupInvocations = D3D12_CS_THREAD_GROUP_MAX_THREADS_PER_GROUP,
                    MaxComputeWorkGroupSizeX = D3D12_CS_THREAD_GROUP_MAX_X,
                    MaxComputeWorkGroupSizeY = D3D12_CS_THREAD_GROUP_MAX_Y,
                    MaxComputeWorkGroupSizeZ = D3D12_CS_THREAD_GROUP_MAX_Z,
                }
            };
        }

        // Create command queue's
        D3D12_COMMAND_QUEUE_DESC commandQueueDesc = new D3D12_COMMAND_QUEUE_DESC
        {
            Type = D3D12_COMMAND_LIST_TYPE_DIRECT,
            Priority = (int)D3D12_COMMAND_QUEUE_PRIORITY.D3D12_COMMAND_QUEUE_PRIORITY_NORMAL,
            Flags = D3D12_COMMAND_QUEUE_FLAGS.D3D12_COMMAND_QUEUE_FLAG_NONE,
            NodeMask = 0
        };

        ThrowIfFailed(_d3dDevice.Get()->CreateCommandQueue(
            &commandQueueDesc,
            __uuidof<ID3D12CommandQueue>(),
            (void**)_graphicsQueue.GetAddressOf())
            );

        _graphicsQueue.Get()->SetName($"{CommandQueueType.Graphics} Command Queue");

        ThrowIfFailed(_d3dDevice.Get()->CreateFence(0,
            D3D12_FENCE_FLAG_NONE,
            __uuidof<ID3D12Fence>(),
            (void**)_graphicsFence.GetAddressOf())
            );
    }

    /// <inheritdoc />
    public override void WaitIdle()
    {
        ThrowIfFailed(_graphicsQueue.Get()->Signal(_graphicsFence.Get(), 1));
        if (_graphicsFence.Get()->GetCompletedValue() < 1)
        {
            ThrowIfFailed(_graphicsFence.Get()->SetEventOnCompletion(1, HANDLE.NULL));
        }
        ThrowIfFailed(_graphicsFence.Get()->Signal(0));
    }

    // <inheritdoc />
    public override GpuBackend BackendType => GpuBackend.Direct3D12;

    // <inheritdoc />
    public override GpuVendorId VendorId { get; }

    /// <inheritdoc />
    public override uint AdapterId { get; }

    /// <inheritdoc />
    public override GpuAdapterType AdapterType { get; }

    /// <inheritdoc />
    public override string AdapterName { get; }

    /// <inheritdoc />
    public override GraphicsDeviceCaps Capabilities => _caps;

    internal bool TearingSupported { get; }

    internal bool SupportsRenderPass { get; }

    /// <summary>
    /// Gets whether or not the current device has a cache coherent UMA architecture.
    /// </summary>
    internal bool IsCacheCoherentUMA { get; }

    internal IDXGIFactory4* Factory => _factory.Get();

    internal ID3D12Device5* NativeDevice => _d3dDevice.Get();
    internal ID3D12CommandQueue* GraphicsQueue => _graphicsQueue.Get();

    /// <inheritdoc />
    protected override void OnDispose()
    {
        WaitIdle();

        _graphicsFence.Dispose();
        _graphicsQueue.Dispose();

#if DEBUG
        uint refCount = _d3dDevice.Get()->Release();
        if (refCount > 0)
        {
            Debug.WriteLine($"Direct3D12: There are {refCount} unreleased references left on the device");

            using ComPtr<ID3D12DebugDevice> debugDevice = default;
            if (_d3dDevice.CopyTo(debugDevice.GetAddressOf()).SUCCEEDED)
            {
                debugDevice.Get()->ReportLiveDeviceObjects(D3D12_RLDO_DETAIL | D3D12_RLDO_IGNORE_INTERNAL);
            }
        }
#else
        _d3dDevice.Dispose();
#endif
        _factory.Dispose();
    }

    private static bool CheckIsSupported()
    {
        try
        {
            using ComPtr<IDXGIFactory4> dxgiFactory4 = default;

            HRESULT hr = CreateDXGIFactory2(0, __uuidof<IDXGIFactory4>(), (void**)dxgiFactory4.GetAddressOf());

            if (hr.FAILED)
            {
                return false;
            }

            using ComPtr<IDXGIAdapter1> dxgiAdapter = default;

            bool foundCompatibleDevice = false;
            for (uint i = 0; DXGI_ERROR_NOT_FOUND != dxgiFactory4.Get()->EnumAdapters1(i, dxgiAdapter.ReleaseAndGetAddressOf()); ++i)
            {
                DXGI_ADAPTER_DESC1 adapterDesc;
                ThrowIfFailed(dxgiAdapter.Get()->GetDesc1(&adapterDesc));

                // Don't select the Basic Render Driver adapter.
                if ((adapterDesc.Flags & DXGI_ADAPTER_FLAG_SOFTWARE) != 0)
                {
                    continue;
                }

                // Check to see if the adapter supports Direct3D 12,
                // but don't create the actual device.
                Guid IID_ID3D12Device = new Guid("189819F1-1DB6-4B57-BE54-1821339B85F7");
                if (D3D12CreateDevice((IUnknown*)dxgiAdapter.Get(), D3D_FEATURE_LEVEL_12_0, &IID_ID3D12Device, null).SUCCEEDED)
                {
                    foundCompatibleDevice = true;
                    break;
                }
            }

            if (foundCompatibleDevice)
            {
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <inheritdoc />
    protected override GraphicsBuffer CreateBufferCore(in BufferDescriptor descriptor, IntPtr initialData) => throw new NotImplementedException();
    /// <inheritdoc />
    protected override Texture CreateTextureCore(in TextureDescriptor descriptor) => new D3D12.D3D12Texture(this, descriptor);
    /// <inheritdoc />
    protected override SwapChain CreateSwapChainCore(in SwapChainSource source, in SwapChainDescriptor descriptor) => new D3D12.D3D12SwapChain(this, source, descriptor);
}
