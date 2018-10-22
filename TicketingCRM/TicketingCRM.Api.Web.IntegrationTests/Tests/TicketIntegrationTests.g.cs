using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Ticket")]
	[Trait("Area", "Integration")]
	public class TicketIntegrationTests
	{
		public TicketIntegrationTests()
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

			await client.TicketDeleteAsync(1);

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

			ApiTicketResponseModel model = await client.TicketGetAsync(1);

			ApiTicketModelMapper mapper = new ApiTicketModelMapper();

			UpdateResponse<ApiTicketResponseModel> updateResponse = await client.TicketUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiTicketRequestModel();
			createModel.SetProperties("B", 1);
			CreateResponse<ApiTicketResponseModel> createResult = await client.TicketCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiTicketResponseModel getResponse = await client.TicketGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.TicketDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiTicketResponseModel verifyResponse = await client.TicketGetAsync(2);

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
			ApiTicketResponseModel response = await client.TicketGetAsync(1);

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

			List<ApiTicketResponseModel> response = await client.TicketAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTicketResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTicketRequestModel();
			model.SetProperties("B", 1);
			CreateResponse<ApiTicketResponseModel> result = await client.TicketCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>7c43403237f325f3d1b31c0ca9c8ab64</Hash>
</Codenesium>*/