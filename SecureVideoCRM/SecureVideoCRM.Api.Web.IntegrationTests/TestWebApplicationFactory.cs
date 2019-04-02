using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Security.Claims;
using SecureVideoCRMNS.Api.Web;
using SecureVideoCRMNS.Api.Services;

namespace SecureVideoCRMNS.Api.Web.IntegrationTests
{
	public class TestWebApplicationFactory : WebApplicationFactory<TestStartup>
	{
		protected override IWebHostBuilder CreateWebHostBuilder()
		{
			return WebHost.CreateDefaultBuilder(new string[0])
			.UseStartup<TestStartup>();
		}
	}

	public static class JWTTestHelper
	{
		public static string GenerateBearerToken()
		{
			JwtService jwtService = new JwtService();
			return jwtService.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$",
									  new List<Claim>()
									  );
		}
	}
}