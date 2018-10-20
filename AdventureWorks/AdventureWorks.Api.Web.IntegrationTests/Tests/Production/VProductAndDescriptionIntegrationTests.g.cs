using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "VProductAndDescription")]
	[Trait("Area", "Integration")]
	public class VProductAndDescriptionIntegrationTests
	{
		public VProductAndDescriptionIntegrationTests()
		{
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiVProductAndDescriptionResponseModel response = await client.VProductAndDescriptionGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			List<ApiVProductAndDescriptionResponseModel> response = await client.VProductAndDescriptionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}
	}
}

/*<Codenesium>
    <Hash>dee6f48f29a92342438a47c3efbccfe1</Hash>
</Codenesium>*/