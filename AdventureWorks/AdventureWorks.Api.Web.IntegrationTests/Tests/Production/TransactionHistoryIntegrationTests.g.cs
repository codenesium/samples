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
	[Trait("Table", "TransactionHistory")]
	[Trait("Area", "Integration")]
	public partial class TransactionHistoryIntegrationTests
	{
		public TransactionHistoryIntegrationTests()
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

			var model = new ApiTransactionHistoryClientRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			var model2 = new ApiTransactionHistoryClientRequestModel();
			model2.SetProperties(3m, DateTime.Parse("1/1/1989 12:00:00 AM"), 1, 3, 3, 3, DateTime.Parse("1/1/1989 12:00:00 AM"), "C");
			var request = new List<ApiTransactionHistoryClientRequestModel>() {model, model2};
			CreateResponse<List<ApiTransactionHistoryClientResponseModel>> result = await client.TransactionHistoryBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<TransactionHistory>().ToList()[1].ActualCost.Should().Be(2m);
			context.Set<TransactionHistory>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistory>().ToList()[1].ProductID.Should().Be(1);
			context.Set<TransactionHistory>().ToList()[1].Quantity.Should().Be(2);
			context.Set<TransactionHistory>().ToList()[1].ReferenceOrderID.Should().Be(2);
			context.Set<TransactionHistory>().ToList()[1].ReferenceOrderLineID.Should().Be(2);
			context.Set<TransactionHistory>().ToList()[1].TransactionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistory>().ToList()[1].TransactionType.Should().Be("B");

			context.Set<TransactionHistory>().ToList()[2].ActualCost.Should().Be(3m);
			context.Set<TransactionHistory>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<TransactionHistory>().ToList()[2].ProductID.Should().Be(1);
			context.Set<TransactionHistory>().ToList()[2].Quantity.Should().Be(3);
			context.Set<TransactionHistory>().ToList()[2].ReferenceOrderID.Should().Be(3);
			context.Set<TransactionHistory>().ToList()[2].ReferenceOrderLineID.Should().Be(3);
			context.Set<TransactionHistory>().ToList()[2].TransactionDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<TransactionHistory>().ToList()[2].TransactionType.Should().Be("C");
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

			var model = new ApiTransactionHistoryClientRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiTransactionHistoryClientResponseModel> result = await client.TransactionHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<TransactionHistory>().ToList()[1].ActualCost.Should().Be(2m);
			context.Set<TransactionHistory>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistory>().ToList()[1].ProductID.Should().Be(1);
			context.Set<TransactionHistory>().ToList()[1].Quantity.Should().Be(2);
			context.Set<TransactionHistory>().ToList()[1].ReferenceOrderID.Should().Be(2);
			context.Set<TransactionHistory>().ToList()[1].ReferenceOrderLineID.Should().Be(2);
			context.Set<TransactionHistory>().ToList()[1].TransactionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistory>().ToList()[1].TransactionType.Should().Be("B");

			result.Record.ActualCost.Should().Be(2m);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ProductID.Should().Be(1);
			result.Record.Quantity.Should().Be(2);
			result.Record.ReferenceOrderID.Should().Be(2);
			result.Record.ReferenceOrderLineID.Should().Be(2);
			result.Record.TransactionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.TransactionType.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiTransactionHistoryServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ITransactionHistoryService service = testServer.Host.Services.GetService(typeof(ITransactionHistoryService)) as ITransactionHistoryService;
			ApiTransactionHistoryServerResponseModel model = await service.Get(1);

			ApiTransactionHistoryClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");

			UpdateResponse<ApiTransactionHistoryClientResponseModel> updateResponse = await client.TransactionHistoryUpdateAsync(model.TransactionID, request);

			context.Entry(context.Set<TransactionHistory>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.TransactionID.Should().Be(1);
			context.Set<TransactionHistory>().ToList()[0].ActualCost.Should().Be(2m);
			context.Set<TransactionHistory>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistory>().ToList()[0].ProductID.Should().Be(1);
			context.Set<TransactionHistory>().ToList()[0].Quantity.Should().Be(2);
			context.Set<TransactionHistory>().ToList()[0].ReferenceOrderID.Should().Be(2);
			context.Set<TransactionHistory>().ToList()[0].ReferenceOrderLineID.Should().Be(2);
			context.Set<TransactionHistory>().ToList()[0].TransactionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistory>().ToList()[0].TransactionType.Should().Be("B");

			updateResponse.Record.TransactionID.Should().Be(1);
			updateResponse.Record.ActualCost.Should().Be(2m);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ProductID.Should().Be(1);
			updateResponse.Record.Quantity.Should().Be(2);
			updateResponse.Record.ReferenceOrderID.Should().Be(2);
			updateResponse.Record.ReferenceOrderLineID.Should().Be(2);
			updateResponse.Record.TransactionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.TransactionType.Should().Be("B");
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

			ITransactionHistoryService service = testServer.Host.Services.GetService(typeof(ITransactionHistoryService)) as ITransactionHistoryService;
			var model = new ApiTransactionHistoryServerRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiTransactionHistoryServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.TransactionHistoryDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiTransactionHistoryServerResponseModel verifyResponse = await service.Get(2);

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

			ApiTransactionHistoryClientResponseModel response = await client.TransactionHistoryGetAsync(1);

			response.Should().NotBeNull();
			response.ActualCost.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ReferenceOrderID.Should().Be(1);
			response.ReferenceOrderLineID.Should().Be(1);
			response.TransactionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionID.Should().Be(1);
			response.TransactionType.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiTransactionHistoryClientResponseModel response = await client.TransactionHistoryGetAsync(default(int));

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

			List<ApiTransactionHistoryClientResponseModel> response = await client.TransactionHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].ActualCost.Should().Be(1m);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ProductID.Should().Be(1);
			response[0].Quantity.Should().Be(1);
			response[0].ReferenceOrderID.Should().Be(1);
			response[0].ReferenceOrderLineID.Should().Be(1);
			response[0].TransactionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].TransactionID.Should().Be(1);
			response[0].TransactionType.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByProductIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiTransactionHistoryClientResponseModel> response = await client.ByTransactionHistoryByProductID(1);

			response.Should().NotBeEmpty();
			response[0].ActualCost.Should().Be(1m);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ProductID.Should().Be(1);
			response[0].Quantity.Should().Be(1);
			response[0].ReferenceOrderID.Should().Be(1);
			response[0].ReferenceOrderLineID.Should().Be(1);
			response[0].TransactionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].TransactionID.Should().Be(1);
			response[0].TransactionType.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByProductIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiTransactionHistoryClientResponseModel> response = await client.ByTransactionHistoryByProductID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByReferenceOrderIDReferenceOrderLineIDFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiTransactionHistoryClientResponseModel> response = await client.ByTransactionHistoryByReferenceOrderIDReferenceOrderLineID(1, 1);

			response.Should().NotBeEmpty();
			response[0].ActualCost.Should().Be(1m);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ProductID.Should().Be(1);
			response[0].Quantity.Should().Be(1);
			response[0].ReferenceOrderID.Should().Be(1);
			response[0].ReferenceOrderLineID.Should().Be(1);
			response[0].TransactionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].TransactionID.Should().Be(1);
			response[0].TransactionType.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByReferenceOrderIDReferenceOrderLineIDNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiTransactionHistoryClientResponseModel> response = await client.ByTransactionHistoryByReferenceOrderIDReferenceOrderLineID(default(int), default(int));

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
				var result = await client.TransactionHistoryAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>d220937740c96f909afe17ab05cf0c50</Hash>
</Codenesium>*/