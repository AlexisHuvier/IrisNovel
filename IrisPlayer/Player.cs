﻿using IrisCore.Project;
using IrisPlayer.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisPlayer
{
    internal class Player(IrisProject project)
    {
        public IrisProject Project { get; } = project;
        public IrisWindow Window { get; } = new IrisWindow(project.WindowData.Width, project.WindowData.Height, project.WindowData.Title, project.WindowData.BackgroundColor.ToColor());

        public void Run()
        {
            Window.Run();
        }

        public void LoadResources()
        {
            foreach(var fonts in Project.ResourceData.Fonts)
                Window.ResourceManager.LoadFont(fonts.Key, fonts.Value.UpdatedWithFolder(Project.Folder));
            foreach (var characters in Project.ResourceData.Characters)
            {
                foreach(var sprite in characters.Value.Sprites)
                    Window.ResourceManager.LoadTexture(sprite.Key, Path.Combine(Project.Folder, sprite.Value));
            }
        }

        public void UnloadResources()
        {
            Window.ResourceManager.UnloadAllTextures();
            Window.ResourceManager.UnloadAllFonts();
        }
    }
}