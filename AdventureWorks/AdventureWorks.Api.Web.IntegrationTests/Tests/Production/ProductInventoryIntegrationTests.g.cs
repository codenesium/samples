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
	[Trait("Table", "ProductInventory")]
	[Trait("Area", "Integration")]
	public class ProductInventoryIntegrationTests
	{
		public ProductInventoryIntegrationTests()
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

			await client.ProductInventoryDeleteAsync(1);

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

			ApiProductInventoryResponseModel model = await client.ProductInventoryGetAsync(1);

			ApiProductInventoryModelMapper mapper = new ApiProductInventoryModelMapper();

			UpdateResponse<ApiProductInventoryResponseModel> updateResponse = await client.ProductInventoryUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

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

			ApiProductInventoryResponseModel response = await client.ProductInventoryGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ProductInventoryDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ProductInventoryGetAsync(1);

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
			ApiProductInventoryResponseModel response = await client.ProductInventoryGetAsync(1);

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

			List<ApiProductInventoryResponseModel> response = await client.ProductInventoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductInventoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiProductInventoryRequestModel();
			model.SetProperties(2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");
			CreateResponse<ApiProductInventoryResponseModel> result = await client.ProductInventoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>a6e01d8769edfd46f8f8081ab6145670</Hash>
</Codenesium>*/