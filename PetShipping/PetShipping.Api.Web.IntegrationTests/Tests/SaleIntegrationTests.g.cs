using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
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

			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiSaleClientRequestModel();
			model.SetProperties(2m, 2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			var model2 = new ApiSaleClientRequestModel();
			model2.SetProperties(3m, 3, "C", 1, DateTime.Parse("1/1/1989 12:00:00 AM"), 3);
			var request = new List<ApiSaleClientRequestModel>() {model, model2};
			CreateResponse<List<ApiSaleClientResponseModel>> result = await client.SaleBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Sale>().ToList()[1].Amount.Should().Be(2m);
			context.Set<Sale>().ToList()[1].CutomerId.Should().Be(2);
			context.Set<Sale>().ToList()[1].Note.Should().Be("B");
			context.Set<Sale>().ToList()[1].PetId.Should().Be(1);
			context.Set<Sale>().ToList()[1].SaleDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Sale>().ToList()[1].SalesPersonId.Should().Be(2);

			context.Set<Sale>().ToList()[2].Amount.Should().Be(3m);
			context.Set<Sale>().ToList()[2].CutomerId.Should().Be(3);
			context.Set<Sale>().ToList()[2].Note.Should().Be("C");
			context.Set<Sale>().ToList()[2].PetId.Should().Be(1);
			context.Set<Sale>().ToList()[2].SaleDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Sale>().ToList()[2].SalesPersonId.Should().Be(3);
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

			var model = new ApiSaleClientRequestModel();
			model.SetProperties(2m, 2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			CreateResponse<ApiSaleClientResponseModel> result = await client.SaleCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Sale>().ToList()[1].Amount.Should().Be(2m);
			context.Set<Sale>().ToList()[1].CutomerId.Should().Be(2);
			context.Set<Sale>().ToList()[1].Note.Should().Be("B");
			context.Set<Sale>().ToList()[1].PetId.Should().Be(1);
			context.Set<Sale>().ToList()[1].SaleDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Sale>().ToList()[1].SalesPersonId.Should().Be(2);

			result.Record.Amount.Should().Be(2m);
			result.Record.CutomerId.Should().Be(2);
			result.Record.Note.Should().Be("B");
			result.Record.PetId.Should().Be(1);
			result.Record.SaleDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.SalesPersonId.Should().Be(2);
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
			var mapper = new ApiSaleServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ISaleService service = testServer.Host.Services.GetService(typeof(ISaleService)) as ISaleService;
			ApiSaleServerResponseModel model = await service.Get(1);

			ApiSaleClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2m, 2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);

			UpdateResponse<ApiSaleClientResponseModel> updateResponse = await client.SaleUpdateAsync(model.Id, request);

			context.Entry(context.Set<Sale>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Sale>().ToList()[0].Amount.Should().Be(2m);
			context.Set<Sale>().ToList()[0].CutomerId.Should().Be(2);
			context.Set<Sale>().ToList()[0].Note.Should().Be("B");
			context.Set<Sale>().ToList()[0].PetId.Should().Be(1);
			context.Set<Sale>().ToList()[0].SaleDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Sale>().ToList()[0].SalesPersonId.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Amount.Should().Be(2m);
			updateResponse.Record.CutomerId.Should().Be(2);
			updateResponse.Record.Note.Should().Be("B");
			updateResponse.Record.PetId.Should().Be(1);
			updateResponse.Record.SaleDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.SalesPersonId.Should().Be(2);
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

			ISaleService service = testServer.Host.Services.GetService(typeof(ISaleService)) as ISaleService;
			var model = new ApiSaleServerRequestModel();
			model.SetProperties(2m, 2, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiSaleClientResponseModel response = await client.SaleGetAsync(1);

			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.CutomerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PetId.Should().Be(1);
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SalesPersonId.Should().Be(1);
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiSaleClientResponseModel> response = await client.SaleAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Amount.Should().Be(1m);
			response[0].CutomerId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].Note.Should().Be("A");
			response[0].PetId.Should().Be(1);
			response[0].SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].SalesPersonId.Should().Be(1);
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
    <Hash>d5f42569413e42e13b0ead1a2893472f</Hash>
</Codenesium>*/