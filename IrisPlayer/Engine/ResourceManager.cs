using IrisCore.Project.Resource;
using IrisPlayer.Engine.Renderer;
using SDL_Sharp;
using SDL_Sharp.Image;
using SDL_Sharp.Ttf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisPlayer.Engine;

public class ResourceManager(IrisRenderer renderer)
{
    private readonly Dictionary<string, RenderTexture> _textures = [];
    private readonly Dictionary<string, SDL_Sharp.Ttf.Font> _fonts = [];
    private readonly IrisRenderer _renderer = renderer;

    public void LoadTexture(string name, string path)
    {
        if (_textures.ContainsKey(name))
        {
            IPConstants.Logger.Warning("Texture {textureName} already loaded", name);
            return;
        }

        var texture = IMG.LoadTexture(_renderer.Renderer, path);
        if (texture.IsNull)
        { 
            IPConstants.Logger.Error("Failed to load texture {texturePath} : {error}", path, SDL.GetError());
            return;
        }

        IPConstants.Logger.Debug("Texture {textureName} loaded", name);
        _textures.Add(path, new RenderTexture(texture));
    }

    public RenderTexture GetTexture(string name)
    {
        if (_textures.TryGetValue(name, out var value) && value != null)
            return value;
        
        IPConstants.Logger.Error("Texture {textureName} not found", name);
        throw new ArgumentException($"Texture {name} not found");
    }

    public void UnloadAllTextures()
    {
        foreach (var texture in _textures)
        {
            IPConstants.Logger.Debug("Texture {textureName} unloaded", texture.Key);
            SDL.DestroyTexture(texture.Value.Texture);
        }
        _textures.Clear();

        IPConstants.Logger.Information("All textures unloaded");
    }

    public void LoadFont(string name, IrisCore.Project.Resource.Font fontInfo)
    {
        if (_fonts.ContainsKey(name))
        {
            IPConstants.Logger.Warning("Font {fontName} already loaded", name);
            return;
        }

        var font = TTF.OpenFont(fontInfo.RealPath, fontInfo.Size);
        if (font.IsNull)
        {
            IPConstants.Logger.Error("Failed to load font {@fontInfo} : {error}", fontInfo, SDL.GetError());
            return;
        }

        IPConstants.Logger.Debug("Font {fontName} loaded", name);
        _fonts.Add(name, font);
    }

    public SDL_Sharp.Ttf.Font GetFont(string name)
    {
        if (_fonts.TryGetValue(name, out SDL_Sharp.Ttf.Font value))
            return value;
        
        IPConstants.Logger.Error("Font {fontName} not found", name);
        throw new ArgumentException($"Font {name} not found");
    }

    public void UnloadAllFonts()
    {
        foreach (var font in _fonts)
        {
            IPConstants.Logger.Debug("Font {fontName} unloaded", font.Key);
            TTF.CloseFont(font.Value);
        }
        _fonts.Clear();

        IPConstants.Logger.Information("All fonts unloaded");
    }
}
