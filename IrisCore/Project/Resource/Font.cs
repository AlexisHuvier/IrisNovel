using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisCore.Project.Resource;

public class Font
{
    public string Path { get; set; } = "";
    public string RealPath { get; set; } = "";
    public int Size { get; set; }

    public Font UpdatedWithFolder(string folder)
    {
        RealPath = System.IO.Path.Combine(folder, Path);
        return this;
    }
}
