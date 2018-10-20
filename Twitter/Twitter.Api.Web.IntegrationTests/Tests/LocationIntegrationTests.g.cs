using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Location")]
	[Trait("Area", "Integration")]
	public class LocationIntegrationTests
	{
		public LocationIntegrationTests()
		{
		}

		[Fact]
		public async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			await client.LocationDeleteAsync(1);

			var response = await this.CreateRecord(client);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			ApiLocationResponseModel model = await client.LocationGetAsync(1);

			ApiLocationModelMapper mapper = new ApiLocationModelMapper();

			UpdateResponse<ApiLocationResponseModel> updateResponse = await client.LocationUpdateAsync(model.LocationId, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
		}

		[Fact]
		public async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			ApiLocationResponseModel response = await client.LocationGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.LocationDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.LocationGetAsync(1);

			response.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiLocationResponseModel response = await client.LocationGetAsync(1);

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

			List<ApiLocationResponseModel> response = await client.LocationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiLocationResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiLocationRequestModel();
			model.SetProperties(2, 2, "B");
			CreateResponse<ApiLocationResponseModel> result = await client.LocationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>e48f7ae1c8a38e58575a3073afccf29f</Hash>
</Codenesium>*/