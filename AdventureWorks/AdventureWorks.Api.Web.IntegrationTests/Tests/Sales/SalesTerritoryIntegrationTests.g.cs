using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "SalesTerritory")]
	[Trait("Area", "Integration")]
	public partial class SalesTerritoryIntegrationTests
	{
		public SalesTerritoryIntegrationTests()
		{
		}

		[Fact]
		public virtual async void TestBulkInsert()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiSalesTerritoryClientRequestModel();
			model.SetProperties(2m, 2m, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			var model2 = new ApiSalesTerritoryClientRequestModel();
			model2.SetProperties(3m, 3m, "C", DateTime.Parse("1/1/1989 12:00:00 AM"), "C", Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), 3m, 3m);
			var request = new List<ApiSalesTerritoryClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSalesTerritoryClientResponseModel>> result = await client.SalesTerritoryBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<SalesTerritory>().ToList()[1].CostLastYear.Should().Be(2m);
			context.Set<SalesTerritory>().ToList()[1].CostYTD.Should().Be(2m);
			context.Set<SalesTerritory>().ToList()[1].CountryRegionCode.Should().Be("B");
			context.Set<SalesTerritory>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesTerritory>().ToList()[1].Name.Should().Be("B");
			context.Set<SalesTerritory>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesTerritory>().ToList()[1].SalesLastYear.Should().Be(2m);
			context.Set<SalesTerritory>().ToList()[1].SalesYTD.Should().Be(2m);

			context.Set<SalesTerritory>().ToList()[2].CostLastYear.Should().Be(3m);
			context.Set<SalesTerritory>().ToList()[2].CostYTD.Should().Be(3m);
			context.Set<SalesTerritory>().ToList()[2].CountryRegionCode.Should().Be("C");
			context.Set<SalesTerritory>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<SalesTerritory>().ToList()[2].Name.Should().Be("C");
			context.Set<SalesTerritory>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<SalesTerritory>().ToList()[2].SalesLastYear.Should().Be(3m);
			context.Set<SalesTerritory>().ToList()[2].SalesYTD.Should().Be(3m);
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiSalesTerritoryClientRequestModel();
			model.SetProperties(2m, 2m, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			CreateResponse<ApiSalesTerritoryClientResponseModel> result = await client.SalesTerritoryCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<SalesTerritory>().ToList()[1].CostLastYear.Should().Be(2m);
			context.Set<SalesTerritory>().ToList()[1].CostYTD.Should().Be(2m);
			context.Set<SalesTerritory>().ToList()[1].CountryRegionCode.Should().Be("B");
			context.Set<SalesTerritory>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesTerritory>().ToList()[1].Name.Should().Be("B");
			context.Set<SalesTerritory>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesTerritory>().ToList()[1].SalesLastYear.Should().Be(2m);
			context.Set<SalesTerritory>().ToList()[1].SalesYTD.Should().Be(2m);

			result.Record.CostLastYear.Should().Be(2m);
			result.Record.CostYTD.Should().Be(2m);
			result.Record.CountryRegionCode.Should().Be("B");
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Name.Should().Be("B");
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.SalesLastYear.Should().Be(2m);
			result.Record.SalesYTD.Should().Be(2m);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiSalesTerritoryServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ISalesTerritoryService service = testServer.Host.Services.GetService(typeof(ISalesTerritoryService)) as ISalesTerritoryService;
			ApiSalesTerritoryServerResponseModel model = await service.Get(1);

			ApiSalesTerritoryClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2m, 2m, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);

			UpdateResponse<ApiSalesTerritoryClientResponseModel> updateResponse = await client.SalesTerritoryUpdateAsync(model.TerritoryID, request);

			context.Entry(context.Set<SalesTerritory>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.TerritoryID.Should().Be(1);
			context.Set<SalesTerritory>().ToList()[0].CostLastYear.Should().Be(2m);
			context.Set<SalesTerritory>().ToList()[0].CostYTD.Should().Be(2m);
			context.Set<SalesTerritory>().ToList()[0].CountryRegionCode.Should().Be("B");
			context.Set<SalesTerritory>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesTerritory>().ToList()[0].Name.Should().Be("B");
			context.Set<SalesTerritory>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesTerritory>().ToList()[0].SalesLastYear.Should().Be(2m);
			context.Set<SalesTerritory>().ToList()[0].SalesYTD.Should().Be(2m);

			updateResponse.Record.TerritoryID.Should().Be(1);
			updateResponse.Record.CostLastYear.Should().Be(2m);
			updateResponse.Record.CostYTD.Should().Be(2m);
			updateResponse.Record.CountryRegionCode.Should().Be("B");
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.SalesLastYear.Should().Be(2m);
			updateResponse.Record.SalesYTD.Should().Be(2m);
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ISalesTerritoryService service = testServer.Host.Services.GetService(typeof(ISalesTerritoryService)) as ISalesTerritoryService;
			var model = new ApiSalesTerritoryServerRequestModel();
			model.SetProperties(2m, 2m, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			CreateResponse<ApiSalesTerritoryServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.SalesTerritoryDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiSalesTerritoryServerResponseModel verifyResponse = await service.Get(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public virtual async void TestGetFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiSalesTerritoryClientResponseModel response = await client.SalesTerritoryGetAsync(1);

			response.Should().NotBeNull();
			response.CostLastYear.Should().Be(1m);
			response.CostYTD.Should().Be(1m);
			response.CountryRegionCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesYTD.Should().Be(1m);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesTerritoryClientResponseModel response = await client.SalesTerritoryGetAsync(default(int));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			List<ApiSalesTerritoryClientResponseModel> response = await client.SalesTerritoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CostLastYear.Should().Be(1m);
			response[0].CostYTD.Should().Be(1m);
			response[0].CountryRegionCode.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Name.Should().Be("A");
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].SalesLastYear.Should().Be(1m);
			response[0].SalesYTD.Should().Be(1m);
			response[0].TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByNameFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesTerritoryClientResponseModel response = await client.BySalesTerritoryByName("A");

			response.Should().NotBeNull();

			response.CostLastYear.Should().Be(1m);
			response.CostYTD.Should().Be(1m);
			response.CountryRegionCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesYTD.Should().Be(1m);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByNameNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesTerritoryClientResponseModel response = await client.BySalesTerritoryByName("test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByRowguidFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesTerritoryClientResponseModel response = await client.BySalesTerritoryByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.CostLastYear.Should().Be(1m);
			response.CostYTD.Should().Be(1m);
			response.CountryRegionCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesYTD.Should().Be(1m);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByRowguidNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesTerritoryClientResponseModel response = await client.BySalesTerritoryByRowguid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestForeignKeyCustomersByTerritoryIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiCustomerClientResponseModel> response = await client.CustomersByTerritoryID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyCustomersByTerritoryIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiCustomerClientResponseModel> response = await client.CustomersByTerritoryID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesOrderHeadersByTerritoryIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.SalesOrderHeadersByTerritoryID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesOrderHeadersByTerritoryIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.SalesOrderHeadersByTerritoryID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesPersonsByTerritoryIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesPersonClientResponseModel> response = await client.SalesPersonsByTerritoryID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesPersonsByTerritoryIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesPersonClientResponseModel> response = await client.SalesPersonsByTerritoryID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual void TestClientCancellationToken()
		{
			Func<Task> testCancellation = async () =>
			{
				var builder = new WebHostBuilder()
				              .UseEnvironment("Production")
				              .UseStartup<TestStartup>();
				TestServer testServer = new TestServer(builder);

				var client = new ApiClient(testServer.BaseAddress.OriginalString);
				CancellationTokenSource tokenSource = new CancellationTokenSource();
				CancellationToken token = tokenSource.Token;
				tokenSource.Cancel();
				var result = await client.SalesTerritoryAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>a279481eeffe51abc1429d6cbbbe1bd4</Hash>
</Codenesium>*/