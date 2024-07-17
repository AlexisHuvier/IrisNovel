using IrisCore.Project.Resource;
using NLua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IrisCore.Project;

public class IrisProject
{
    public string Folder { get; set; } = "";

    public required MetaData MetaData { get; set; }
    public required WindowData WindowData { get; set; }
    public required ResourceData ResourceData { get; set; }
    public required TechnicalData TechnicalData { get; set; }

    public static IrisProject Load(string path) {
        var project = new IrisProject
        {
            Folder = path,
            MetaData = new() { Author = "", IrisVersion = "", Name = "" },
            WindowData = new() { Height = 600, Width = 800, BackgroundColor = "#000000", DefaultFont = "IrisDefault", Title = "Iris Project" },
            ResourceData = new() { Characters = [], Backgrounds = [], Music = [], Sounds = [], Fonts = [], Scripts = [] },
            TechnicalData = new() { StartScript = "", Variables = [] }
        };

        using Lua lua = new();
        lua.DoFile(Path.Combine(path, "project.lua"));

        var setupMetaFunction = lua.GetFunction("setupMeta");
        setupMetaFunction.Call(project.MetaData);

        var setupWindowFunction = lua.GetFunction("setupWindow");
        setupWindowFunction.Call(project.WindowData);

        var setupResourcesFunction = lua.GetFunction("setupResources");
        setupResourcesFunction.Call(project.ResourceData);

        var setupTechnicalFunction = lua.GetFunction("setupTechnical");
        setupTechnicalFunction.Call(project.TechnicalData);

        return project;
    }
}
