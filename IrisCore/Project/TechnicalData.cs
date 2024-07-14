using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisCore.Project;

public class TechnicalData
{
    public required string StartScript { get; set; }
    public Dictionary<string, string> Variables { get; set; } = [];
}
