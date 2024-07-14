function setupMeta(meta)
    meta.Name = "Demo Project"
    meta.Author = "LavaPower"
    meta.IrisVersion = "1.0.0"
end

function setupWindow(window)
    window.Width = 800
    window.Height = 600
    window.Title = "Demo Project"
    window.BackgroundColor = "#aaaaaa"
    window.DefaultFont = "IrisDefault"
end

function setupResources(resources)
    resources:AddFont("Default", "fonts/default.ttf", 16)
    resources:AddCharacter("Player", "Player", "#ff0000")
    resources:AddCharacterSprite("Player", "Full", "characters/player/full.png")
    resources:AddBackground("Default", "backgrounds/default.png")
    resources:AddScript("Scene1", "scripts/scene1.lua")
end

function setupTechnical(technical)
    technical.StartScript = "Scene1"
end