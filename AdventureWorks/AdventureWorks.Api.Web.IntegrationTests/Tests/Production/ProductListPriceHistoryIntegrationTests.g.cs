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
	[Trait("Table", "ProductListPriceHistory")]
	[Trait("Area", "Integration")]
	public class ProductListPriceHistoryIntegrationTests
	{
		public ProductListPriceHistoryIntegrationTests()
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

			await client.ProductListPriceHistoryDeleteAsync(1);

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

			ApiProductListPriceHistoryResponseModel model = await client.ProductListPriceHistoryGetAsync(1);

			ApiProductListPriceHistoryModelMapper mapper = new ApiProductListPriceHistoryModelMapper();

			UpdateResponse<ApiProductListPriceHistoryResponseModel> updateResponse = await client.ProductListPriceHistoryUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

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

			ApiProductListPriceHistoryResponseModel response = await client.ProductListPriceHistoryGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ProductListPriceHistoryDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ProductListPriceHistoryGetAsync(1);

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
			ApiProductListPriceHistoryResponseModel response = await client.ProductListPriceHistoryGetAsync(1);

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

			List<ApiProductListPriceHistoryResponseModel> response = await client.ProductListPriceHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductListPriceHistoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiProductListPriceHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiProductListPriceHistoryResponseModel> result = await client.ProductListPriceHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>ffb7896eb7da7a27e34dc5c1f4e04586</Hash>
</Codenesium>*/