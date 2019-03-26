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
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "Integration")]
	public partial class SalesPersonIntegrationTests
	{
		public SalesPersonIntegrationTests()
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

			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiSalesPersonClientRequestModel();
			model.SetProperties(2m, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m, 2m, 1);
			var model2 = new ApiSalesPersonClientRequestModel();
			model2.SetProperties(3m, 3m, DateTime.Parse("1/1/1989 12:00:00 AM"), Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), 3m, 3m, 3m, 1);
			var request = new List<ApiSalesPersonClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSalesPersonClientResponseModel>> result = await client.SalesPersonBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<SalesPerson>().ToList()[1].Bonus.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[1].CommissionPct.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesPerson>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesPerson>().ToList()[1].SalesLastYear.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[1].SalesQuota.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[1].SalesYTD.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[1].TerritoryID.Should().Be(1);

			context.Set<SalesPerson>().ToList()[2].Bonus.Should().Be(3m);
			context.Set<SalesPerson>().ToList()[2].CommissionPct.Should().Be(3m);
			context.Set<SalesPerson>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<SalesPerson>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<SalesPerson>().ToList()[2].SalesLastYear.Should().Be(3m);
			context.Set<SalesPerson>().ToList()[2].SalesQuota.Should().Be(3m);
			context.Set<SalesPerson>().ToList()[2].SalesYTD.Should().Be(3m);
			context.Set<SalesPerson>().ToList()[2].TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiSalesPersonClientRequestModel();
			model.SetProperties(2m, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m, 2m, 1);
			CreateResponse<ApiSalesPersonClientResponseModel> result = await client.SalesPersonCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<SalesPerson>().ToList()[1].Bonus.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[1].CommissionPct.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesPerson>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesPerson>().ToList()[1].SalesLastYear.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[1].SalesQuota.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[1].SalesYTD.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[1].TerritoryID.Should().Be(1);

			result.Record.Bonus.Should().Be(2m);
			result.Record.CommissionPct.Should().Be(2m);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.SalesLastYear.Should().Be(2m);
			result.Record.SalesQuota.Should().Be(2m);
			result.Record.SalesYTD.Should().Be(2m);
			result.Record.TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			var mapper = new ApiSalesPersonServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ISalesPersonService service = testServer.Host.Services.GetService(typeof(ISalesPersonService)) as ISalesPersonService;
			ApiSalesPersonServerResponseModel model = await service.Get(1);

			ApiSalesPersonClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2m, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m, 2m, 1);

			UpdateResponse<ApiSalesPersonClientResponseModel> updateResponse = await client.SalesPersonUpdateAsync(model.BusinessEntityID, request);

			context.Entry(context.Set<SalesPerson>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.BusinessEntityID.Should().Be(1);
			context.Set<SalesPerson>().ToList()[0].Bonus.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[0].CommissionPct.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesPerson>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesPerson>().ToList()[0].SalesLastYear.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[0].SalesQuota.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[0].SalesYTD.Should().Be(2m);
			context.Set<SalesPerson>().ToList()[0].TerritoryID.Should().Be(1);

			updateResponse.Record.BusinessEntityID.Should().Be(1);
			updateResponse.Record.Bonus.Should().Be(2m);
			updateResponse.Record.CommissionPct.Should().Be(2m);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.SalesLastYear.Should().Be(2m);
			updateResponse.Record.SalesQuota.Should().Be(2m);
			updateResponse.Record.SalesYTD.Should().Be(2m);
			updateResponse.Record.TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ISalesPersonService service = testServer.Host.Services.GetService(typeof(ISalesPersonService)) as ISalesPersonService;
			var model = new ApiSalesPersonServerRequestModel();
			model.SetProperties(2m, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m, 2m, 1);
			CreateResponse<ApiSalesPersonServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.SalesPersonDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiSalesPersonServerResponseModel verifyResponse = await service.Get(2);

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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiSalesPersonClientResponseModel response = await client.SalesPersonGetAsync(1);

			response.Should().NotBeNull();
			response.Bonus.Should().Be(1m);
			response.BusinessEntityID.Should().Be(1);
			response.CommissionPct.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesQuota.Should().Be(1m);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiSalesPersonClientResponseModel response = await client.SalesPersonGetAsync(default(int));

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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiSalesPersonClientResponseModel> response = await client.SalesPersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Bonus.Should().Be(1m);
			response[0].BusinessEntityID.Should().Be(1);
			response[0].CommissionPct.Should().Be(1m);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].SalesLastYear.Should().Be(1m);
			response[0].SalesQuota.Should().Be(1m);
			response[0].SalesYTD.Should().Be(1m);
			response[0].TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByRowguidFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiSalesPersonClientResponseModel response = await client.BySalesPersonByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.Bonus.Should().Be(1m);
			response.BusinessEntityID.Should().Be(1);
			response.CommissionPct.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesQuota.Should().Be(1m);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiSalesPersonClientResponseModel response = await client.BySalesPersonByRowguid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestForeignKeySalesOrderHeadersBySalesPersonIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.SalesOrderHeadersBySalesPersonID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesOrderHeadersBySalesPersonIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.SalesOrderHeadersBySalesPersonID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyStoresBySalesPersonIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiStoreClientResponseModel> response = await client.StoresBySalesPersonID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyStoresBySalesPersonIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiStoreClientResponseModel> response = await client.StoresBySalesPersonID(default(int));

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
				var result = await client.SalesPersonAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>c1b4ff54cf1ff43ab1d44296a2dd9a0e</Hash>
</Codenesium>*/