// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SignalRSample.Web
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseSetting(WebHostDefaults.PreventHostingStartupKey, "true")
                .ConfigureLogging(factory =>
                {
                    factory.AddConsole();
                })
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("Development")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
