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
	[Trait("Table", "CreditCard")]
	[Trait("Area", "Integration")]
	public partial class CreditCardIntegrationTests
	{
		public CreditCardIntegrationTests()
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

			var model = new ApiCreditCardClientRequestModel();
			model.SetProperties("B", "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			var model2 = new ApiCreditCardClientRequestModel();
			model2.SetProperties("C", "C", 3, 3, DateTime.Parse("1/1/1989 12:00:00 AM"));
			var request = new List<ApiCreditCardClientRequestModel>() {model, model2};
			CreateResponse<List<ApiCreditCardClientResponseModel>> result = await client.CreditCardBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<CreditCard>().ToList()[1].CardNumber.Should().Be("B");
			context.Set<CreditCard>().ToList()[1].CardType.Should().Be("B");
			context.Set<CreditCard>().ToList()[1].ExpMonth.Should().Be(2);
			context.Set<CreditCard>().ToList()[1].ExpYear.Should().Be(2);
			context.Set<CreditCard>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			context.Set<CreditCard>().ToList()[2].CardNumber.Should().Be("C");
			context.Set<CreditCard>().ToList()[2].CardType.Should().Be("C");
			context.Set<CreditCard>().ToList()[2].ExpMonth.Should().Be(3);
			context.Set<CreditCard>().ToList()[2].ExpYear.Should().Be(3);
			context.Set<CreditCard>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
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

			var model = new ApiCreditCardClientRequestModel();
			model.SetProperties("B", "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiCreditCardClientResponseModel> result = await client.CreditCardCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<CreditCard>().ToList()[1].CardNumber.Should().Be("B");
			context.Set<CreditCard>().ToList()[1].CardType.Should().Be("B");
			context.Set<CreditCard>().ToList()[1].ExpMonth.Should().Be(2);
			context.Set<CreditCard>().ToList()[1].ExpYear.Should().Be(2);
			context.Set<CreditCard>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			result.Record.CardNumber.Should().Be("B");
			result.Record.CardType.Should().Be("B");
			result.Record.ExpMonth.Should().Be(2);
			result.Record.ExpYear.Should().Be(2);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiCreditCardServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ICreditCardService service = testServer.Host.Services.GetService(typeof(ICreditCardService)) as ICreditCardService;
			ApiCreditCardServerResponseModel model = await service.Get(1);

			ApiCreditCardClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"));

			UpdateResponse<ApiCreditCardClientResponseModel> updateResponse = await client.CreditCardUpdateAsync(model.CreditCardID, request);

			context.Entry(context.Set<CreditCard>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.CreditCardID.Should().Be(1);
			context.Set<CreditCard>().ToList()[0].CardNumber.Should().Be("B");
			context.Set<CreditCard>().ToList()[0].CardType.Should().Be("B");
			context.Set<CreditCard>().ToList()[0].ExpMonth.Should().Be(2);
			context.Set<CreditCard>().ToList()[0].ExpYear.Should().Be(2);
			context.Set<CreditCard>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			updateResponse.Record.CreditCardID.Should().Be(1);
			updateResponse.Record.CardNumber.Should().Be("B");
			updateResponse.Record.CardType.Should().Be("B");
			updateResponse.Record.ExpMonth.Should().Be(2);
			updateResponse.Record.ExpYear.Should().Be(2);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
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

			ICreditCardService service = testServer.Host.Services.GetService(typeof(ICreditCardService)) as ICreditCardService;
			var model = new ApiCreditCardServerRequestModel();
			model.SetProperties("B", "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiCreditCardServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.CreditCardDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiCreditCardServerResponseModel verifyResponse = await service.Get(2);

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

			ApiCreditCardClientResponseModel response = await client.CreditCardGetAsync(1);

			response.Should().NotBeNull();
			response.CardNumber.Should().Be("A");
			response.CardType.Should().Be("A");
			response.CreditCardID.Should().Be(1);
			response.ExpMonth.Should().Be(1);
			response.ExpYear.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCreditCardClientResponseModel response = await client.CreditCardGetAsync(default(int));

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

			List<ApiCreditCardClientResponseModel> response = await client.CreditCardAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CardNumber.Should().Be("A");
			response[0].CardType.Should().Be("A");
			response[0].CreditCardID.Should().Be(1);
			response[0].ExpMonth.Should().Be(1);
			response[0].ExpYear.Should().Be(1);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public virtual async void TestByCardNumberFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCreditCardClientResponseModel response = await client.ByCreditCardByCardNumber("A");

			response.Should().NotBeNull();

			response.CardNumber.Should().Be("A");
			response.CardType.Should().Be("A");
			response.CreditCardID.Should().Be(1);
			response.ExpMonth.Should().Be(1);
			response.ExpYear.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public virtual async void TestByCardNumberNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCreditCardClientResponseModel response = await client.ByCreditCardByCardNumber("test_value");

			response.Should().BeNull();
		}

		[Fact]
		public virtual async void TestForeignKeySalesOrderHeadersByCreditCardIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.SalesOrderHeadersByCreditCardID(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeySalesOrderHeadersByCreditCardIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSalesOrderHeaderClientResponseModel> response = await client.SalesOrderHeadersByCreditCardID(default(int));

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
				var result = await client.CreditCardAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>80e5509a2b452caa35e5db5243637b5c</Hash>
</Codenesium>*/