// Copyright � Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/d3d12.h in the Windows SDK for Windows 10.0.22000.0
// Original source is Copyright � Microsoft. All rights reserved.

using TerraFX.Interop.Windows;

namespace TerraFX.Interop.DirectX;

/// <include file='ID3D12CommandAllocator.xml' path='doc/member[@name="ID3D12CommandAllocator"]/*' />
[Guid("6102DEE4-AF59-4B09-B999-B44D73F09B24")]
[NativeTypeName("struct ID3D12CommandAllocator : ID3D12Pageable")]
[NativeInheritance("ID3D12Pageable")]
internal unsafe partial struct ID3D12CommandAllocator
{
    public void** lpVtbl;

    /// <inheritdoc cref="IUnknown.QueryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(0)]
    public HRESULT QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandAllocator*, Guid*, void**, int>)(lpVtbl[0]))((ID3D12CommandAllocator*)Unsafe.AsPointer(ref this), riid, ppvObject);
    }

    /// <inheritdoc cref="IUnknown.AddRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(1)]
    [return: NativeTypeName("ULONG")]
    public uint AddRef()
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandAllocator*, uint>)(lpVtbl[1]))((ID3D12CommandAllocator*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IUnknown.Release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(2)]
    [return: NativeTypeName("ULONG")]
    public uint Release()
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandAllocator*, uint>)(lpVtbl[2]))((ID3D12CommandAllocator*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ID3D12Object.GetPrivateData" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(3)]
    public HRESULT GetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint* pDataSize, void* pData)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandAllocator*, Guid*, uint*, void*, int>)(lpVtbl[3]))((ID3D12CommandAllocator*)Unsafe.AsPointer(ref this), guid, pDataSize, pData);
    }

    /// <inheritdoc cref="ID3D12Object.SetPrivateData" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(4)]
    public HRESULT SetPrivateData([NativeTypeName("const GUID &")] Guid* guid, uint DataSize, [NativeTypeName("const void *")] void* pData)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandAllocator*, Guid*, uint, void*, int>)(lpVtbl[4]))((ID3D12CommandAllocator*)Unsafe.AsPointer(ref this), guid, DataSize, pData);
    }

    /// <inheritdoc cref="ID3D12Object.SetPrivateDataInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(5)]
    public HRESULT SetPrivateDataInterface([NativeTypeName("const GUID &")] Guid* guid, [NativeTypeName("const IUnknown *")] IUnknown* pData)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandAllocator*, Guid*, IUnknown*, int>)(lpVtbl[5]))((ID3D12CommandAllocator*)Unsafe.AsPointer(ref this), guid, pData);
    }

    /// <inheritdoc cref="ID3D12Object.SetName" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(6)]
    public HRESULT SetName([NativeTypeName("LPCWSTR")] ushort* Name)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandAllocator*, ushort*, int>)(lpVtbl[6]))((ID3D12CommandAllocator*)Unsafe.AsPointer(ref this), Name);
    }

    /// <inheritdoc cref="ID3D12DeviceChild.GetDevice" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(7)]
    public HRESULT GetDevice([NativeTypeName("const IID &")] Guid* riid, void** ppvDevice)
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandAllocator*, Guid*, void**, int>)(lpVtbl[7]))((ID3D12CommandAllocator*)Unsafe.AsPointer(ref this), riid, ppvDevice);
    }

    /// <include file='ID3D12CommandAllocator.xml' path='doc/member[@name="ID3D12CommandAllocator.Reset"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(8)]
    public HRESULT Reset()
    {
        return ((delegate* unmanaged[Stdcall]<ID3D12CommandAllocator*, int>)(lpVtbl[8]))((ID3D12CommandAllocator*)Unsafe.AsPointer(ref this));
    }
}
