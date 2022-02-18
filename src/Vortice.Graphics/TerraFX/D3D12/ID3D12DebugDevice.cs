// Copyright � Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/d3d12sdklayers.h in the Windows SDK for Windows 10.0.22000.0
// Original source is Copyright � Microsoft. All rights reserved.

using TerraFX.Interop.Windows;

namespace TerraFX.Interop.DirectX;

/// <include file='ID3D12DebugDevice.xml' path='doc/member[@name="ID3D12DebugDevice"]/*' />
[Guid("3FEBD6DD-4973-4787-8194-E45F9E28923E")]
[NativeTypeName("struct ID3D12DebugDevice : IUnknown")]
[NativeInheritance("IUnknown")]
internal unsafe partial struct ID3D12DebugDevice
{
    public void** lpVtbl;

    /// <inheritdoc cref="IUnknown.QueryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(0)]
    public HRESULT QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
    {
        return ((delegate* unmanaged<ID3D12DebugDevice*, Guid*, void**, int>)(lpVtbl[0]))((ID3D12DebugDevice*)Unsafe.AsPointer(ref this), riid, ppvObject);
    }

    /// <inheritdoc cref="IUnknown.AddRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(1)]
    [return: NativeTypeName("ULONG")]
    public uint AddRef()
    {
        return ((delegate* unmanaged<ID3D12DebugDevice*, uint>)(lpVtbl[1]))((ID3D12DebugDevice*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IUnknown.Release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(2)]
    [return: NativeTypeName("ULONG")]
    public uint Release()
    {
        return ((delegate* unmanaged<ID3D12DebugDevice*, uint>)(lpVtbl[2]))((ID3D12DebugDevice*)Unsafe.AsPointer(ref this));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(3)]
    public HRESULT SetFeatureMask(D3D12_DEBUG_FEATURE Mask)
    {
        return ((delegate* unmanaged<ID3D12DebugDevice*, D3D12_DEBUG_FEATURE, int>)(lpVtbl[3]))((ID3D12DebugDevice*)Unsafe.AsPointer(ref this), Mask);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(4)]
    public D3D12_DEBUG_FEATURE GetFeatureMask()
    {
        return ((delegate* unmanaged<ID3D12DebugDevice*, D3D12_DEBUG_FEATURE>)(lpVtbl[4]))((ID3D12DebugDevice*)Unsafe.AsPointer(ref this));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(5)]
    public HRESULT ReportLiveDeviceObjects(D3D12_RLDO_FLAGS Flags)
    {
        return ((delegate* unmanaged<ID3D12DebugDevice*, D3D12_RLDO_FLAGS, int>)(lpVtbl[5]))((ID3D12DebugDevice*)Unsafe.AsPointer(ref this), Flags);
    }
}
