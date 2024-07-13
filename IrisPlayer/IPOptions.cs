using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisPlayer
{
    internal class IPOptions
    {
        [Option('d', Required = false, Default = false, HelpText = "Enable debug mode.")]
        public bool Debug { get; set; }

        [Value(0, MetaName = "project folder", HelpText = "Project folder to be played.", Required = true)]
        public required string ProjectFolder { get; set; }

    }
}
