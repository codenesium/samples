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
	[Trait("Table", "Customer")]
	[Trait("Area", "Integration")]
	public partial class CustomerIntegrationTests
	{
		public CustomerIntegrationTests()
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

			var model = new ApiCustomerClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, 1);
			var model2 = new ApiCustomerClientRequestModel();
			model2.SetProperties("C", DateTime.Parse("1/1/1989 12:00:00 AM"), 3, Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"), 1, 1);
			var request = new List<ApiCustomerClientRequestModel>() {model, model2};
			CreateResponse<List<ApiCustomerClientResponseModel>> result = await client.CustomerBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Customer>().ToList()[1].AccountNumber.Should().Be("B");
			context.Set<Customer>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Customer>().ToList()[1].PersonID.Should().Be(2);
			context.Set<Customer>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Customer>().ToList()[1].StoreID.Should().Be(1);
			context.Set<Customer>().ToList()[1].TerritoryID.Should().Be(1);

			context.Set<Customer>().ToList()[2].AccountNumber.Should().Be("C");
			context.Set<Customer>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Customer>().ToList()[2].PersonID.Should().Be(3);
			context.Set<Customer>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			context.Set<Customer>().ToList()[2].StoreID.Should().Be(1);
			context.Set<Customer>().ToList()[2].TerritoryID.Should().Be(1);
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

			var model = new ApiCustomerClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, 1);
			CreateResponse<ApiCustomerClientResponseModel> result = await client.CustomerCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Customer>().ToList()[1].AccountNumber.Should().Be("B");
			context.Set<Customer>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Customer>().ToList()[1].PersonID.Should().Be(2);
			context.Set<Customer>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Customer>().ToList()[1].StoreID.Should().Be(1);
			context.Set<Customer>().ToList()[1].TerritoryID.Should().Be(1);

			result.Record.AccountNumber.Should().Be("B");
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.PersonID.Should().Be(2);
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			result.Record.StoreID.Should().Be(1);
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
			var mapper = new ApiCustomerServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ICustomerService service = testServer.Host.Services.GetService(typeof(ICustomerService)) as ICustomerService;
			ApiCustomerServerResponseModel model = await service.Get(1);

			ApiCustomerClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, 1);

			UpdateResponse<ApiCustomerClientResponseModel> updateResponse = await client.CustomerUpdateAsync(model.CustomerID, request);

			context.Entry(context.Set<Customer>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.CustomerID.Should().Be(1);
			context.Set<Customer>().ToList()[0].AccountNumber.Should().Be("B");
			context.Set<Customer>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Customer>().ToList()[0].PersonID.Should().Be(2);
			context.Set<Customer>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			context.Set<Customer>().ToList()[0].StoreID.Should().Be(1);
			context.Set<Customer>().ToList()[0].TerritoryID.Should().Be(1);

			updateResponse.Record.CustomerID.Should().Be(1);
			updateResponse.Record.AccountNumber.Should().Be("B");
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.PersonID.Should().Be(2);
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			updateResponse.Record.StoreID.Should().Be(1);
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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ICustomerService service = testServer.Host.Services.GetService(typeof(ICustomerService)) as ICustomerService;
			var model = new ApiCustomerServerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1, 1);
			CreateResponse<ApiCustomerServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.CustomerDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiCustomerServerResponseModel verifyResponse = await service.Get(2);

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

			ApiCustomerClientResponseModel response = await client.CustomerGetAsync(1);

			response.Should().NotBeNull();
			response.AccountNumber.Should().Be("A");
			response.CustomerID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PersonID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StoreID.Should().Be(1);
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
			ApiCustomerClientResponseModel response = await client.CustomerGetAsync(default(int));

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

			List<ApiCustomerClientResponseModel> response = await client.CustomerAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AccountNumber.Should().Be("A");
			response[0].CustomerID.Should().Be(1);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PersonID.Should().Be(1);
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].StoreID.Should().Be(1);
			response[0].TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByAccountNumberFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCustomerClientResponseModel response = await client.ByCustomerByAccountNumber("A");

			response.Should().NotBeNull();

			response.AccountNumber.Should().Be("A");
			response.CustomerID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PersonID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StoreID.Should().Be(1);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByAccountNumberNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCustomerClientResponseModel response = await client.ByCustomerByAccountNumber("test_value");

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
			ApiCustomerClientResponseModel response = await client.ByCustomerByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.AccountNumber.Should().Be("A");
			response.CustomerID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PersonID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StoreID.Should().Be(1);
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
			ApiCustomerClientResponseModel response = await client.ByCustomerByRowguid(default(Guid));

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestByTerritoryIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiCustomerClientResponseModel> response = await client.ByCustomerByTerritoryID(1);

			response.Should().NotBeEmpty();
			response[0].AccountNumber.Should().Be("A");
			response[0].CustomerID.Should().Be(1);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].PersonID.Should().Be(1);
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response[0].StoreID.Should().Be(1);
			response[0].TerritoryID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTerritoryIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiCustomerClientResponseModel> response = await client.ByCustomerByTerritoryID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesOrderHeadersByCustomerIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.SalesOrderHeadersByCustomerID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesOrderHeadersByCustomerIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.SalesOrderHeadersByCustomerID(default(int));

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
				var result = await client.CustomerAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>d7bb625b6f0c8ded006b1f834f127892</Hash>
</Codenesium>*/