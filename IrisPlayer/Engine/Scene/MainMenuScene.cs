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
        var (Width, _) = window.Renderer.GetTextSize(window.Project.WindowData.DefaultFont, window.Project.WindowData.Title);
        window.Renderer.RenderText(window.Project.WindowData.DefaultFont, window.Project.WindowData.Title, (window.Project.WindowData.Width - Width) / 2, 50);
    }

    public void Update(IrisWindow window, Event e)
    {
    }
}
