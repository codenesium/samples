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
	[Trait("Table", "SalesTerritory")]
	[Trait("Area", "Integration")]
	public class SalesTerritoryIntegrationTests
	{
		public SalesTerritoryIntegrationTests()
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

			await client.SalesTerritoryDeleteAsync(1);

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

			ApiSalesTerritoryResponseModel model = await client.SalesTerritoryGetAsync(1);

			ApiSalesTerritoryModelMapper mapper = new ApiSalesTerritoryModelMapper();

			UpdateResponse<ApiSalesTerritoryResponseModel> updateResponse = await client.SalesTerritoryUpdateAsync(model.TerritoryID, mapper.MapResponseToRequest(model));

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

			ApiSalesTerritoryResponseModel response = await client.SalesTerritoryGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SalesTerritoryDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SalesTerritoryGetAsync(1);

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
			ApiSalesTerritoryResponseModel response = await client.SalesTerritoryGetAsync(1);

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

			List<ApiSalesTerritoryResponseModel> response = await client.SalesTerritoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesTerritoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSalesTerritoryRequestModel();
			model.SetProperties(2m, 2m, "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			CreateResponse<ApiSalesTerritoryResponseModel> result = await client.SalesTerritoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>9b101c5750910376ac8aa32b6ddf3610</Hash>
</Codenesium>*/