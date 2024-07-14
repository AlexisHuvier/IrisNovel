using SDL_Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisPlayer.Engine.Scene;

public interface IScene
{
    public void Update(IrisWindow window, Event e);
    public void Render(IrisWindow window);
}
