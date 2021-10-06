﻿using System;
using System.Globalization;
using System.Windows.Input;
using Avalonia.Logging;
using OpenApogee.Models.Physics;
using ReactiveUI;

namespace OpenApogee.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public MainWindowViewModel() {
            LaunchRocketCommand = ReactiveCommand.Create(() => {
                Logger.Sink.Log(LogEventLevel.Information,LogArea.Control,"0", "Rocket Launched");
                SimplePhysicsSim sim = new SimplePhysicsSim();
                float temp = sim.Simulate();
                Logger.Sink.Log(LogEventLevel.Information,LogArea.Control,"0", $"{temp:N3}");



            });
        }

        public ICommand LaunchRocketCommand { get; }
    }
    
}