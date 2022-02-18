// Copyright � Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/d3d12sdklayers.h in the Windows SDK for Windows 10.0.22000.0
// Original source is Copyright � Microsoft. All rights reserved.

namespace TerraFX.Interop.DirectX;

internal partial struct D3D12_RANGE
{
    [NativeTypeName("SIZE_T")]
    public nuint Begin;
    [NativeTypeName("SIZE_T")]
    public nuint End;
}
