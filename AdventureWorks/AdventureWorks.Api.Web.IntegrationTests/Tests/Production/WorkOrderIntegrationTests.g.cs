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
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "Integration")]
	public class WorkOrderIntegrationTests
	{
		public WorkOrderIntegrationTests()
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

			await client.WorkOrderDeleteAsync(1);

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

			ApiWorkOrderResponseModel model = await client.WorkOrderGetAsync(1);

			ApiWorkOrderModelMapper mapper = new ApiWorkOrderModelMapper();

			UpdateResponse<ApiWorkOrderResponseModel> updateResponse = await client.WorkOrderUpdateAsync(model.WorkOrderID, mapper.MapResponseToRequest(model));

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

			ApiWorkOrderResponseModel response = await client.WorkOrderGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.WorkOrderDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.WorkOrderGetAsync(1);

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
			ApiWorkOrderResponseModel response = await client.WorkOrderGetAsync(1);

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

			List<ApiWorkOrderResponseModel> response = await client.WorkOrderAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiWorkOrderResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiWorkOrderRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			CreateResponse<ApiWorkOrderResponseModel> result = await client.WorkOrderCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>f7075ca4b80d33b7d7e69d099a7c95a3</Hash>
</Codenesium>*/