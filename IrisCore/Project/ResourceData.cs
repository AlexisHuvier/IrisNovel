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
}
