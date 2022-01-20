// Copyright � Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Drawing;

namespace Vortice.Graphics;

public abstract class SwapChain : GraphicsResource
{
    protected SwapChain(GraphicsDevice device, in SwapChainDescriptor descriptor)
        : base(device)
    {
        Size = descriptor.Size;
        ColorFormat = descriptor.ColorFormat;
        PresentMode = descriptor.PresentMode;
        IsFullscreen = descriptor.IsFullscreen;
    }

    public Size Size { get; protected set; }

    public TextureFormat ColorFormat { get; protected set; }
    public PresentMode PresentMode { get; }
    public bool IsFullscreen { get; }

    public abstract Texture? CurrentBackBuffer { get; }

    public abstract int CurrentBackBufferIndex { get; }
    public abstract int BackBufferCount { get; }

    public abstract void Present();
}
