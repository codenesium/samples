using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Security.Claims;
using PetStoreNS.Api.Web;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Web.IntegrationTests
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
			JWTHelper jwtHelper = new JWTHelper();
			return jwtHelper.GenerateBearerToken(
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