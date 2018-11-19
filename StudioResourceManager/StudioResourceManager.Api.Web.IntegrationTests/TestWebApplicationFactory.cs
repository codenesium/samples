using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using StudioResourceManagerNS.Api.Web;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	public class TestWebApplicationFactory : WebApplicationFactory<TestStartup>
	{
		protected override IWebHostBuilder CreateWebHostBuilder()
		{
			return WebHost.CreateDefaultBuilder(new string[0])
			.UseStartup<TestStartup>();
		}
	}
}