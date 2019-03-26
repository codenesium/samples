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
	[Trait("Table", "Transaction")]
	[Trait("Area", "Integration")]
	public partial class TransactionIntegrationTests
	{
		public TransactionIntegrationTests()
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

			var model = new ApiTransactionClientRequestModel();
			model.SetProperties(2m, "B", 1);
			var model2 = new ApiTransactionClientRequestModel();
			model2.SetProperties(3m, "C", 1);
			var request = new List<ApiTransactionClientRequestModel>() {model, model2};
			CreateResponse<List<ApiTransactionClientResponseModel>> result = await client.TransactionBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Transaction>().ToList()[1].Amount.Should().Be(2m);
			context.Set<Transaction>().ToList()[1].GatewayConfirmationNumber.Should().Be("B");
			context.Set<Transaction>().ToList()[1].TransactionStatusId.Should().Be(1);

			context.Set<Transaction>().ToList()[2].Amount.Should().Be(3m);
			context.Set<Transaction>().ToList()[2].GatewayConfirmationNumber.Should().Be("C");
			context.Set<Transaction>().ToList()[2].TransactionStatusId.Should().Be(1);
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

			var model = new ApiTransactionClientRequestModel();
			model.SetProperties(2m, "B", 1);
			CreateResponse<ApiTransactionClientResponseModel> result = await client.TransactionCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Transaction>().ToList()[1].Amount.Should().Be(2m);
			context.Set<Transaction>().ToList()[1].GatewayConfirmationNumber.Should().Be("B");
			context.Set<Transaction>().ToList()[1].TransactionStatusId.Should().Be(1);

			result.Record.Amount.Should().Be(2m);
			result.Record.GatewayConfirmationNumber.Should().Be("B");
			result.Record.TransactionStatusId.Should().Be(1);
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
			var mapper = new ApiTransactionServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ITransactionService service = testServer.Host.Services.GetService(typeof(ITransactionService)) as ITransactionService;
			ApiTransactionServerResponseModel model = await service.Get(1);

			ApiTransactionClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2m, "B", 1);

			UpdateResponse<ApiTransactionClientResponseModel> updateResponse = await client.TransactionUpdateAsync(model.Id, request);

			context.Entry(context.Set<Transaction>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Transaction>().ToList()[0].Amount.Should().Be(2m);
			context.Set<Transaction>().ToList()[0].GatewayConfirmationNumber.Should().Be("B");
			context.Set<Transaction>().ToList()[0].TransactionStatusId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Amount.Should().Be(2m);
			updateResponse.Record.GatewayConfirmationNumber.Should().Be("B");
			updateResponse.Record.TransactionStatusId.Should().Be(1);
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

			ITransactionService service = testServer.Host.Services.GetService(typeof(ITransactionService)) as ITransactionService;
			var model = new ApiTransactionServerRequestModel();
			model.SetProperties(2m, "B", 1);
			CreateResponse<ApiTransactionServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.TransactionDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiTransactionServerResponseModel verifyResponse = await service.Get(2);

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

			ApiTransactionClientResponseModel response = await client.TransactionGetAsync(1);

			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.Id.Should().Be(1);
			response.TransactionStatusId.Should().Be(1);
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
			ApiTransactionClientResponseModel response = await client.TransactionGetAsync(default(int));

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
			List<ApiTransactionClientResponseModel> response = await client.TransactionAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Amount.Should().Be(1m);
			response[0].GatewayConfirmationNumber.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].TransactionStatusId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTransactionStatusIdFound()
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
			List<ApiTransactionClientResponseModel> response = await client.ByTransactionByTransactionStatusId(1);

			response.Should().NotBeEmpty();
			response[0].Amount.Should().Be(1m);
			response[0].GatewayConfirmationNumber.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].TransactionStatusId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTransactionStatusIdNotFound()
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
			List<ApiTransactionClientResponseModel> response = await client.ByTransactionByTransactionStatusId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesByTransactionIdFound()
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
			List<ApiSaleClientResponseModel> response = await client.SalesByTransactionId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesByTransactionIdNotFound()
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
			List<ApiSaleClientResponseModel> response = await client.SalesByTransactionId(default(int));

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
				var result = await client.TransactionAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>46e47e4eb8a92a42f2c9c1f0fd3da730</Hash>
</Codenesium>*/