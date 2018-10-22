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
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "Integration")]
	public class SpaceFeatureIntegrationTests
	{
		public SpaceFeatureIntegrationTests()
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

			await client.SpaceFeatureDeleteAsync(1);

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

			ApiSpaceFeatureResponseModel model = await client.SpaceFeatureGetAsync(1);

			ApiSpaceFeatureModelMapper mapper = new ApiSpaceFeatureModelMapper();

			UpdateResponse<ApiSpaceFeatureResponseModel> updateResponse = await client.SpaceFeatureUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiSpaceFeatureRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiSpaceFeatureResponseModel> createResult = await client.SpaceFeatureCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiSpaceFeatureResponseModel getResponse = await client.SpaceFeatureGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.SpaceFeatureDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiSpaceFeatureResponseModel verifyResponse = await client.SpaceFeatureGetAsync(2);

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
			ApiSpaceFeatureResponseModel response = await client.SpaceFeatureGetAsync(1);

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

			List<ApiSpaceFeatureResponseModel> response = await client.SpaceFeatureAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSpaceFeatureResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSpaceFeatureRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiSpaceFeatureResponseModel> result = await client.SpaceFeatureCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>d1d89b389a06cc6d671242a9cae5eacc</Hash>
</Codenesium>*/