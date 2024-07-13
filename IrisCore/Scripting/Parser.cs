using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisCore.Scripting;

internal class Parser
{
    public static List<Expression> Parse(string script)
    {
        var expressions = new List<Expression>();
        var lines = script.Replace("\r", "").Split("\n");
        foreach (var line in lines)
        {
            var parts = line.Split(" ");
            expressions.Add(new Expression(parts[0], ProcessString(parts.Skip(1).ToList())));
        }
        return expressions;
    }

    private static List<string> ProcessString(List<string> parts)
    {
        var result = new List<string>();

        var isInString = false;
        var currentString = "";
        foreach (var part in parts)
        {
            if(isInString)
            {
                currentString += " " + part; 
                if(part.EndsWith('"'))
                {
                    result.Add(currentString[..^1]);
                    isInString = false;
                }
            }
            else
            {
                if(part.StartsWith('"'))
                {
                    if(part.EndsWith('"'))
                        result.Add(part);
                    else
                    {
                        currentString = part[1..];
                        isInString = true;
                    }
                }
                else
                    result.Add(part);
            }
        }

        return result;
    }
}
