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

			var createModel = new ApiLocationRequestModel();
			createModel.SetProperties(2, 2, "B");
			CreateResponse<ApiLocationResponseModel> createResult = await client.LocationCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiLocationResponseModel getResponse = await client.LocationGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.LocationDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiLocationResponseModel verifyResponse = await client.LocationGetAsync(2);

			verifyResponse.Should().BeNull();
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
    <Hash>fbf48d32de28d638127c0bc12eccd793</Hash>
</Codenesium>*/