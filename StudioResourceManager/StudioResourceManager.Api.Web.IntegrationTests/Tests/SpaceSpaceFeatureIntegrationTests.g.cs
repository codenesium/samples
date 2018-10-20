using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "Integration")]
	public class SpaceSpaceFeatureIntegrationTests
	{
		public SpaceSpaceFeatureIntegrationTests()
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

			await client.SpaceSpaceFeatureDeleteAsync(1);

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

			ApiSpaceSpaceFeatureResponseModel model = await client.SpaceSpaceFeatureGetAsync(1);

			ApiSpaceSpaceFeatureModelMapper mapper = new ApiSpaceSpaceFeatureModelMapper();

			UpdateResponse<ApiSpaceSpaceFeatureResponseModel> updateResponse = await client.SpaceSpaceFeatureUpdateAsync(model.SpaceId, mapper.MapResponseToRequest(model));

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

			ApiSpaceSpaceFeatureResponseModel response = await client.SpaceSpaceFeatureGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SpaceSpaceFeatureDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SpaceSpaceFeatureGetAsync(1);

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
			ApiSpaceSpaceFeatureResponseModel response = await client.SpaceSpaceFeatureGetAsync(1);

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

			List<ApiSpaceSpaceFeatureResponseModel> response = await client.SpaceSpaceFeatureAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSpaceSpaceFeatureResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSpaceSpaceFeatureRequestModel();
			model.SetProperties(1, true);
			CreateResponse<ApiSpaceSpaceFeatureResponseModel> result = await client.SpaceSpaceFeatureCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>81f0e18c9ba4b9f375c0911db6a2950a</Hash>
</Codenesium>*/