// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

//using static Vortice.Audio.OpenAL.OpenALNative;

namespace Vortice.Audio.OpenAL;

internal unsafe class OpenALEngine : AudioDevice
{
    //private readonly nint _device;

    public OpenALEngine()
    {
        //_device = alcOpenDevice(null);
    }

    /// <inheritdoc />
    protected override void OnDispose()
    {
    }

    // <inheritdoc />
    public override AudioBackend BackendType => AudioBackend.OpenAL;
}
