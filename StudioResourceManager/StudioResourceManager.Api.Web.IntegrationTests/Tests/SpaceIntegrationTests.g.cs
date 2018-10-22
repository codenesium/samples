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
	[Trait("Table", "Space")]
	[Trait("Area", "Integration")]
	public class SpaceIntegrationTests
	{
		public SpaceIntegrationTests()
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

			await client.SpaceDeleteAsync(1);

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

			ApiSpaceResponseModel model = await client.SpaceGetAsync(1);

			ApiSpaceModelMapper mapper = new ApiSpaceModelMapper();

			UpdateResponse<ApiSpaceResponseModel> updateResponse = await client.SpaceUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiSpaceRequestModel();
			createModel.SetProperties("B", "B");
			CreateResponse<ApiSpaceResponseModel> createResult = await client.SpaceCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiSpaceResponseModel getResponse = await client.SpaceGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.SpaceDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiSpaceResponseModel verifyResponse = await client.SpaceGetAsync(2);

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
			ApiSpaceResponseModel response = await client.SpaceGetAsync(1);

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

			List<ApiSpaceResponseModel> response = await client.SpaceAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSpaceResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSpaceRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiSpaceResponseModel> result = await client.SpaceCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>f232855c7b4e404929fc6d480ced8009</Hash>
</Codenesium>*/