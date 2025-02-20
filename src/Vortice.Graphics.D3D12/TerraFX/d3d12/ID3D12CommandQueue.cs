// Copyright � Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/d3d12.h in the Windows SDK for Windows 10.0.22000.0
// Original source is Copyright � Microsoft. All rights reserved.

using TerraFX.Interop.Windows;

namespace TerraFX.Interop.DirectX;

/// <include file='ID3D12CommandQueue.xml' path='doc/member[@name="ID3D12CommandQueue"]/*' />
[Guid("0EC870A6-5D7E-4C22-8CFC-5BAAE07616ED")]
[NativeTypeName("struct ID3D12CommandQueue : ID3D12Pageable")]
[NativeInheritance("ID3D12Pageable")]
internal unsafe partial struct ID3D12CommandQueue
{
    public void** lpVtbl;

    /// <inheritdoc cref="IUnknown.QueryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(0)]
    public HRESULT QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, Guid*, void**, int>)(lpVtbl[0]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), riid, ppvObject);
    }

    /// <inheritdoc cref="IUnknown.AddRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(1)]
    [return: NativeTypeName("ULONG")]
    public uint AddRef()
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, uint>)(lpVtbl[1]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IUnknown.Release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(2)]
    [return: NativeTypeName("ULONG")]
    public uint Release()
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, uint>)(lpVtbl[2]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ID3D12Object.GetPrivateData" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(3)]
    public HRESULT GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, Guid*, uint*, void*, int>)(lpVtbl[3]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
    }

    /// <inheritdoc cref="ID3D12Object.SetPrivateData" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(4)]
    public HRESULT SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, Guid*, uint, void*, int>)(lpVtbl[4]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
    }

    /// <inheritdoc cref="ID3D12Object.SetPrivateDataInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(5)]
    public HRESULT SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IUnknown* pData)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, Guid*, IUnknown*, int>)(lpVtbl[5]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), guid, pData);
    }

    /// <inheritdoc cref="ID3D12Object.SetName" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(6)]
    public HRESULT SetName([NativeTypeName("LPCWSTR")] ushort* Name)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, ushort*, int>)(lpVtbl[6]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), Name);
    }

    /// <inheritdoc cref="ID3D12DeviceChild.GetDevice" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(7)]
    public HRESULT GetDevice([NativeTypeName("const IID &")] Guid* riid, void** ppvDevice)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, Guid*, void**, int>)(lpVtbl[7]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), riid, ppvDevice);
    }

