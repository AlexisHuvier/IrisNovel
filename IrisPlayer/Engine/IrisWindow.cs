using IrisCore.Project;
using IrisPlayer.Engine.Renderer;
using IrisPlayer.Engine.Scene;
using SDL_Sharp;
using SDL_Sharp.Ttf;
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
    public IrisProject Project { get; }
    public MainMenuScene MainMenuScene { get; }

    internal Window Window { get; }

    public IrisWindow(IrisProject irisProject)
    {
        Project = irisProject;

        SDL.Init(SdlInitFlags.Video);
        Window = SDL.CreateWindow(Project.WindowData.Title, SDL.WINDOWPOS_UNDEFINED, SDL.WINDOWPOS_UNDEFINED, Project.WindowData.Width, Project.WindowData.Height, WindowFlags.Resizable);
        if (Window.IsNull)
        {
            IPConstants.Logger.Error("Failed to create window : {error}", SDL.GetError());
            throw new Exception("Failed to create window");
        }

        Renderer = new IrisRenderer(this)
        {
            ClearColor = Project.WindowData.BackgroundColor.ToColor()
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
