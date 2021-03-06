﻿using System;
using DotNet.Cli.Flubu.Commanding;
using DotNet.Cli.Flubu.Infrastructure;
using FlubuCore.Commanding;
using FlubuCore.Infrastructure;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotNet.Cli.Flubu
{
    public static class Program
    {
        private static readonly IServiceCollection Services = new ServiceCollection();

        private static IServiceProvider _provider;

        public static int Main(string[] args)
        {
            if (args == null)
            {
                args = new string[0];
            }

            Services
                .AddCoreComponents()
                .AddCommandComponents()
                .AddScriptAnalyser()
                .AddArguments(args)
                .AddTasks();

            _provider = Services.BuildServiceProvider();
            ILoggerFactory factory = _provider.GetRequiredService<ILoggerFactory>();
            factory.AddProvider(new FlubuLoggerProvider());
            var cmdApp = _provider.GetRequiredService<CommandLineApplication>();
            ICommandExecutor executor = _provider.GetRequiredService<ICommandExecutor>();
            executor.FlubuHelpText = cmdApp.GetHelpText();
            var result = executor.ExecuteAsync().Result;
            return result;
        }
    }
}