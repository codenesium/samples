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
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "Integration")]
	public partial class WorkOrderIntegrationTests
	{
		public WorkOrderIntegrationTests()
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

			var model = new ApiWorkOrderClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			var model2 = new ApiWorkOrderClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), 3, 1, 3, 1, DateTime.Parse("1/1/1989 12:00:00 AM"), 3);
			var request = new List<ApiWorkOrderClientRequestModel>() {model, model2};
			CreateResponse<List<ApiWorkOrderClientResponseModel>> result = await client.WorkOrderBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<WorkOrder>().ToList()[1].DueDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[1].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[1].OrderQty.Should().Be(2);
			context.Set<WorkOrder>().ToList()[1].ProductID.Should().Be(1);
			context.Set<WorkOrder>().ToList()[1].ScrappedQty.Should().Be(2);
			context.Set<WorkOrder>().ToList()[1].ScrapReasonID.Should().Be(1);
			context.Set<WorkOrder>().ToList()[1].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[1].StockedQty.Should().Be(2);

			context.Set<WorkOrder>().ToList()[2].DueDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[2].EndDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[2].OrderQty.Should().Be(3);
			context.Set<WorkOrder>().ToList()[2].ProductID.Should().Be(1);
			context.Set<WorkOrder>().ToList()[2].ScrappedQty.Should().Be(3);
			context.Set<WorkOrder>().ToList()[2].ScrapReasonID.Should().Be(1);
			context.Set<WorkOrder>().ToList()[2].StartDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[2].StockedQty.Should().Be(3);
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

			var model = new ApiWorkOrderClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			CreateResponse<ApiWorkOrderClientResponseModel> result = await client.WorkOrderCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<WorkOrder>().ToList()[1].DueDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[1].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[1].OrderQty.Should().Be(2);
			context.Set<WorkOrder>().ToList()[1].ProductID.Should().Be(1);
			context.Set<WorkOrder>().ToList()[1].ScrappedQty.Should().Be(2);
			context.Set<WorkOrder>().ToList()[1].ScrapReasonID.Should().Be(1);
			context.Set<WorkOrder>().ToList()[1].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[1].StockedQty.Should().Be(2);

			result.Record.DueDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.OrderQty.Should().Be(2);
			result.Record.ProductID.Should().Be(1);
			result.Record.ScrappedQty.Should().Be(2);
			result.Record.ScrapReasonID.Should().Be(1);
			result.Record.StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.StockedQty.Should().Be(2);
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
			var mapper = new ApiWorkOrderServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IWorkOrderService service = testServer.Host.Services.GetService(typeof(IWorkOrderService)) as IWorkOrderService;
			ApiWorkOrderServerResponseModel model = await service.Get(1);

			ApiWorkOrderClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);

			UpdateResponse<ApiWorkOrderClientResponseModel> updateResponse = await client.WorkOrderUpdateAsync(model.WorkOrderID, request);

			context.Entry(context.Set<WorkOrder>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.WorkOrderID.Should().Be(1);
			context.Set<WorkOrder>().ToList()[0].DueDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[0].EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[0].OrderQty.Should().Be(2);
			context.Set<WorkOrder>().ToList()[0].ProductID.Should().Be(1);
			context.Set<WorkOrder>().ToList()[0].ScrappedQty.Should().Be(2);
			context.Set<WorkOrder>().ToList()[0].ScrapReasonID.Should().Be(1);
			context.Set<WorkOrder>().ToList()[0].StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<WorkOrder>().ToList()[0].StockedQty.Should().Be(2);

			updateResponse.Record.WorkOrderID.Should().Be(1);
			updateResponse.Record.DueDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.EndDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.OrderQty.Should().Be(2);
			updateResponse.Record.ProductID.Should().Be(1);
			updateResponse.Record.ScrappedQty.Should().Be(2);
			updateResponse.Record.ScrapReasonID.Should().Be(1);
			updateResponse.Record.StartDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.StockedQty.Should().Be(2);
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

			IWorkOrderService service = testServer.Host.Services.GetService(typeof(IWorkOrderService)) as IWorkOrderService;
			var model = new ApiWorkOrderServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, 2, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			CreateResponse<ApiWorkOrderServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.WorkOrderDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiWorkOrderServerResponseModel verifyResponse = await service.Get(2);

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

			ApiWorkOrderClientResponseModel response = await client.WorkOrderGetAsync(1);

			response.Should().NotBeNull();
			response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderQty.Should().Be(1);
			response.ProductID.Should().Be(1);
			response.ScrappedQty.Should().Be(1);
			response.ScrapReasonID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StockedQty.Should().Be(1);
			response.WorkOrderID.Should().Be(1);
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
			ApiWorkOrderClientResponseModel response = await client.WorkOrderGetAsync(default(int));

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
			List<ApiWorkOrderClientResponseModel> response = await client.WorkOrderAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].OrderQty.Should().Be(1);
			response[0].ProductID.Should().Be(1);
			response[0].ScrappedQty.Should().Be(1);
			response[0].ScrapReasonID.Should().Be(1);
			response[0].StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].StockedQty.Should().Be(1);
			response[0].WorkOrderID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByProductIDFound()
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
			List<ApiWorkOrderClientResponseModel> response = await client.ByWorkOrderByProductID(1);

			response.Should().NotBeEmpty();
			response[0].DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].OrderQty.Should().Be(1);
			response[0].ProductID.Should().Be(1);
			response[0].ScrappedQty.Should().Be(1);
			response[0].ScrapReasonID.Should().Be(1);
			response[0].StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].StockedQty.Should().Be(1);
			response[0].WorkOrderID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByProductIDNotFound()
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
			List<ApiWorkOrderClientResponseModel> response = await client.ByWorkOrderByProductID(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByScrapReasonIDFound()
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
			List<ApiWorkOrderClientResponseModel> response = await client.ByWorkOrderByScrapReasonID(1);

			response.Should().NotBeEmpty();
			response[0].DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].OrderQty.Should().Be(1);
			response[0].ProductID.Should().Be(1);
			response[0].ScrappedQty.Should().Be(1);
			response[0].ScrapReasonID.Should().Be(1);
			response[0].StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].StockedQty.Should().Be(1);
			response[0].WorkOrderID.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByScrapReasonIDNotFound()
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
			List<ApiWorkOrderClientResponseModel> response = await client.ByWorkOrderByScrapReasonID(default(short));

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
				var result = await client.WorkOrderAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>47dfd0660801640e653d3b50cc95dea5</Hash>
</Codenesium>*/