using SDL_Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisPlayer.Engine.Scene;

public class MainMenuScene : IScene
{
    public void Render(IrisWindow window)
    {
        window.Renderer.RenderText(window.Project.WindowData.DefaultFont, window.Project.WindowData.Title, 200, 200);
    }

    public void Update(IrisWindow window, Event e)
    {
    }
}
