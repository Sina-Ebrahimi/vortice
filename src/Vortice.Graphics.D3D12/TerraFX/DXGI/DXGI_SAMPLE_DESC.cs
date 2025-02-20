// Copyright � Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from shared/dxgicommon.h in the Windows SDK for Windows 10.0.22000.0
// Original source is Copyright � Microsoft. All rights reserved.

namespace TerraFX.Interop.DirectX;

internal readonly struct DXGI_SAMPLE_DESC
{
    public readonly uint Count;

    public readonly uint Quality;

    public DXGI_SAMPLE_DESC(uint count, uint quality)
    {
        Count = count;
        Quality = quality;
    }
}
