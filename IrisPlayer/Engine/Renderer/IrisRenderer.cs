using SDL_Sharp;
using SDL_Sharp.Ttf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisPlayer.Engine.Renderer
{
    public class IrisRenderer
    {
        public Color ClearColor { get; set; }

        internal SDL_Sharp.Renderer Renderer { get; }
        internal IrisWindow Window { get; }

        public IrisRenderer(IrisWindow window)
        {
            Window = window;
            Renderer = SDL.CreateRenderer(window.Window, -1, RendererFlags.Accelerated);
            if (Renderer.IsNull)
            {
                IPConstants.Logger.Error("Failed to create renderer : {error}", SDL.GetError());
                throw new Exception("Failed to create renderer");
            }
        }

        public void Clear()
        {
            SDL.SetRenderDrawColor(Renderer, ClearColor.R, ClearColor.G, ClearColor.B, ClearColor.A);
            SDL.RenderClear(Renderer);
        }

        public void Render()
        {
            SDL.RenderPresent(Renderer);
        }

        public void RenderTexture(string texture, int x, int y, double angle = 0f, RendererFlip flip = RendererFlip.None)
        {
            var renderTexture = Window.ResourceManager.GetTexture(texture);
            var destination = new Rect { X = x, Y = y, Width = renderTexture.Width, Height = renderTexture.Height };

            SDL.RenderCopyEx(Renderer, Window.ResourceManager.GetTexture(texture).Texture, ref renderTexture.FullSource, ref destination, angle, ref renderTexture.Center, flip);
        }

        public void RenderText(string font, string text, int x, int y) => RenderText(font, text, x, y, new Color { R = 0, G = 0, B = 0, A = 255 });

        public void RenderText(string font, string text, int x, int y, Color color)
        {
            var renderFont = Window.ResourceManager.GetFont(font);
            TTF.RenderText_Solid(renderFont, text, color, out PSurface surface);
            var renderTexture = new RenderTexture(SDL.CreateTextureFromSurface(Renderer, surface));
            var destination = new Rect { X = x, Y = y, Width = renderTexture.Width, Height = renderTexture.Height };

            SDL.RenderCopy(Renderer, renderTexture.Texture, ref renderTexture.FullSource, ref destination);

            SDL.FreeSurface(surface);
            SDL.DestroyTexture(renderTexture.Texture);
        }

        public (int Width, int Height) GetTextSize(string font, string text)
        {
            var renderFont = Window.ResourceManager.GetFont(font);
            TTF.RenderText_Solid(renderFont, text, new Color { }, out PSurface surface);
            var texture = new RenderTexture(SDL.CreateTextureFromSurface(Renderer, surface));
            return new(texture.Width, texture.Height);
        }

        public void Destroy()
        {
            SDL.DestroyRenderer(Renderer);
        }
    }
}
