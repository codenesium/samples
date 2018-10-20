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
	[Trait("Table", "ShoppingCartItem")]
	[Trait("Area", "Integration")]
	public class ShoppingCartItemIntegrationTests
	{
		public ShoppingCartItemIntegrationTests()
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

			await client.ShoppingCartItemDeleteAsync(1);

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

			ApiShoppingCartItemResponseModel model = await client.ShoppingCartItemGetAsync(1);

			ApiShoppingCartItemModelMapper mapper = new ApiShoppingCartItemModelMapper();

			UpdateResponse<ApiShoppingCartItemResponseModel> updateResponse = await client.ShoppingCartItemUpdateAsync(model.ShoppingCartItemID, mapper.MapResponseToRequest(model));

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

			ApiShoppingCartItemResponseModel response = await client.ShoppingCartItemGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ShoppingCartItemDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ShoppingCartItemGetAsync(1);

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
			ApiShoppingCartItemResponseModel response = await client.ShoppingCartItemGetAsync(1);

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

			List<ApiShoppingCartItemResponseModel> response = await client.ShoppingCartItemAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiShoppingCartItemResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiShoppingCartItemRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B");
			CreateResponse<ApiShoppingCartItemResponseModel> result = await client.ShoppingCartItemCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>a447ede661b833fa60ba4a21c352ec58</Hash>
</Codenesium>*/