#if TODO
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(8)]
    public void UpdateTileMappings(ID3D12Resource* pResource, uint NumResourceRegions, [NativeTypeName("const D3D12_TILED_RESOURCE_COORDINATE *")] D3D12_TILED_RESOURCE_COORDINATE* pResourceRegionStartCoordinates, [NativeTypeName("const D3D12_TILE_REGION_SIZE *")] D3D12_TILE_REGION_SIZE* pResourceRegionSizes, ID3D12Heap* pHeap, uint NumRanges, [NativeTypeName("const D3D12_TILE_RANGE_FLAGS *")] D3D12_TILE_RANGE_FLAGS* pRangeFlags, [NativeTypeName("const UINT *")] uint* pHeapRangeStartOffsets, [NativeTypeName("const UINT *")] uint* pRangeTileCounts, D3D12_TILE_MAPPING_FLAGS Flags)
    {
        ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, ID3D12Resource*, uint, D3D12_TILED_RESOURCE_COORDINATE*, D3D12_TILE_REGION_SIZE*, ID3D12Heap*, uint, D3D12_TILE_RANGE_FLAGS*, uint*, uint*, D3D12_TILE_MAPPING_FLAGS, void>)(lpVtbl[8]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), pResource, NumResourceRegions, pResourceRegionStartCoordinates, pResourceRegionSizes, pHeap, NumRanges, pRangeFlags, pHeapRangeStartOffsets, pRangeTileCounts, Flags);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(9)]
    public void CopyTileMappings(ID3D12Resource* pDstResource, [NativeTypeName("const D3D12_TILED_RESOURCE_COORDINATE *")] D3D12_TILED_RESOURCE_COORDINATE* pDstRegionStartCoordinate, ID3D12Resource* pSrcResource, [NativeTypeName("const D3D12_TILED_RESOURCE_COORDINATE *")] D3D12_TILED_RESOURCE_COORDINATE* pSrcRegionStartCoordinate, [NativeTypeName("const D3D12_TILE_REGION_SIZE *")] D3D12_TILE_REGION_SIZE* pRegionSize, D3D12_TILE_MAPPING_FLAGS Flags)
    {
        ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, ID3D12Resource*, D3D12_TILED_RESOURCE_COORDINATE*, ID3D12Resource*, D3D12_TILED_RESOURCE_COORDINATE*, D3D12_TILE_REGION_SIZE*, D3D12_TILE_MAPPING_FLAGS, void>)(lpVtbl[9]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), pDstResource, pDstRegionStartCoordinate, pSrcResource, pSrcRegionStartCoordinate, pRegionSize, Flags);
    }
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(10)]
    public void ExecuteCommandLists(uint NumCommandLists, [NativeTypeName("ID3D12CommandList *const *")] ID3D12CommandList** ppCommandLists)
    {
        ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, uint, ID3D12CommandList**, void>)(lpVtbl[10]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), NumCommandLists, ppCommandLists);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(11)]
    public void SetMarker(uint Metadata, [NativeTypeName("const void *")] void* pData, uint Size)
    {
        ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, uint, void*, uint, void>)(lpVtbl[11]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), Metadata, pData, Size);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(12)]
    public void BeginEvent(uint Metadata, [NativeTypeName("const void *")] void* pData, uint Size)
    {
        ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, uint, void*, uint, void>)(lpVtbl[12]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), Metadata, pData, Size);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(13)]
    public void EndEvent()
    {
        ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, void>)(lpVtbl[13]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(14)]
    public HRESULT Signal(ID3D12Fence* pFence, [NativeTypeName("UINT64")] ulong Value)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, ID3D12Fence*, ulong, int>)(lpVtbl[14]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), pFence, Value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(15)]
    public HRESULT Wait(ID3D12Fence* pFence, [NativeTypeName("UINT64")] ulong Value)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, ID3D12Fence*, ulong, int>)(lpVtbl[15]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), pFence, Value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(16)]
    public HRESULT GetTimestampFrequency([NativeTypeName("UINT64 *")] ulong* pFrequency)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, ulong*, int>)(lpVtbl[16]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), pFrequency);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(17)]
    public HRESULT GetClockCalibration([NativeTypeName("UINT64 *")] ulong* pGpuTimestamp, [NativeTypeName("UINT64 *")] ulong* pCpuTimestamp)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, ulong*, ulong*, int>)(lpVtbl[17]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), pGpuTimestamp, pCpuTimestamp);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(18)]
    public D3D12_COMMAND_QUEUE_DESC GetDesc()
    {
        D3D12_COMMAND_QUEUE_DESC result;
#if NETSTANDARD2_0
        return *((delegate* unmanaged[Stdcall]<ID3D12CommandQueue*, D3D12_COMMAND_QUEUE_DESC*, D3D12_COMMAND_QUEUE_DESC*>)(lpVtbl[18]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), &result);
#else
        return *((delegate* unmanaged[SuppressGCTransition]<ID3D12CommandQueue*, D3D12_COMMAND_QUEUE_DESC*, D3D12_COMMAND_QUEUE_DESC*>)(lpVtbl[18]))((ID3D12CommandQueue*)Unsafe.AsPointer(ref this), &result);
#endif
    }

    public HRESULT SetName(string name)
    {
        fixed (char* namePtr = name)
        {
            return SetName((ushort*)namePtr);
        }
    }
}
