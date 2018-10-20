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
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "Integration")]
	public class PurchaseOrderHeaderIntegrationTests
	{
		public PurchaseOrderHeaderIntegrationTests()
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

			await client.PurchaseOrderHeaderDeleteAsync(1);

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

			ApiPurchaseOrderHeaderResponseModel model = await client.PurchaseOrderHeaderGetAsync(1);

			ApiPurchaseOrderHeaderModelMapper mapper = new ApiPurchaseOrderHeaderModelMapper();

			UpdateResponse<ApiPurchaseOrderHeaderResponseModel> updateResponse = await client.PurchaseOrderHeaderUpdateAsync(model.PurchaseOrderID, mapper.MapResponseToRequest(model));

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

			ApiPurchaseOrderHeaderResponseModel response = await client.PurchaseOrderHeaderGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.PurchaseOrderHeaderDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.PurchaseOrderHeaderGetAsync(1);

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
			ApiPurchaseOrderHeaderResponseModel response = await client.PurchaseOrderHeaderGetAsync(1);

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

			List<ApiPurchaseOrderHeaderResponseModel> response = await client.PurchaseOrderHeaderAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPurchaseOrderHeaderResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPurchaseOrderHeaderRequestModel();
			model.SetProperties(2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2m, 2m, 2m, 2);
			CreateResponse<ApiPurchaseOrderHeaderResponseModel> result = await client.PurchaseOrderHeaderCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>107737d2ee1aedd24af8d4d3396031dd</Hash>
</Codenesium>*/