using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Destination")]
	[Trait("Area", "Integration")]
	public class DestinationIntegrationTests
	{
		public DestinationIntegrationTests()
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

			await client.DestinationDeleteAsync(1);

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

			ApiDestinationResponseModel model = await client.DestinationGetAsync(1);

			ApiDestinationModelMapper mapper = new ApiDestinationModelMapper();

			UpdateResponse<ApiDestinationResponseModel> updateResponse = await client.DestinationUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiDestinationRequestModel();
			createModel.SetProperties(1, "B", 2);
			CreateResponse<ApiDestinationResponseModel> createResult = await client.DestinationCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiDestinationResponseModel getResponse = await client.DestinationGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.DestinationDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiDestinationResponseModel verifyResponse = await client.DestinationGetAsync(2);

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
			ApiDestinationResponseModel response = await client.DestinationGetAsync(1);

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

			List<ApiDestinationResponseModel> response = await client.DestinationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDestinationResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiDestinationRequestModel();
			model.SetProperties(1, "B", 2);
			CreateResponse<ApiDestinationResponseModel> result = await client.DestinationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>ce051503e71a978c1ecbcc4fc942c80a</Hash>
</Codenesium>*/