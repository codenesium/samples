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
	[Trait("Table", "Client")]
	[Trait("Area", "Integration")]
	public class ClientIntegrationTests
	{
		public ClientIntegrationTests()
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

			await client.ClientDeleteAsync(1);

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

			ApiClientResponseModel model = await client.ClientGetAsync(1);

			ApiClientModelMapper mapper = new ApiClientModelMapper();

			UpdateResponse<ApiClientResponseModel> updateResponse = await client.ClientUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiClientRequestModel();
			createModel.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiClientResponseModel> createResult = await client.ClientCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiClientResponseModel getResponse = await client.ClientGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.ClientDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiClientResponseModel verifyResponse = await client.ClientGetAsync(2);

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
			ApiClientResponseModel response = await client.ClientGetAsync(1);

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

			List<ApiClientResponseModel> response = await client.ClientAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiClientResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiClientRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiClientResponseModel> result = await client.ClientCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>368e2ecf506ff86b7da71a65e18bc958</Hash>
</Codenesium>*/