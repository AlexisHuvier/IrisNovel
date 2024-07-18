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
    internal Rect FullSource;
    internal Point Center;
    public RenderTexture(Texture texture)
    {
        Texture = texture;

        if(SDL.QueryTexture(texture, out _, out _, out int texW, out int texH) != 0)
            IPConstants.Logger.Error("Failed to query texture : {Error}", SDL.GetError());

        Width = texW;
        Height = texH;
        FullSource = new Rect { X = 0, Y = 0, Width = texW, Height = texH };
        Center = new Point { X = texW / 2, Y = texH / 2 };

    }
}
