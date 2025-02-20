// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using Microsoft.Extensions.DependencyInjection;
using Vortice.Graphics;
using static SDL2.SDL;
using static SDL2.SDL.SDL_EventType;

namespace Vortice;

public sealed class SDL2GameContext : GameContext
{
    private const int _eventsPerPeep = 64;
    private readonly SDL_Event[] _events = new SDL_Event[_eventsPerPeep];

    private bool _exiting = false;

    public SDL2GameContext()
    {
        // Init SDL2
        if (SDL_Init(SDL_INIT_VIDEO | SDL_INIT_TIMER | SDL_INIT_GAMECONTROLLER) != 0)
        {
            SDL_Log($"Unable to initialize SDL: {SDL_GetError()}");
            throw new Exception("");
        }

        View = new SDL2GameView();
    }

    // <inheritdoc />
    public override GameView View { get; }

    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
    }

    public override void RunMainLoop(Action init, Action callback)
    {
        init();

        while (!_exiting)
        {
            PollSDLEvents();
            callback();
        }

        SDL_Quit();
    }

    private void PollSDLEvents()
    {
        SDL_PumpEvents();
        int eventsRead;

        do
        {
            eventsRead = SDL_PeepEvents(_events, _eventsPerPeep, SDL_eventaction.SDL_GETEVENT, SDL_EventType.SDL_FIRSTEVENT, SDL_EventType.SDL_LASTEVENT);
            for (int i = 0; i < eventsRead; i++)
            {
                handleSDLEvent(_events[i]);
            }
        } while (eventsRead == _eventsPerPeep);
    }

    private void handleSDLEvent(SDL_Event e)
    {
        switch (e.type)
        {
            case SDL_QUIT:
            case SDL_APP_TERMINATING:
                _exiting = true;
                break;
        }
    }
}
