using IrisCore.Project.Resource;
using IrisCore.Scripting;
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

    public Dictionary<string, List<Expression>> ScriptsImplementations = [];

    public void Save(string path) {
        File.WriteAllText(path, JsonSerializer.Serialize(this));
    }

    public static IrisProject Load(string path) {
        var project = JsonSerializer.Deserialize<IrisProject>(File.ReadAllText(Path.Combine(path, "project.json"))) ?? throw new Exception("Failed to load project");
        project.Folder = path;

        project.ScriptsImplementations.Add("__main__", Parser.Parse(File.ReadAllText(Path.Combine(path, project.TechnicalData.MainScript))));
        foreach (var script in project.TechnicalData.Scripts)
            project.ScriptsImplementations.Add(script.Key, Parser.Parse(File.ReadAllText(Path.Combine(path, script.Value))));

        return project;
    }
}
