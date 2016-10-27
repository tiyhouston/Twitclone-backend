using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder().AddCommandLine(args).Build();
        
        var host = new WebHostBuilder()
            .UseKestrel()
            .UseWebRoot("assets")
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseConfiguration(config)
            .UseIISIntegration()
            .UseStartup<Handler>()
            .Build();

        host.Run();
    }
}

