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
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "Integration")]
	public class TicketStatuIntegrationTests
	{
		public TicketStatuIntegrationTests()
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

			await client.TicketStatuDeleteAsync(1);

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

			ApiTicketStatuResponseModel model = await client.TicketStatuGetAsync(1);

			ApiTicketStatuModelMapper mapper = new ApiTicketStatuModelMapper();

			UpdateResponse<ApiTicketStatuResponseModel> updateResponse = await client.TicketStatuUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiTicketStatuRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiTicketStatuResponseModel> createResult = await client.TicketStatuCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiTicketStatuResponseModel getResponse = await client.TicketStatuGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.TicketStatuDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiTicketStatuResponseModel verifyResponse = await client.TicketStatuGetAsync(2);

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
			ApiTicketStatuResponseModel response = await client.TicketStatuGetAsync(1);

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

			List<ApiTicketStatuResponseModel> response = await client.TicketStatuAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTicketStatuResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTicketStatuRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiTicketStatuResponseModel> result = await client.TicketStatuCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>64e7b47719e5e0d7c764965115aba9e3</Hash>
</Codenesium>*/