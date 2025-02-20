// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using Vortice.Mathematics;
using Vortice.Graphics;

namespace Vortice;

public abstract class GameView
{
    public event EventHandler? SizeChanged;

    public abstract SizeI ClientSize { get; }

    public abstract GraphicsSurface Surface { get; }

    public SwapChain? SwapChain { get; private set; }

    public void CreateSwapChain(GraphicsDevice device)
    {
        SwapChainDescriptor descriptor = new()
        {
            Size = ClientSize,
        };
        
        SwapChain = device.CreateSwapChain(Surface, descriptor);
    }

    public void Present()
    {
        SwapChain?.Present();
    }

    protected virtual void OnSizeChanged()
    {
        SizeChanged?.Invoke(this, EventArgs.Empty);
    }
}
