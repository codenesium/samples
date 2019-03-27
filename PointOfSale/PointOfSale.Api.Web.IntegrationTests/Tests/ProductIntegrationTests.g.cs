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
	[Trait("Table", "Product")]
	[Trait("Area", "Integration")]
	public partial class ProductIntegrationTests
	{
		public ProductIntegrationTests()
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

			var model = new ApiProductClientRequestModel();
			model.SetProperties(true, "B", "B", 2m, 2);
			var model2 = new ApiProductClientRequestModel();
			model2.SetProperties(true, "C", "C", 3m, 3);
			var request = new List<ApiProductClientRequestModel>() {model, model2};
			CreateResponse<List<ApiProductClientResponseModel>> result = await client.ProductBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Product>().ToList()[1].Active.Should().Be(true);
			context.Set<Product>().ToList()[1].Description.Should().Be("B");
			context.Set<Product>().ToList()[1].Name.Should().Be("B");
			context.Set<Product>().ToList()[1].Price.Should().Be(2m);
			context.Set<Product>().ToList()[1].Quantity.Should().Be(2);

			context.Set<Product>().ToList()[2].Active.Should().Be(true);
			context.Set<Product>().ToList()[2].Description.Should().Be("C");
			context.Set<Product>().ToList()[2].Name.Should().Be("C");
			context.Set<Product>().ToList()[2].Price.Should().Be(3m);
			context.Set<Product>().ToList()[2].Quantity.Should().Be(3);
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

			var model = new ApiProductClientRequestModel();
			model.SetProperties(true, "B", "B", 2m, 2);
			CreateResponse<ApiProductClientResponseModel> result = await client.ProductCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Product>().ToList()[1].Active.Should().Be(true);
			context.Set<Product>().ToList()[1].Description.Should().Be("B");
			context.Set<Product>().ToList()[1].Name.Should().Be("B");
			context.Set<Product>().ToList()[1].Price.Should().Be(2m);
			context.Set<Product>().ToList()[1].Quantity.Should().Be(2);

			result.Record.Active.Should().Be(true);
			result.Record.Description.Should().Be("B");
			result.Record.Name.Should().Be("B");
			result.Record.Price.Should().Be(2m);
			result.Record.Quantity.Should().Be(2);
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
			var mapper = new ApiProductServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IProductService service = testServer.Host.Services.GetService(typeof(IProductService)) as IProductService;
			ApiProductServerResponseModel model = await service.Get(1);

			ApiProductClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(true, "B", "B", 2m, 2);

			UpdateResponse<ApiProductClientResponseModel> updateResponse = await client.ProductUpdateAsync(model.Id, request);

			context.Entry(context.Set<Product>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Product>().ToList()[0].Active.Should().Be(true);
			context.Set<Product>().ToList()[0].Description.Should().Be("B");
			context.Set<Product>().ToList()[0].Name.Should().Be("B");
			context.Set<Product>().ToList()[0].Price.Should().Be(2m);
			context.Set<Product>().ToList()[0].Quantity.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Active.Should().Be(true);
			updateResponse.Record.Description.Should().Be("B");
			updateResponse.Record.Name.Should().Be("B");
			updateResponse.Record.Price.Should().Be(2m);
			updateResponse.Record.Quantity.Should().Be(2);
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

			IProductService service = testServer.Host.Services.GetService(typeof(IProductService)) as IProductService;
			var model = new ApiProductServerRequestModel();
			model.SetProperties(true, "B", "B", 2m, 2);
			CreateResponse<ApiProductServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ProductDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiProductServerResponseModel verifyResponse = await service.Get(2);

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

			ApiProductClientResponseModel response = await client.ProductGetAsync(1);

			response.Should().NotBeNull();
			response.Active.Should().Be(true);
			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Price.Should().Be(1m);
			response.Quantity.Should().Be(1);
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
			ApiProductClientResponseModel response = await client.ProductGetAsync(default(int));

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
			List<ApiProductClientResponseModel> response = await client.ProductAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Active.Should().Be(true);
			response[0].Description.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Name.Should().Be("A");
			response[0].Price.Should().Be(1m);
			response[0].Quantity.Should().Be(1);
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
				var result = await client.ProductAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>fe63753322b715700720e6e1ce598fe3</Hash>
</Codenesium>*/