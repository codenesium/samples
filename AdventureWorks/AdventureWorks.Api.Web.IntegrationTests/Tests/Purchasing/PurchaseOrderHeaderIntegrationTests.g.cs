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
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "Integration")]
	public partial class PurchaseOrderHeaderIntegrationTests
	{
		public PurchaseOrderHeaderIntegrationTests()
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

			var model = new ApiPurchaseOrderHeaderClientRequestModel();
			model.SetProperties(2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2m, 2m, 2m, 1);
			var model2 = new ApiPurchaseOrderHeaderClientRequestModel();
			model2.SetProperties(3, 3m, DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), 3, DateTime.Parse("1/1/1989 12:00:00 AM"), 1, 3, 3m, 3m, 3m, 1);
			var request = new List<ApiPurchaseOrderHeaderClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPurchaseOrderHeaderClientResponseModel>> result = await client.PurchaseOrderHeaderBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<PurchaseOrderHeader>().ToList()[1].EmployeeID.Should().Be(2);
			context.Set<PurchaseOrderHeader>().ToList()[1].Freight.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[1].OrderDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[1].RevisionNumber.Should().Be(2);
			context.Set<PurchaseOrderHeader>().ToList()[1].ShipDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[1].ShipMethodID.Should().Be(1);
			context.Set<PurchaseOrderHeader>().ToList()[1].Status.Should().Be(2);
			context.Set<PurchaseOrderHeader>().ToList()[1].SubTotal.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[1].TaxAmt.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[1].TotalDue.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[1].VendorID.Should().Be(1);

			context.Set<PurchaseOrderHeader>().ToList()[2].EmployeeID.Should().Be(3);
			context.Set<PurchaseOrderHeader>().ToList()[2].Freight.Should().Be(3m);
			context.Set<PurchaseOrderHeader>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[2].OrderDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[2].RevisionNumber.Should().Be(3);
			context.Set<PurchaseOrderHeader>().ToList()[2].ShipDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[2].ShipMethodID.Should().Be(1);
			context.Set<PurchaseOrderHeader>().ToList()[2].Status.Should().Be(3);
			context.Set<PurchaseOrderHeader>().ToList()[2].SubTotal.Should().Be(3m);
			context.Set<PurchaseOrderHeader>().ToList()[2].TaxAmt.Should().Be(3m);
			context.Set<PurchaseOrderHeader>().ToList()[2].TotalDue.Should().Be(3m);
			context.Set<PurchaseOrderHeader>().ToList()[2].VendorID.Should().Be(1);
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

			var model = new ApiPurchaseOrderHeaderClientRequestModel();
			model.SetProperties(2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2m, 2m, 2m, 1);
			CreateResponse<ApiPurchaseOrderHeaderClientResponseModel> result = await client.PurchaseOrderHeaderCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<PurchaseOrderHeader>().ToList()[1].EmployeeID.Should().Be(2);
			context.Set<PurchaseOrderHeader>().ToList()[1].Freight.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[1].OrderDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[1].RevisionNumber.Should().Be(2);
			context.Set<PurchaseOrderHeader>().ToList()[1].ShipDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[1].ShipMethodID.Should().Be(1);
			context.Set<PurchaseOrderHeader>().ToList()[1].Status.Should().Be(2);
			context.Set<PurchaseOrderHeader>().ToList()[1].SubTotal.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[1].TaxAmt.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[1].TotalDue.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[1].VendorID.Should().Be(1);

			result.Record.EmployeeID.Should().Be(2);
			result.Record.Freight.Should().Be(2m);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.OrderDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.RevisionNumber.Should().Be(2);
			result.Record.ShipDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ShipMethodID.Should().Be(1);
			result.Record.Status.Should().Be(2);
			result.Record.SubTotal.Should().Be(2m);
			result.Record.TaxAmt.Should().Be(2m);
			result.Record.TotalDue.Should().Be(2m);
			result.Record.VendorID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiPurchaseOrderHeaderServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPurchaseOrderHeaderService service = testServer.Host.Services.GetService(typeof(IPurchaseOrderHeaderService)) as IPurchaseOrderHeaderService;
			ApiPurchaseOrderHeaderServerResponseModel model = await service.Get(1);

			ApiPurchaseOrderHeaderClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2m, 2m, 2m, 1);

			UpdateResponse<ApiPurchaseOrderHeaderClientResponseModel> updateResponse = await client.PurchaseOrderHeaderUpdateAsync(model.PurchaseOrderID, request);

			context.Entry(context.Set<PurchaseOrderHeader>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.PurchaseOrderID.Should().Be(1);
			context.Set<PurchaseOrderHeader>().ToList()[0].EmployeeID.Should().Be(2);
			context.Set<PurchaseOrderHeader>().ToList()[0].Freight.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[0].OrderDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[0].RevisionNumber.Should().Be(2);
			context.Set<PurchaseOrderHeader>().ToList()[0].ShipDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PurchaseOrderHeader>().ToList()[0].ShipMethodID.Should().Be(1);
			context.Set<PurchaseOrderHeader>().ToList()[0].Status.Should().Be(2);
			context.Set<PurchaseOrderHeader>().ToList()[0].SubTotal.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[0].TaxAmt.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[0].TotalDue.Should().Be(2m);
			context.Set<PurchaseOrderHeader>().ToList()[0].VendorID.Should().Be(1);

			updateResponse.Record.PurchaseOrderID.Should().Be(1);
			updateResponse.Record.EmployeeID.Should().Be(2);
			updateResponse.Record.Freight.Should().Be(2m);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.OrderDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.RevisionNumber.Should().Be(2);
			updateResponse.Record.ShipDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ShipMethodID.Should().Be(1);
			updateResponse.Record.Status.Should().Be(2);
			updateResponse.Record.SubTotal.Should().Be(2m);
			updateResponse.Record.TaxAmt.Should().Be(2m);
			updateResponse.Record.TotalDue.Should().Be(2m);
			updateResponse.Record.VendorID.Should().Be(1);
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

			IPurchaseOrderHeaderService service = testServer.Host.Services.GetService(typeof(IPurchaseOrderHeaderService)) as IPurchaseOrderHeaderService;
			var model = new ApiPurchaseOrderHeaderServerRequestModel();
			model.SetProperties(2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2m, 2m, 2m, 1);
			CreateResponse<ApiPurchaseOrderHeaderServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PurchaseOrderHeaderDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPurchaseOrderHeaderServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPurchaseOrderHeaderClientResponseModel response = await client.PurchaseOrderHeaderGetAsync(1);

			response.Should().NotBeNull();
			response.EmployeeID.Should().Be(1);
			response.Freight.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PurchaseOrderID.Should().Be(1);
			response.RevisionNumber.Should().Be(1);
			response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ShipMethodID.Should().Be(1);
			response.Status.Should().Be(1);
			response.SubTotal.Should().Be(1m);
			response.TaxAmt.Should().Be(1m);
			response.TotalDue.Should().Be(1m);
			response.VendorID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiPurchaseOrderHeaderClientResponseModel response = await client.PurchaseOrderHeaderGetAsync(default(int));

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

			List<ApiPurchaseOrderHeaderClientResponseModel> response = await client.PurchaseOrderHeaderAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].EmployeeID.Should().Be(1);
			response[0].Freight.Should().Be(1m);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PurchaseOrderID.Should().Be(1);
			response[0].RevisionNumber.Should().Be(1);
			response[0].ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ShipMethodID.Should().Be(1);
			response[0].Status.Should().Be(1);
			response[0].SubTotal.Should().Be(1m);
			response[0].TaxAmt.Should().Be(1m);
			response[0].TotalDue.Should().Be(1m);
			response[0].VendorID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByEmployeeIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPurchaseOrderHeaderClientResponseModel> response = await client.ByPurchaseOrderHeaderByEmployeeID(1);

			response.Should().NotBeEmpty();
			response[0].EmployeeID.Should().Be(1);
			response[0].Freight.Should().Be(1m);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PurchaseOrderID.Should().Be(1);
			response[0].RevisionNumber.Should().Be(1);
			response[0].ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ShipMethodID.Should().Be(1);
			response[0].Status.Should().Be(1);
			response[0].SubTotal.Should().Be(1m);
			response[0].TaxAmt.Should().Be(1m);
			response[0].TotalDue.Should().Be(1m);
			response[0].VendorID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByEmployeeIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPurchaseOrderHeaderClientResponseModel> response = await client.ByPurchaseOrderHeaderByEmployeeID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByVendorIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPurchaseOrderHeaderClientResponseModel> response = await client.ByPurchaseOrderHeaderByVendorID(1);

			response.Should().NotBeEmpty();
			response[0].EmployeeID.Should().Be(1);
			response[0].Freight.Should().Be(1m);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PurchaseOrderID.Should().Be(1);
			response[0].RevisionNumber.Should().Be(1);
			response[0].ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ShipMethodID.Should().Be(1);
			response[0].Status.Should().Be(1);
			response[0].SubTotal.Should().Be(1m);
			response[0].TaxAmt.Should().Be(1m);
			response[0].TotalDue.Should().Be(1m);
			response[0].VendorID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByVendorIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPurchaseOrderHeaderClientResponseModel> response = await client.ByPurchaseOrderHeaderByVendorID(default(int));

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
				var result = await client.PurchaseOrderHeaderAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>d14912e561ed4e09c2edb96ff6139dba</Hash>
</Codenesium>*/