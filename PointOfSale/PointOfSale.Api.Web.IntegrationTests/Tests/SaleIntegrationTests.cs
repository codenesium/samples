using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PointOfSaleNS.Api.Client;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using PointOfSaleNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PointOfSaleNS.Api.Web.IntegrationTests
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
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			var model2 = new ApiSaleClientRequestModel();
			model2.SetProperties(3, DateTime.Parse("1/1/1989 12:00:00 AM"));
			var request = new List<ApiSaleClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSaleClientResponseModel>> result = await client.SaleBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Sale>().ToList()[1].CustomerId.Should().Be(2);
			context.Set<Sale>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			context.Set<Sale>().ToList()[2].CustomerId.Should().Be(3);
			context.Set<Sale>().ToList()[2].Date.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
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
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiSaleClientResponseModel> result = await client.SaleCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Sale>().ToList()[1].CustomerId.Should().Be(2);
			context.Set<Sale>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			result.Record.CustomerId.Should().Be(2);
			result.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
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
			request.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"));

			UpdateResponse<ApiSaleClientResponseModel> updateResponse = await client.SaleUpdateAsync(model.Id, request);

			context.Entry(context.Set<Sale>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Sale>().ToList()[0].CustomerId.Should().Be(2);
			context.Set<Sale>().ToList()[0].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.CustomerId.Should().Be(2);
			updateResponse.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
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
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"));
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
			response.CustomerId.Should().Be(1);
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
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
			response[0].CustomerId.Should().Be(1);
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByCustomerIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiSaleClientResponseModel> response = await client.BySaleByCustomerId(1);

			response.Should().NotBeEmpty();
			response[0].CustomerId.Should().Be(1);
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByCustomerIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiSaleClientResponseModel> response = await client.BySaleByCustomerId(default(int));

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
    <Hash>e3aef211582dd669f4b8ce65107b1516</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/