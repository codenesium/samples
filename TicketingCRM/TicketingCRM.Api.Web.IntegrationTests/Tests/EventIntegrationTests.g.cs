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
	[Trait("Table", "Event")]
	[Trait("Area", "Integration")]
	public class EventIntegrationTests
	{
		public EventIntegrationTests()
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

			await client.EventDeleteAsync(1);

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

			ApiEventResponseModel model = await client.EventGetAsync(1);

			ApiEventModelMapper mapper = new ApiEventModelMapper();

			UpdateResponse<ApiEventResponseModel> updateResponse = await client.EventUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiEventResponseModel response = await client.EventGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.EventDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.EventGetAsync(1);

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
			ApiEventResponseModel response = await client.EventGetAsync(1);

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

			List<ApiEventResponseModel> response = await client.EventAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEventResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiEventRequestModel();
			model.SetProperties("B", "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiEventResponseModel> result = await client.EventCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>cb14897329c75c68ccda218c3b036933</Hash>
</Codenesium>*/