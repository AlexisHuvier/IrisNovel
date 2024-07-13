using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisCore.Scripting;

public class Expression(string command, List<string> args)
{
    public string Command { get; } = command;
    public List<string> Arguments { get; } = args;
}
