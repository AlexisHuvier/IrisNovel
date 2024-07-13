using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisCore.Project.Resource;

public class Character
{
    public required string DisplayName { get; set; }
    public required string Color { get; set; }
    public Dictionary<string, string> Sprites { get; set; } = [];
}
