using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Sale")]
	[Trait("Area", "Integration")]
	public partial class SaleIntegrationTests
	{
		public SaleIntegrationTests()
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

			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiSaleClientRequestModel();
			model.SetProperties("B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1);
			var model2 = new ApiSaleClientRequestModel();
			model2.SetProperties("C", "C", DateTime.Parse("1/1/1989 12:00:00 AM"), 1);
			var request = new List<ApiSaleClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSaleClientResponseModel>> result = await client.SaleBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Sale>().ToList()[1].IpAddress.Should().Be("B");
			context.Set<Sale>().ToList()[1].Notes.Should().Be("B");
			context.Set<Sale>().ToList()[1].SaleDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Sale>().ToList()[1].TransactionId.Should().Be(1);

			context.Set<Sale>().ToList()[2].IpAddress.Should().Be("C");
			context.Set<Sale>().ToList()[2].Notes.Should().Be("C");
			context.Set<Sale>().ToList()[2].SaleDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Sale>().ToList()[2].TransactionId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiSaleClientRequestModel();
			model.SetProperties("B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1);
			CreateResponse<ApiSaleClientResponseModel> result = await client.SaleCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Sale>().ToList()[1].IpAddress.Should().Be("B");
			context.Set<Sale>().ToList()[1].Notes.Should().Be("B");
			context.Set<Sale>().ToList()[1].SaleDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Sale>().ToList()[1].TransactionId.Should().Be(1);

			result.Record.IpAddress.Should().Be("B");
			result.Record.Notes.Should().Be("B");
			result.Record.SaleDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.TransactionId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			var mapper = new ApiSaleServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ISaleService service = testServer.Host.Services.GetService(typeof(ISaleService)) as ISaleService;
			ApiSaleServerResponseModel model = await service.Get(1);

			ApiSaleClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1);

			UpdateResponse<ApiSaleClientResponseModel> updateResponse = await client.SaleUpdateAsync(model.Id, request);

			context.Entry(context.Set<Sale>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Sale>().ToList()[0].IpAddress.Should().Be("B");
			context.Set<Sale>().ToList()[0].Notes.Should().Be("B");
			context.Set<Sale>().ToList()[0].SaleDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Sale>().ToList()[0].TransactionId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.IpAddress.Should().Be("B");
			updateResponse.Record.Notes.Should().Be("B");
			updateResponse.Record.SaleDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.TransactionId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ISaleService service = testServer.Host.Services.GetService(typeof(ISaleService)) as ISaleService;
			var model = new ApiSaleServerRequestModel();
			model.SetProperties("B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1);
			CreateResponse<ApiSaleServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.SaleDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiSaleServerResponseModel verifyResponse = await service.Get(2);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiSaleClientResponseModel response = await client.SaleGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.IpAddress.Should().Be("A");
			response.Notes.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApiSaleClientResponseModel response = await client.SaleGetAsync(default(int));

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiSaleClientResponseModel> response = await client.SaleAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].IpAddress.Should().Be("A");
			response[0].Notes.Should().Be("A");
			response[0].SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].TransactionId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTransactionIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiSaleClientResponseModel> response = await client.BySaleByTransactionId(1);

			response.Should().NotBeEmpty();
			response[0].Id.Should().Be(1);
			response[0].IpAddress.Should().Be("A");
			response[0].Notes.Should().Be("A");
			response[0].SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].TransactionId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTransactionIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiSaleClientResponseModel> response = await client.BySaleByTransactionId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySaleTicketsBySaleIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiSaleTicketsClientResponseModel> response = await client.SaleTicketsBySaleId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySaleTicketsBySaleIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiSaleTicketsClientResponseModel> response = await client.SaleTicketsBySaleId(default(int));

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
				var result = await client.SaleAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>2f2e0d2a32a2b22f0b9b0208694b46b8</Hash>
</Codenesium>*/