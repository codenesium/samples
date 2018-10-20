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
	[Trait("Table", "SalesTerritoryHistory")]
	[Trait("Area", "Integration")]
	public class SalesTerritoryHistoryIntegrationTests
	{
		public SalesTerritoryHistoryIntegrationTests()
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

			await client.SalesTerritoryHistoryDeleteAsync(1);

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

			ApiSalesTerritoryHistoryResponseModel model = await client.SalesTerritoryHistoryGetAsync(1);

			ApiSalesTerritoryHistoryModelMapper mapper = new ApiSalesTerritoryHistoryModelMapper();

			UpdateResponse<ApiSalesTerritoryHistoryResponseModel> updateResponse = await client.SalesTerritoryHistoryUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiSalesTerritoryHistoryResponseModel response = await client.SalesTerritoryHistoryGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SalesTerritoryHistoryDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SalesTerritoryHistoryGetAsync(1);

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
			ApiSalesTerritoryHistoryResponseModel response = await client.SalesTerritoryHistoryGetAsync(1);

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

			List<ApiSalesTerritoryHistoryResponseModel> response = await client.SalesTerritoryHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesTerritoryHistoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSalesTerritoryHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"), 1);
			CreateResponse<ApiSalesTerritoryHistoryResponseModel> result = await client.SalesTerritoryHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>5e49c45eb08c4d9b97afa83135c26047</Hash>
</Codenesium>*/