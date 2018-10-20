using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "WorkOrderRouting")]
	[Trait("Area", "Integration")]
	public class WorkOrderRoutingIntegrationTests
	{
		public WorkOrderRoutingIntegrationTests()
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

			await client.WorkOrderRoutingDeleteAsync(1);

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

			ApiWorkOrderRoutingResponseModel model = await client.WorkOrderRoutingGetAsync(1);

			ApiWorkOrderRoutingModelMapper mapper = new ApiWorkOrderRoutingModelMapper();

			UpdateResponse<ApiWorkOrderRoutingResponseModel> updateResponse = await client.WorkOrderRoutingUpdateAsync(model.WorkOrderID, mapper.MapResponseToRequest(model));

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

			ApiWorkOrderRoutingResponseModel response = await client.WorkOrderRoutingGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.WorkOrderRoutingDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.WorkOrderRoutingGetAsync(1);

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
			ApiWorkOrderRoutingResponseModel response = await client.WorkOrderRoutingGetAsync(1);

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

			List<ApiWorkOrderRoutingResponseModel> response = await client.WorkOrderRoutingAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiWorkOrderRoutingResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiWorkOrderRoutingRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiWorkOrderRoutingResponseModel> result = await client.WorkOrderRoutingCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>350d74eb699392e4520b1994e45348ee</Hash>
</Codenesium>*/