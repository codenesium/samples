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
	[Trait("Table", "PurchaseOrderDetail")]
	[Trait("Area", "Integration")]
	public class PurchaseOrderDetailIntegrationTests
	{
		public PurchaseOrderDetailIntegrationTests()
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

			await client.PurchaseOrderDetailDeleteAsync(1);

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

			ApiPurchaseOrderDetailResponseModel model = await client.PurchaseOrderDetailGetAsync(1);

			ApiPurchaseOrderDetailModelMapper mapper = new ApiPurchaseOrderDetailModelMapper();

			UpdateResponse<ApiPurchaseOrderDetailResponseModel> updateResponse = await client.PurchaseOrderDetailUpdateAsync(model.PurchaseOrderID, mapper.MapResponseToRequest(model));

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

			ApiPurchaseOrderDetailResponseModel response = await client.PurchaseOrderDetailGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.PurchaseOrderDetailDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.PurchaseOrderDetailGetAsync(1);

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
			ApiPurchaseOrderDetailResponseModel response = await client.PurchaseOrderDetailGetAsync(1);

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

			List<ApiPurchaseOrderDetailResponseModel> response = await client.PurchaseOrderDetailAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPurchaseOrderDetailResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPurchaseOrderDetailRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, 2, 2, 2m);
			CreateResponse<ApiPurchaseOrderDetailResponseModel> result = await client.PurchaseOrderDetailCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>08f71fa09e1e69583e45f1b6e1e8812f</Hash>
</Codenesium>*/