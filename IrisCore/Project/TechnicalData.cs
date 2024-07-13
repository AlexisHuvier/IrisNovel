using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisCore.Project;

public class TechnicalData
{
    public required string MainScript { get; set; }
    public Dictionary<string, string> Scripts { get; set; } = [];
    public Dictionary<string, string> Variables { get; set; } = [];
}
