using IrisPlayer.Engine.Renderer;
using SDL_Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisPlayer.Engine;

public class IrisWindow
{
    public bool IsRunning { get; set; }
    public ResourceManager ResourceManager { get; }
    public IrisRenderer Renderer { get; }

    internal Window Window { get; }

    public IrisWindow(int weight, int height, string title, Color backgroundColor)
    {

        SDL.Init(SdlInitFlags.Video);
        Window = SDL.CreateWindow(title, SDL.WINDOWPOS_UNDEFINED, SDL.WINDOWPOS_UNDEFINED, weight, height, WindowFlags.Resizable);
        if (Window.IsNull)
        {
            IPConstants.Logger.Error("Failed to create window");
            throw new Exception("Failed to create window");
        }

        Renderer = new IrisRenderer(this)
        {
            ClearColor = backgroundColor
        };

        ResourceManager = new ResourceManager(Renderer);

        IPConstants.Logger.Debug("Base Path SDL : {BasePath}", SDL.GetBasePath());
    }

    public void Run()
    {
        SDL.ShowWindow(Window);
        IsRunning = true;
        while(IsRunning)
        {
            while(SDL.PollEvent(out var e) != 0)
            {
                if(e.Type == EventType.Quit)
                    IsRunning = false;
            }

            Renderer.Clear();

            // RENDER THINGS HERE

            Renderer.Render();
        }

        Renderer.Destroy();
        SDL.DestroyWindow(Window);
    }
}
