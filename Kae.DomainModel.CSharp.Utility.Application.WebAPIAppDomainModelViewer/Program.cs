using Kae.DomainModel.Csharp.Framework.Adaptor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Kae.DomainModel.CSharp.Utility.Application.WebAPIAppDomainModelViewer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static string DomainModelAdaptorDllPath { get; set; }

        public static DomainModelAdaptor domainModelAdaptor;
        public static DomainModelAdaptor GetDomainModelAdaptor(Kae.Utility.Logging.Logger logger)
        {
            if (domainModelAdaptor == null)
            {
                if (!string.IsNullOrEmpty(DomainModelAdaptorDllPath))
                {
                    var adaptorAssembly = Assembly.LoadFrom(DomainModelAdaptorDllPath);
                    var loadedModules = adaptorAssembly.GetLoadedModules();
                    if (loadedModules.Length > 0)
                    {
                        var adaptorModule = loadedModules[0];
                        string nsOfAdaptor = adaptorModule.Name.Substring(0, adaptorModule.Name.LastIndexOf(".dll"));
                        var typeOfAdaptorEntry = adaptorModule.GetType($"{nsOfAdaptor}.Adaptor.DomainModelAdaptorEntry");
                        if (typeOfAdaptorEntry != null)
                        {
                            var methodOfGetAdaptor = typeOfAdaptorEntry.GetMethod("GetAdaptor");
                            if (methodOfGetAdaptor != null)
                            {
                                domainModelAdaptor = methodOfGetAdaptor.Invoke(null, new object[] { logger }) as DomainModelAdaptor;
                            }
                        }
                    }

                }
            }
            return domainModelAdaptor;
        }

    }
}
