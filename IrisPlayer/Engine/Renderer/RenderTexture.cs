using SDL_Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisPlayer.Engine.Renderer;

public class RenderTexture
{
    public Texture Texture { get; }
    public int Width { get; }
    public int Height { get; }
    public Rect FullSource;
    public Point Center;
    public RenderTexture(Texture texture)
    {
        Texture = texture;

        SDL.QueryTexture(texture, out _, out _, out int texW, out int texH);

        Width = texW;
        Height = texH;
        FullSource = new Rect { X = 0, Y = 0, Width = texW, Height = texH };
        Center = new Point { X = texW / 2, Y = texH / 2 };

    }
}
