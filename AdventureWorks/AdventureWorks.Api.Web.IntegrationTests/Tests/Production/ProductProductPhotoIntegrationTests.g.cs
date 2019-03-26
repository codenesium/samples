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
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "Integration")]
	public partial class ProductProductPhotoIntegrationTests
	{
		public ProductProductPhotoIntegrationTests()
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

			var model = new ApiProductProductPhotoClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, 1);
			var model2 = new ApiProductProductPhotoClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), true, 1);
			var request = new List<ApiProductProductPhotoClientRequestModel>() {model, model2};
			CreateResponse<List<ApiProductProductPhotoClientResponseModel>> result = await client.ProductProductPhotoBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<ProductProductPhoto>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductProductPhoto>().ToList()[1].Primary.Should().Be(true);
			context.Set<ProductProductPhoto>().ToList()[1].ProductPhotoID.Should().Be(1);

			context.Set<ProductProductPhoto>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<ProductProductPhoto>().ToList()[2].Primary.Should().Be(true);
			context.Set<ProductProductPhoto>().ToList()[2].ProductPhotoID.Should().Be(1);
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

			var model = new ApiProductProductPhotoClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, 1);
			CreateResponse<ApiProductProductPhotoClientResponseModel> result = await client.ProductProductPhotoCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<ProductProductPhoto>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductProductPhoto>().ToList()[1].Primary.Should().Be(true);
			context.Set<ProductProductPhoto>().ToList()[1].ProductPhotoID.Should().Be(1);

			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Primary.Should().Be(true);
			result.Record.ProductPhotoID.Should().Be(1);
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
			var mapper = new ApiProductProductPhotoServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IProductProductPhotoService service = testServer.Host.Services.GetService(typeof(IProductProductPhotoService)) as IProductProductPhotoService;
			ApiProductProductPhotoServerResponseModel model = await service.Get(1);

			ApiProductProductPhotoClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, 1);

			UpdateResponse<ApiProductProductPhotoClientResponseModel> updateResponse = await client.ProductProductPhotoUpdateAsync(model.ProductID, request);

			context.Entry(context.Set<ProductProductPhoto>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.ProductID.Should().Be(1);
			context.Set<ProductProductPhoto>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductProductPhoto>().ToList()[0].Primary.Should().Be(true);
			context.Set<ProductProductPhoto>().ToList()[0].ProductPhotoID.Should().Be(1);

			updateResponse.Record.ProductID.Should().Be(1);
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Primary.Should().Be(true);
			updateResponse.Record.ProductPhotoID.Should().Be(1);
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

			IProductProductPhotoService service = testServer.Host.Services.GetService(typeof(IProductProductPhotoService)) as IProductProductPhotoService;
			var model = new ApiProductProductPhotoServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, 1);
			CreateResponse<ApiProductProductPhotoServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ProductProductPhotoDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiProductProductPhotoServerResponseModel verifyResponse = await service.Get(2);

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

			ApiProductProductPhotoClientResponseModel response = await client.ProductProductPhotoGetAsync(1);

			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductID.Should().Be(1);
			response.ProductPhotoID.Should().Be(1);
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
			ApiProductProductPhotoClientResponseModel response = await client.ProductProductPhotoGetAsync(default(int));

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
			List<ApiProductProductPhotoClientResponseModel> response = await client.ProductProductPhotoAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Primary.Should().Be(true);
			response[0].ProductID.Should().Be(1);
			response[0].ProductPhotoID.Should().Be(1);
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
				var result = await client.ProductProductPhotoAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>27d1ed5bd49f18ca467b15bc892acd1c</Hash>
</Codenesium>*/