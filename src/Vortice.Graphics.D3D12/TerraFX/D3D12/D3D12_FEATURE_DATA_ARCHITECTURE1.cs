// Copyright � Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/d3d12.h in the Windows SDK for Windows 10.0.22000.0
// Original source is Copyright � Microsoft. All rights reserved.

using TerraFX.Interop.Windows;

namespace TerraFX.Interop.DirectX;

internal partial struct D3D12_FEATURE_DATA_ARCHITECTURE1
{
    public readonly uint NodeIndex;
    public readonly BOOL TileBasedRenderer;
    public readonly BOOL UMA;
    public readonly BOOL CacheCoherentUMA;
    public readonly BOOL IsolatedMMU;
}
