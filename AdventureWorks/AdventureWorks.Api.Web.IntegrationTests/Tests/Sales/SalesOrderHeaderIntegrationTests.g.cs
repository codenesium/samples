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
	[Trait("Table", "SalesOrderHeader")]
	[Trait("Area", "Integration")]
	public partial class SalesOrderHeaderIntegrationTests
	{
		public SalesOrderHeaderIntegrationTests()
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

			var model = new ApiSalesOrderHeaderClientRequestModel();
			model.SetProperties("B", 2, "B", "B", 1, 1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2m, 2m, 1, 2m);
			var model2 = new ApiSalesOrderHeaderClientRequestModel();
			model2.SetProperties("C", 3, "C", "C", 1, 1, 1, DateTime.Parse("1/1/1989 12:00:00 AM"), 3m, DateTime.Parse("1/1/1989 12:00:00 AM"), true, DateTime.Parse("1/1/1989 12:00:00 AM"), "C", 3, Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), "C", 1, DateTime.Parse("1/1/1989 12:00:00 AM"), 3, 3, 3, 3m, 3m, 1, 3m);
			var request = new List<ApiSalesOrderHeaderClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSalesOrderHeaderClientResponseModel>> result = await client.SalesOrderHeaderBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<SalesOrderHeader>().ToList()[1].AccountNumber.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[1].BillToAddressID.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[1].Comment.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[1].CreditCardApprovalCode.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[1].CreditCardID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[1].CurrencyRateID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[1].CustomerID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[1].DueDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[1].Freight.Should().Be(2m);
			context.Set<SalesOrderHeader>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[1].OnlineOrderFlag.Should().Be(true);
			context.Set<SalesOrderHeader>().ToList()[1].OrderDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[1].PurchaseOrderNumber.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[1].RevisionNumber.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesOrderHeader>().ToList()[1].SalesOrderNumber.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[1].SalesPersonID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[1].ShipDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[1].ShipMethodID.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[1].ShipToAddressID.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[1].Status.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[1].SubTotal.Should().Be(2m);
			context.Set<SalesOrderHeader>().ToList()[1].TaxAmt.Should().Be(2m);
			context.Set<SalesOrderHeader>().ToList()[1].TerritoryID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[1].TotalDue.Should().Be(2m);

			context.Set<SalesOrderHeader>().ToList()[2].AccountNumber.Should().Be("C");
			context.Set<SalesOrderHeader>().ToList()[2].BillToAddressID.Should().Be(3);
			context.Set<SalesOrderHeader>().ToList()[2].Comment.Should().Be("C");
			context.Set<SalesOrderHeader>().ToList()[2].CreditCardApprovalCode.Should().Be("C");
			context.Set<SalesOrderHeader>().ToList()[2].CreditCardID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[2].CurrencyRateID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[2].CustomerID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[2].DueDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[2].Freight.Should().Be(3m);
			context.Set<SalesOrderHeader>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[2].OnlineOrderFlag.Should().Be(true);
			context.Set<SalesOrderHeader>().ToList()[2].OrderDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[2].PurchaseOrderNumber.Should().Be("C");
			context.Set<SalesOrderHeader>().ToList()[2].RevisionNumber.Should().Be(3);
			context.Set<SalesOrderHeader>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<SalesOrderHeader>().ToList()[2].SalesOrderNumber.Should().Be("C");
			context.Set<SalesOrderHeader>().ToList()[2].SalesPersonID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[2].ShipDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[2].ShipMethodID.Should().Be(3);
			context.Set<SalesOrderHeader>().ToList()[2].ShipToAddressID.Should().Be(3);
			context.Set<SalesOrderHeader>().ToList()[2].Status.Should().Be(3);
			context.Set<SalesOrderHeader>().ToList()[2].SubTotal.Should().Be(3m);
			context.Set<SalesOrderHeader>().ToList()[2].TaxAmt.Should().Be(3m);
			context.Set<SalesOrderHeader>().ToList()[2].TerritoryID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[2].TotalDue.Should().Be(3m);
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

			var model = new ApiSalesOrderHeaderClientRequestModel();
			model.SetProperties("B", 2, "B", "B", 1, 1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2m, 2m, 1, 2m);
			CreateResponse<ApiSalesOrderHeaderClientResponseModel> result = await client.SalesOrderHeaderCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<SalesOrderHeader>().ToList()[1].AccountNumber.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[1].BillToAddressID.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[1].Comment.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[1].CreditCardApprovalCode.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[1].CreditCardID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[1].CurrencyRateID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[1].CustomerID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[1].DueDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[1].Freight.Should().Be(2m);
			context.Set<SalesOrderHeader>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[1].OnlineOrderFlag.Should().Be(true);
			context.Set<SalesOrderHeader>().ToList()[1].OrderDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[1].PurchaseOrderNumber.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[1].RevisionNumber.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesOrderHeader>().ToList()[1].SalesOrderNumber.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[1].SalesPersonID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[1].ShipDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[1].ShipMethodID.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[1].ShipToAddressID.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[1].Status.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[1].SubTotal.Should().Be(2m);
			context.Set<SalesOrderHeader>().ToList()[1].TaxAmt.Should().Be(2m);
			context.Set<SalesOrderHeader>().ToList()[1].TerritoryID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[1].TotalDue.Should().Be(2m);

			result.Record.AccountNumber.Should().Be("B");
			result.Record.BillToAddressID.Should().Be(2);
			result.Record.Comment.Should().Be("B");
			result.Record.CreditCardApprovalCode.Should().Be("B");
			result.Record.CreditCardID.Should().Be(1);
			result.Record.CurrencyRateID.Should().Be(1);
			result.Record.CustomerID.Should().Be(1);
			result.Record.DueDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Freight.Should().Be(2m);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.OnlineOrderFlag.Should().Be(true);
			result.Record.OrderDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.PurchaseOrderNumber.Should().Be("B");
			result.Record.RevisionNumber.Should().Be(2);
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.SalesOrderNumber.Should().Be("B");
			result.Record.SalesPersonID.Should().Be(1);
			result.Record.ShipDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ShipMethodID.Should().Be(2);
			result.Record.ShipToAddressID.Should().Be(2);
			result.Record.Status.Should().Be(2);
			result.Record.SubTotal.Should().Be(2m);
			result.Record.TaxAmt.Should().Be(2m);
			result.Record.TerritoryID.Should().Be(1);
			result.Record.TotalDue.Should().Be(2m);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiSalesOrderHeaderServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ISalesOrderHeaderService service = testServer.Host.Services.GetService(typeof(ISalesOrderHeaderService)) as ISalesOrderHeaderService;
			ApiSalesOrderHeaderServerResponseModel model = await service.Get(1);

			ApiSalesOrderHeaderClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", 2, "B", "B", 1, 1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2m, 2m, 1, 2m);

			UpdateResponse<ApiSalesOrderHeaderClientResponseModel> updateResponse = await client.SalesOrderHeaderUpdateAsync(model.SalesOrderID, request);

			context.Entry(context.Set<SalesOrderHeader>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.SalesOrderID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[0].AccountNumber.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[0].BillToAddressID.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[0].Comment.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[0].CreditCardApprovalCode.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[0].CreditCardID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[0].CurrencyRateID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[0].CustomerID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[0].DueDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[0].Freight.Should().Be(2m);
			context.Set<SalesOrderHeader>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[0].OnlineOrderFlag.Should().Be(true);
			context.Set<SalesOrderHeader>().ToList()[0].OrderDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[0].PurchaseOrderNumber.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[0].RevisionNumber.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<SalesOrderHeader>().ToList()[0].SalesOrderNumber.Should().Be("B");
			context.Set<SalesOrderHeader>().ToList()[0].SalesPersonID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[0].ShipDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<SalesOrderHeader>().ToList()[0].ShipMethodID.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[0].ShipToAddressID.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[0].Status.Should().Be(2);
			context.Set<SalesOrderHeader>().ToList()[0].SubTotal.Should().Be(2m);
			context.Set<SalesOrderHeader>().ToList()[0].TaxAmt.Should().Be(2m);
			context.Set<SalesOrderHeader>().ToList()[0].TerritoryID.Should().Be(1);
			context.Set<SalesOrderHeader>().ToList()[0].TotalDue.Should().Be(2m);

			updateResponse.Record.SalesOrderID.Should().Be(1);
			updateResponse.Record.AccountNumber.Should().Be("B");
			updateResponse.Record.BillToAddressID.Should().Be(2);
			updateResponse.Record.Comment.Should().Be("B");
			updateResponse.Record.CreditCardApprovalCode.Should().Be("B");
			updateResponse.Record.CreditCardID.Should().Be(1);
			updateResponse.Record.CurrencyRateID.Should().Be(1);
			updateResponse.Record.CustomerID.Should().Be(1);
			updateResponse.Record.DueDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Freight.Should().Be(2m);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.OnlineOrderFlag.Should().Be(true);
			updateResponse.Record.OrderDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.PurchaseOrderNumber.Should().Be("B");
			updateResponse.Record.RevisionNumber.Should().Be(2);
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.SalesOrderNumber.Should().Be("B");
			updateResponse.Record.SalesPersonID.Should().Be(1);
			updateResponse.Record.ShipDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ShipMethodID.Should().Be(2);
			updateResponse.Record.ShipToAddressID.Should().Be(2);
			updateResponse.Record.Status.Should().Be(2);
			updateResponse.Record.SubTotal.Should().Be(2m);
			updateResponse.Record.TaxAmt.Should().Be(2m);
			updateResponse.Record.TerritoryID.Should().Be(1);
			updateResponse.Record.TotalDue.Should().Be(2m);
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

			ISalesOrderHeaderService service = testServer.Host.Services.GetService(typeof(ISalesOrderHeaderService)) as ISalesOrderHeaderService;
			var model = new ApiSalesOrderHeaderServerRequestModel();
			model.SetProperties("B", 2, "B", "B", 1, 1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2m, 2m, 1, 2m);
			CreateResponse<ApiSalesOrderHeaderServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.SalesOrderHeaderDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiSalesOrderHeaderServerResponseModel verifyResponse = await service.Get(2);

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

			ApiSalesOrderHeaderClientResponseModel response = await client.SalesOrderHeaderGetAsync(1);

			response.Should().NotBeNull();
			response.AccountNumber.Should().Be("A");
			response.BillToAddressID.Should().Be(1);
			response.Comment.Should().Be("A");
			response.CreditCardApprovalCode.Should().Be("A");
			response.CreditCardID.Should().Be(1);
			response.CurrencyRateID.Should().Be(1);
			response.CustomerID.Should().Be(1);
			response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Freight.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OnlineOrderFlag.Should().Be(true);
			response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PurchaseOrderNumber.Should().Be("A");
			response.RevisionNumber.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesOrderID.Should().Be(1);
			response.SalesOrderNumber.Should().Be("A");
			response.SalesPersonID.Should().Be(1);
			response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ShipMethodID.Should().Be(1);
			response.ShipToAddressID.Should().Be(1);
			response.Status.Should().Be(1);
			response.SubTotal.Should().Be(1m);
			response.TaxAmt.Should().Be(1m);
			response.TerritoryID.Should().Be(1);
			response.TotalDue.Should().Be(1m);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesOrderHeaderClientResponseModel response = await client.SalesOrderHeaderGetAsync(default(int));

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

			List<ApiSalesOrderHeaderClientResponseModel> response = await client.SalesOrderHeaderAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AccountNumber.Should().Be("A");
			response[0].BillToAddressID.Should().Be(1);
			response[0].Comment.Should().Be("A");
			response[0].CreditCardApprovalCode.Should().Be("A");
			response[0].CreditCardID.Should().Be(1);
			response[0].CurrencyRateID.Should().Be(1);
			response[0].CustomerID.Should().Be(1);
			response[0].DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Freight.Should().Be(1m);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].OnlineOrderFlag.Should().Be(true);
			response[0].OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PurchaseOrderNumber.Should().Be("A");
			response[0].RevisionNumber.Should().Be(1);
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].SalesOrderID.Should().Be(1);
			response[0].SalesOrderNumber.Should().Be("A");
			response[0].SalesPersonID.Should().Be(1);
			response[0].ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ShipMethodID.Should().Be(1);
			response[0].ShipToAddressID.Should().Be(1);
			response[0].Status.Should().Be(1);
			response[0].SubTotal.Should().Be(1m);
			response[0].TaxAmt.Should().Be(1m);
			response[0].TerritoryID.Should().Be(1);
			response[0].TotalDue.Should().Be(1m);
		}

		[Fact]
		public virtual async void TestByRowguidFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesOrderHeaderClientResponseModel response = await client.BySalesOrderHeaderByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.AccountNumber.Should().Be("A");
			response.BillToAddressID.Should().Be(1);
			response.Comment.Should().Be("A");
			response.CreditCardApprovalCode.Should().Be("A");
			response.CreditCardID.Should().Be(1);
			response.CurrencyRateID.Should().Be(1);
			response.CustomerID.Should().Be(1);
			response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Freight.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OnlineOrderFlag.Should().Be(true);
			response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PurchaseOrderNumber.Should().Be("A");
			response.RevisionNumber.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesOrderID.Should().Be(1);
			response.SalesOrderNumber.Should().Be("A");
			response.SalesPersonID.Should().Be(1);
			response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ShipMethodID.Should().Be(1);
			response.ShipToAddressID.Should().Be(1);
			response.Status.Should().Be(1);
			response.SubTotal.Should().Be(1m);
			response.TaxAmt.Should().Be(1m);
			response.TerritoryID.Should().Be(1);
			response.TotalDue.Should().Be(1m);
		}

		[Fact]
		public virtual async void TestByRowguidNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesOrderHeaderClientResponseModel response = await client.BySalesOrderHeaderByRowguid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestBySalesOrderNumberFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesOrderHeaderClientResponseModel response = await client.BySalesOrderHeaderBySalesOrderNumber("A");

			response.Should().NotBeNull();

			response.AccountNumber.Should().Be("A");
			response.BillToAddressID.Should().Be(1);
			response.Comment.Should().Be("A");
			response.CreditCardApprovalCode.Should().Be("A");
			response.CreditCardID.Should().Be(1);
			response.CurrencyRateID.Should().Be(1);
			response.CustomerID.Should().Be(1);
			response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Freight.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OnlineOrderFlag.Should().Be(true);
			response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PurchaseOrderNumber.Should().Be("A");
			response.RevisionNumber.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesOrderID.Should().Be(1);
			response.SalesOrderNumber.Should().Be("A");
			response.SalesPersonID.Should().Be(1);
			response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ShipMethodID.Should().Be(1);
			response.ShipToAddressID.Should().Be(1);
			response.Status.Should().Be(1);
			response.SubTotal.Should().Be(1m);
			response.TaxAmt.Should().Be(1m);
			response.TerritoryID.Should().Be(1);
			response.TotalDue.Should().Be(1m);
		}

		[Fact]
		public virtual async void TestBySalesOrderNumberNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSalesOrderHeaderClientResponseModel response = await client.BySalesOrderHeaderBySalesOrderNumber("test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByCustomerIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.BySalesOrderHeaderByCustomerID(1);

			response.Should().NotBeEmpty();
			response[0].AccountNumber.Should().Be("A");
			response[0].BillToAddressID.Should().Be(1);
			response[0].Comment.Should().Be("A");
			response[0].CreditCardApprovalCode.Should().Be("A");
			response[0].CreditCardID.Should().Be(1);
			response[0].CurrencyRateID.Should().Be(1);
			response[0].CustomerID.Should().Be(1);
			response[0].DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Freight.Should().Be(1m);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].OnlineOrderFlag.Should().Be(true);
			response[0].OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PurchaseOrderNumber.Should().Be("A");
			response[0].RevisionNumber.Should().Be(1);
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].SalesOrderID.Should().Be(1);
			response[0].SalesOrderNumber.Should().Be("A");
			response[0].SalesPersonID.Should().Be(1);
			response[0].ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ShipMethodID.Should().Be(1);
			response[0].ShipToAddressID.Should().Be(1);
			response[0].Status.Should().Be(1);
			response[0].SubTotal.Should().Be(1m);
			response[0].TaxAmt.Should().Be(1m);
			response[0].TerritoryID.Should().Be(1);
			response[0].TotalDue.Should().Be(1m);
		}

		[Fact]
		public virtual async void TestByCustomerIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.BySalesOrderHeaderByCustomerID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestBySalesPersonIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.BySalesOrderHeaderBySalesPersonID(1);

			response.Should().NotBeEmpty();
			response[0].AccountNumber.Should().Be("A");
			response[0].BillToAddressID.Should().Be(1);
			response[0].Comment.Should().Be("A");
			response[0].CreditCardApprovalCode.Should().Be("A");
			response[0].CreditCardID.Should().Be(1);
			response[0].CurrencyRateID.Should().Be(1);
			response[0].CustomerID.Should().Be(1);
			response[0].DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Freight.Should().Be(1m);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].OnlineOrderFlag.Should().Be(true);
			response[0].OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PurchaseOrderNumber.Should().Be("A");
			response[0].RevisionNumber.Should().Be(1);
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].SalesOrderID.Should().Be(1);
			response[0].SalesOrderNumber.Should().Be("A");
			response[0].SalesPersonID.Should().Be(1);
			response[0].ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ShipMethodID.Should().Be(1);
			response[0].ShipToAddressID.Should().Be(1);
			response[0].Status.Should().Be(1);
			response[0].SubTotal.Should().Be(1m);
			response[0].TaxAmt.Should().Be(1m);
			response[0].TerritoryID.Should().Be(1);
			response[0].TotalDue.Should().Be(1m);
		}

		[Fact]
		public virtual async void TestBySalesPersonIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.BySalesOrderHeaderBySalesPersonID(default(int));

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
				var result = await client.SalesOrderHeaderAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>77124fc20ccf57bcf1dcd21af8c5091b</Hash>
</Codenesium>*/