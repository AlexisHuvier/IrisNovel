﻿using CommandLine;
using IrisCore.Project;
using IrisPlayer;
using Serilog;
using Serilog.Context;

Parser.Default.ParseArguments<IPOptions>(args)
    .WithParsed(o =>
    {
        IPConstants.Logger = o.Debug.CreateLogger();

        if (!Directory.Exists(o.ProjectFolder))
        {
            IPConstants.Logger.Error("Project folder {Folder} not found", o.ProjectFolder);
            return;
        }

        IPConstants.Logger.Information("Loading project from {ProjectFolder}", o.ProjectFolder);
        var project = IrisProject.Load(o.ProjectFolder);
        IPConstants.Logger.Information("Project {ProjectName} loaded", project.MetaData.Name);

        IPConstants.Logger.Information("Creating player with project");
        var player = new Player(project);
        IPConstants.Logger.Information("Loading Iris resources");
        IPConstants.Logger.Information("Loading project resources");
        player.LoadResources();
        IPConstants.Logger.Information("Running player");
        player.Run();
        IPConstants.Logger.Information("Unloading all resources");
        player.UnloadResources();
        IPConstants.Logger.Information("Player stopped");
    });