﻿
using SDL_Sharp;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisPlayer
{
    public static class IPExtensions
    {
        public static Color ToColor(this string color)
        {
            if (color.StartsWith('#'))
            {
                color = color[1..];

                if (color.Length != 6)
                    throw new ArgumentException("Color must be in the format RRGGBB");

                return new Color(
                    Convert.ToByte(color[..2], 16),
                    Convert.ToByte(color[2..4], 16),
                    Convert.ToByte(color[4..], 16),
                    255
                );
            }
            else
                throw new ArgumentException("Cannot create Color from string");
        }

        public static Logger CreateLogger(this bool debug)
        {
            var config = new LoggerConfiguration().WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Properties}{NewLine}{Exception}").Enrich.FromLogContext();
            if(debug)
                config.MinimumLevel.Debug();
            return config.CreateLogger();
                
        }
    }
}