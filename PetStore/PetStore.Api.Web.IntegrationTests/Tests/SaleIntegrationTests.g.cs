using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetStoreNS.Api.Client;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Web.IntegrationTests
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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiSaleClientRequestModel();
			model.SetProperties(2m, "B", "B", 1, 1, "B");
			var model2 = new ApiSaleClientRequestModel();
			model2.SetProperties(3m, "C", "C", 1, 1, "C");
			var request = new List<ApiSaleClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSaleClientResponseModel>> result = await client.SaleBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Sale>().ToList()[1].Amount.Should().Be(2m);
			context.Set<Sale>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Sale>().ToList()[1].LastName.Should().Be("B");
			context.Set<Sale>().ToList()[1].PaymentTypeId.Should().Be(1);
			context.Set<Sale>().ToList()[1].PetId.Should().Be(1);
			context.Set<Sale>().ToList()[1].Phone.Should().Be("B");

			context.Set<Sale>().ToList()[2].Amount.Should().Be(3m);
			context.Set<Sale>().ToList()[2].FirstName.Should().Be("C");
			context.Set<Sale>().ToList()[2].LastName.Should().Be("C");
			context.Set<Sale>().ToList()[2].PaymentTypeId.Should().Be(1);
			context.Set<Sale>().ToList()[2].PetId.Should().Be(1);
			context.Set<Sale>().ToList()[2].Phone.Should().Be("C");
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

			var model = new ApiSaleClientRequestModel();
			model.SetProperties(2m, "B", "B", 1, 1, "B");
			CreateResponse<ApiSaleClientResponseModel> result = await client.SaleCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Sale>().ToList()[1].Amount.Should().Be(2m);
			context.Set<Sale>().ToList()[1].FirstName.Should().Be("B");
			context.Set<Sale>().ToList()[1].LastName.Should().Be("B");
			context.Set<Sale>().ToList()[1].PaymentTypeId.Should().Be(1);
			context.Set<Sale>().ToList()[1].PetId.Should().Be(1);
			context.Set<Sale>().ToList()[1].Phone.Should().Be("B");

			result.Record.Amount.Should().Be(2m);
			result.Record.FirstName.Should().Be("B");
			result.Record.LastName.Should().Be("B");
			result.Record.PaymentTypeId.Should().Be(1);
			result.Record.PetId.Should().Be(1);
			result.Record.Phone.Should().Be("B");
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiSaleServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ISaleService service = testServer.Host.Services.GetService(typeof(ISaleService)) as ISaleService;
			ApiSaleServerResponseModel model = await service.Get(1);

			ApiSaleClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2m, "B", "B", 1, 1, "B");

			UpdateResponse<ApiSaleClientResponseModel> updateResponse = await client.SaleUpdateAsync(model.Id, request);

			context.Entry(context.Set<Sale>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Sale>().ToList()[0].Amount.Should().Be(2m);
			context.Set<Sale>().ToList()[0].FirstName.Should().Be("B");
			context.Set<Sale>().ToList()[0].LastName.Should().Be("B");
			context.Set<Sale>().ToList()[0].PaymentTypeId.Should().Be(1);
			context.Set<Sale>().ToList()[0].PetId.Should().Be(1);
			context.Set<Sale>().ToList()[0].Phone.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Amount.Should().Be(2m);
			updateResponse.Record.FirstName.Should().Be("B");
			updateResponse.Record.LastName.Should().Be("B");
			updateResponse.Record.PaymentTypeId.Should().Be(1);
			updateResponse.Record.PetId.Should().Be(1);
			updateResponse.Record.Phone.Should().Be("B");
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

			ISaleService service = testServer.Host.Services.GetService(typeof(ISaleService)) as ISaleService;
			var model = new ApiSaleServerRequestModel();
			model.SetProperties(2m, "B", "B", 1, 1, "B");
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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiSaleClientResponseModel response = await client.SaleGetAsync(1);

			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.PaymentTypeId.Should().Be(1);
			response.PetId.Should().Be(1);
			response.Phone.Should().Be("A");
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
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

			List<ApiSaleClientResponseModel> response = await client.SaleAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Amount.Should().Be(1m);
			response[0].FirstName.Should().Be("A");
			response[0].LastName.Should().Be("A");
			response[0].PaymentTypeId.Should().Be(1);
			response[0].PetId.Should().Be(1);
			response[0].Phone.Should().Be("A");
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
    <Hash>d052fe16a20412886deca7fdad60ed05</Hash>
</Codenesium>*/