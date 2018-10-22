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
	[Trait("Table", "Venue")]
	[Trait("Area", "Integration")]
	public class VenueIntegrationTests
	{
		public VenueIntegrationTests()
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

			await client.VenueDeleteAsync(1);

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

			ApiVenueResponseModel model = await client.VenueGetAsync(1);

			ApiVenueModelMapper mapper = new ApiVenueModelMapper();

			UpdateResponse<ApiVenueResponseModel> updateResponse = await client.VenueUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiVenueRequestModel();
			createModel.SetProperties("B", "B", 1, "B", "B", "B", "B", 1, "B");
			CreateResponse<ApiVenueResponseModel> createResult = await client.VenueCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiVenueResponseModel getResponse = await client.VenueGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.VenueDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiVenueResponseModel verifyResponse = await client.VenueGetAsync(2);

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
			ApiVenueResponseModel response = await client.VenueGetAsync(1);

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

			List<ApiVenueResponseModel> response = await client.VenueAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVenueResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiVenueRequestModel();
			model.SetProperties("B", "B", 1, "B", "B", "B", "B", 1, "B");
			CreateResponse<ApiVenueResponseModel> result = await client.VenueCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>ef8f836f25a165fe71764047cd551a3a</Hash>
</Codenesium>*/