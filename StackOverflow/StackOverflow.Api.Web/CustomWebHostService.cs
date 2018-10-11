using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using System.ServiceProcess;

namespace StackOverflowNS.Api.Web
{
    public class CustomWebHostService : WebHostService
    {
        public CustomWebHostService(IWebHost host) 
            : base(host)
        {
        }

        protected override void OnStarting(string[] args)
        {
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {
            base.OnStarted();
        }

        protected override void OnStopping()
        {
            base.OnStopping();
        }
    }

    public static class WebHostServiceExtensions
    {
        public static void RunAsCustomService(this IWebHost host)
        {
            var webHostService = new CustomWebHostService(host);
            ServiceBase.Run(webHostService);
        }
    }
}