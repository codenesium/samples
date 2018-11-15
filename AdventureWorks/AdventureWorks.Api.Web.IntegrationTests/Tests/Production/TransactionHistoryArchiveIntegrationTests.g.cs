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
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "Integration")]
	public partial class TransactionHistoryArchiveIntegrationTests
	{
		public TransactionHistoryArchiveIntegrationTests()
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

			var model = new ApiTransactionHistoryArchiveClientRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			var model2 = new ApiTransactionHistoryArchiveClientRequestModel();
			model2.SetProperties(3m, DateTime.Parse("1/1/1989 12:00:00 AM"), 3, 3, 3, 3, DateTime.Parse("1/1/1989 12:00:00 AM"), "C");
			var request = new List<ApiTransactionHistoryArchiveClientRequestModel>() {model, model2};
			CreateResponse<List<ApiTransactionHistoryArchiveClientResponseModel>> result = await client.TransactionHistoryArchiveBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<TransactionHistoryArchive>().ToList()[1].ActualCost.Should().Be(2m);
			context.Set<TransactionHistoryArchive>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistoryArchive>().ToList()[1].ProductID.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[1].Quantity.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[1].ReferenceOrderID.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[1].ReferenceOrderLineID.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[1].TransactionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistoryArchive>().ToList()[1].TransactionType.Should().Be("B");

			context.Set<TransactionHistoryArchive>().ToList()[2].ActualCost.Should().Be(3m);
			context.Set<TransactionHistoryArchive>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<TransactionHistoryArchive>().ToList()[2].ProductID.Should().Be(3);
			context.Set<TransactionHistoryArchive>().ToList()[2].Quantity.Should().Be(3);
			context.Set<TransactionHistoryArchive>().ToList()[2].ReferenceOrderID.Should().Be(3);
			context.Set<TransactionHistoryArchive>().ToList()[2].ReferenceOrderLineID.Should().Be(3);
			context.Set<TransactionHistoryArchive>().ToList()[2].TransactionDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<TransactionHistoryArchive>().ToList()[2].TransactionType.Should().Be("C");
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

			var model = new ApiTransactionHistoryArchiveClientRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiTransactionHistoryArchiveClientResponseModel> result = await client.TransactionHistoryArchiveCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<TransactionHistoryArchive>().ToList()[1].ActualCost.Should().Be(2m);
			context.Set<TransactionHistoryArchive>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistoryArchive>().ToList()[1].ProductID.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[1].Quantity.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[1].ReferenceOrderID.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[1].ReferenceOrderLineID.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[1].TransactionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistoryArchive>().ToList()[1].TransactionType.Should().Be("B");

			result.Record.ActualCost.Should().Be(2m);
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ProductID.Should().Be(2);
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
			var mapper = new ApiTransactionHistoryArchiveServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ITransactionHistoryArchiveService service = testServer.Host.Services.GetService(typeof(ITransactionHistoryArchiveService)) as ITransactionHistoryArchiveService;
			ApiTransactionHistoryArchiveServerResponseModel model = await service.Get(1);

			ApiTransactionHistoryArchiveClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");

			UpdateResponse<ApiTransactionHistoryArchiveClientResponseModel> updateResponse = await client.TransactionHistoryArchiveUpdateAsync(model.TransactionID, request);

			context.Entry(context.Set<TransactionHistoryArchive>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.TransactionID.Should().Be(1);
			context.Set<TransactionHistoryArchive>().ToList()[0].ActualCost.Should().Be(2m);
			context.Set<TransactionHistoryArchive>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistoryArchive>().ToList()[0].ProductID.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[0].Quantity.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[0].ReferenceOrderID.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[0].ReferenceOrderLineID.Should().Be(2);
			context.Set<TransactionHistoryArchive>().ToList()[0].TransactionDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<TransactionHistoryArchive>().ToList()[0].TransactionType.Should().Be("B");

			updateResponse.Record.TransactionID.Should().Be(1);
			updateResponse.Record.ActualCost.Should().Be(2m);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ProductID.Should().Be(2);
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

			ITransactionHistoryArchiveService service = testServer.Host.Services.GetService(typeof(ITransactionHistoryArchiveService)) as ITransactionHistoryArchiveService;
			var model = new ApiTransactionHistoryArchiveServerRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiTransactionHistoryArchiveServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.TransactionHistoryArchiveDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiTransactionHistoryArchiveServerResponseModel verifyResponse = await service.Get(2);

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

			ApiTransactionHistoryArchiveClientResponseModel response = await client.TransactionHistoryArchiveGetAsync(1);

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
			ApiTransactionHistoryArchiveClientResponseModel response = await client.TransactionHistoryArchiveGetAsync(default(int));

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

			List<ApiTransactionHistoryArchiveClientResponseModel> response = await client.TransactionHistoryArchiveAllAsync();

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
			List<ApiTransactionHistoryArchiveClientResponseModel> response = await client.ByTransactionHistoryArchiveByProductID(1);

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
			List<ApiTransactionHistoryArchiveClientResponseModel> response = await client.ByTransactionHistoryArchiveByProductID(default(int));

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
			List<ApiTransactionHistoryArchiveClientResponseModel> response = await client.ByTransactionHistoryArchiveByReferenceOrderIDReferenceOrderLineID(1, 1);

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
			List<ApiTransactionHistoryArchiveClientResponseModel> response = await client.ByTransactionHistoryArchiveByReferenceOrderIDReferenceOrderLineID(default(int), default(int));

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
				var result = await client.TransactionHistoryArchiveAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>d92b15743d280a62d1d6e1cf88b59208</Hash>
</Codenesium>*/