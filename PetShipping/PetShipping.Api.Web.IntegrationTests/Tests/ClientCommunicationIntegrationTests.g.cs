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
	[Trait("Table", "ClientCommunication")]
	[Trait("Area", "Integration")]
	public class ClientCommunicationIntegrationTests
	{
		public ClientCommunicationIntegrationTests()
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

			await client.ClientCommunicationDeleteAsync(1);

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

			ApiClientCommunicationResponseModel model = await client.ClientCommunicationGetAsync(1);

			ApiClientCommunicationModelMapper mapper = new ApiClientCommunicationModelMapper();

			UpdateResponse<ApiClientCommunicationResponseModel> updateResponse = await client.ClientCommunicationUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiClientCommunicationResponseModel response = await client.ClientCommunicationGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ClientCommunicationDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ClientCommunicationGetAsync(1);

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
			ApiClientCommunicationResponseModel response = await client.ClientCommunicationGetAsync(1);

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

			List<ApiClientCommunicationResponseModel> response = await client.ClientCommunicationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiClientCommunicationResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiClientCommunicationRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
			CreateResponse<ApiClientCommunicationResponseModel> result = await client.ClientCommunicationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>005ce6312d0667df033ae201f7e5a53e</Hash>
</Codenesium>*/