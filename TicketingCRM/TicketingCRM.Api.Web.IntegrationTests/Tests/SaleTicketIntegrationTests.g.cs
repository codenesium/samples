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
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "Integration")]
	public partial class SaleTicketIntegrationTests
	{
		public SaleTicketIntegrationTests()
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

			var model = new ApiSaleTicketClientRequestModel();
			model.SetProperties(1, 1);
			var model2 = new ApiSaleTicketClientRequestModel();
			model2.SetProperties(1, 1);
			var request = new List<ApiSaleTicketClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSaleTicketClientResponseModel>> result = await client.SaleTicketBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<SaleTicket>().ToList()[1].SaleId.Should().Be(1);
			context.Set<SaleTicket>().ToList()[1].TicketId.Should().Be(1);

			context.Set<SaleTicket>().ToList()[2].SaleId.Should().Be(1);
			context.Set<SaleTicket>().ToList()[2].TicketId.Should().Be(1);
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

			var model = new ApiSaleTicketClientRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiSaleTicketClientResponseModel> result = await client.SaleTicketCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<SaleTicket>().ToList()[1].SaleId.Should().Be(1);
			context.Set<SaleTicket>().ToList()[1].TicketId.Should().Be(1);

			result.Record.SaleId.Should().Be(1);
			result.Record.TicketId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiSaleTicketServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ISaleTicketService service = testServer.Host.Services.GetService(typeof(ISaleTicketService)) as ISaleTicketService;
			ApiSaleTicketServerResponseModel model = await service.Get(1);

			ApiSaleTicketClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(1, 1);

			UpdateResponse<ApiSaleTicketClientResponseModel> updateResponse = await client.SaleTicketUpdateAsync(model.Id, request);

			context.Entry(context.Set<SaleTicket>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<SaleTicket>().ToList()[0].SaleId.Should().Be(1);
			context.Set<SaleTicket>().ToList()[0].TicketId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.SaleId.Should().Be(1);
			updateResponse.Record.TicketId.Should().Be(1);
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

			ISaleTicketService service = testServer.Host.Services.GetService(typeof(ISaleTicketService)) as ISaleTicketService;
			var model = new ApiSaleTicketServerRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiSaleTicketServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.SaleTicketDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiSaleTicketServerResponseModel verifyResponse = await service.Get(2);

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

			ApiSaleTicketClientResponseModel response = await client.SaleTicketGetAsync(1);

			response.Should().NotBeNull();
			response.Id.Should().Be(1);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiSaleTicketClientResponseModel response = await client.SaleTicketGetAsync(default(int));

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

			List<ApiSaleTicketClientResponseModel> response = await client.SaleTicketAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Id.Should().Be(1);
			response[0].SaleId.Should().Be(1);
			response[0].TicketId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTicketIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSaleTicketClientResponseModel> response = await client.BySaleTicketByTicketId(1);

			response.Should().NotBeEmpty();
			response[0].Id.Should().Be(1);
			response[0].SaleId.Should().Be(1);
			response[0].TicketId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTicketIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiSaleTicketClientResponseModel> response = await client.BySaleTicketByTicketId(default(int));

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
				var result = await client.SaleTicketAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>ddccb5cafd9973b949dff17eaebaa41c</Hash>
</Codenesium>*/