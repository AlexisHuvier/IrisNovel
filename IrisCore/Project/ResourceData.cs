using IrisCore.Project.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisCore.Project;

public class ResourceData
{
    public Dictionary<string, Character> Characters { get; set; } = [];
    public Dictionary<string, string> Backgrounds { get; set; } = [];
    public Dictionary<string, Font> Fonts { get; set; } = [];
    public Dictionary<string, string> Music { get; set; } = [];
    public Dictionary<string, string> Sounds { get; set; } = [];
    public Dictionary<string, string> Scripts { get; set; } = [];

    public void AddCharacter(string name, string displayName, string color)
    {
        Characters[name] = new Character { 
            DisplayName = displayName, 
            Color = color 
        };
    }

    public void AddCharacterSprite(string characterName, string spriteName, string path)
    {
        if (!Characters.TryGetValue(characterName, out Character? value))
            throw new Exception("Character not found");
        value.Sprites[spriteName] = path;
    }

    public void AddBackground(string name, string path)
    {
        Backgrounds[name] = path;
    }

    public void AddFont(string name, string path, int size)
    {
        Fonts[name] = new Font
        {
            Path = path,
            Size = size
        };
    }

    public void AddMusic(string name, string path)
    {
        Music[name] = path;
    }

    public void AddSound(string name, string path)
    {
        Sounds[name] = path;
    }

    public void AddScript(string name, string path)
    {
        Scripts[name] = path;
    }
}
