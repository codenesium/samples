using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
    public class Program
    {
		public static void Main(string[] args)
        {
            CreateWebHostBuilderForServiceIDE(args).Build().Run();

			/* uncomment to support hosting as a windows service 
			bool isService = !(Debugger.IsAttached || args.Contains("--console"));

            if (isService)
            {
                CreateWebHostBuilderForService(args).Build().RunAsCustomService();
            }
            else
            {
                CreateWebHostBuilderForServiceIDE(args).Build().Run();
            }
			*/
        }

        public static IWebHostBuilder CreateWebHostBuilderForServiceIDE(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                     .UseStartup<Startup>()
                     .UseKestrel()
                     .UseUrls("http://0.0.0.0:8000");
        }

        public static IWebHostBuilder CreateWebHostBuilderForService(string[] args)
        {
            string pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            string pathToContentRoot = Path.GetDirectoryName(pathToExe);

            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                })
                .UseContentRoot(pathToContentRoot)
                .UseStartup<Startup>()
                .UseKestrel()
                .UseUrls("http://0.0.0.0:8000");
        }
    }
}