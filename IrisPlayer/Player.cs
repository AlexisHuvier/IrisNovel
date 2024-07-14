using IrisCore.Project;
using IrisPlayer.Engine;
using SDL_Sharp.Ttf;
using SDL_Sharp;
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
        public IrisWindow Window { get; } = new IrisWindow(project);

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
            foreach (var backgrounds in Project.ResourceData.Backgrounds)
                Window.ResourceManager.LoadTexture(backgrounds.Key, Path.Combine(Project.Folder, backgrounds.Value));
        }

        public void UnloadResources()
        {
            Window.ResourceManager.UnloadAllTextures();
            Window.ResourceManager.UnloadAllFonts();

            TTF.Quit();
            SDL.Quit();
        }
    }
}
