// Copyright � Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/d3d12.h in the Windows SDK for Windows 10.0.22000.0
// Original source is Copyright � Microsoft. All rights reserved.

using TerraFX.Interop.Windows;

namespace TerraFX.Interop.DirectX;

internal readonly struct D3D12_FEATURE_DATA_D3D12_OPTIONS1
{
    public readonly BOOL WaveOps;
    public readonly uint WaveLaneCountMin;
    public readonly uint WaveLaneCountMax;
    public readonly uint TotalLaneCount;
    public readonly BOOL ExpandedComputeResourceStates;
    public readonly BOOL Int64ShaderOps;
}
