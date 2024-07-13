using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisCore.Project;

public class WindowData
{
    public int Width { get; set; } = 800;
    public int Height { get; set; } = 600;
    public string Title { get; set; } = "Iris Game";
    public string BackgroundColor { get; set; } = "#000000";
    public string DefaultFont { get; set; } = "Default";
}
