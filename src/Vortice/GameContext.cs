// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Diagnostics;
using Vortice.Graphics;

namespace Vortice;

public abstract class GameContext
{
    /// <summary>
    /// Gets the main view.
    /// </summary>
    public abstract GameView View { get; }

    public virtual void ConfigureServices(IServiceCollection services)
    {
    }

    public abstract void RunMainLoop(Action init, Action callback);
}
