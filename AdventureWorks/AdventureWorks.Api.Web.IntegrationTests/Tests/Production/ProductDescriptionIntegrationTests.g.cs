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
	[Trait("Table", "ProductDescription")]
	[Trait("Area", "Integration")]
	public partial class ProductDescriptionIntegrationTests
	{
		public ProductDescriptionIntegrationTests()
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

			var model = new ApiProductDescriptionClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			var model2 = new ApiProductDescriptionClientRequestModel();
			model2.SetProperties("C", DateTime.Parse("1/1/1989 12:00:00 AM"), Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
			var request = new List<ApiProductDescriptionClientRequestModel>() {model, model2};
			CreateResponse<List<ApiProductDescriptionClientResponseModel>> result = await client.ProductDescriptionBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<ProductDescription>().ToList()[1].Description.Should().Be("B");
			context.Set<ProductDescription>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductDescription>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));

			context.Set<ProductDescription>().ToList()[2].Description.Should().Be("C");
			context.Set<ProductDescription>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<ProductDescription>().ToList()[2].Rowguid.Should().Be(Guid.Parse("8d721ec8-4c9d-632f-6f06-7f89cc14862c"));
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

			var model = new ApiProductDescriptionClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiProductDescriptionClientResponseModel> result = await client.ProductDescriptionCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<ProductDescription>().ToList()[1].Description.Should().Be("B");
			context.Set<ProductDescription>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductDescription>().ToList()[1].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));

			result.Record.Description.Should().Be("B");
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
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
			var mapper = new ApiProductDescriptionServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IProductDescriptionService service = testServer.Host.Services.GetService(typeof(IProductDescriptionService)) as IProductDescriptionService;
			ApiProductDescriptionServerResponseModel model = await service.Get(1);

			ApiProductDescriptionClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));

			UpdateResponse<ApiProductDescriptionClientResponseModel> updateResponse = await client.ProductDescriptionUpdateAsync(model.ProductDescriptionID, request);

			context.Entry(context.Set<ProductDescription>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.ProductDescriptionID.Should().Be(1);
			context.Set<ProductDescription>().ToList()[0].Description.Should().Be("B");
			context.Set<ProductDescription>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductDescription>().ToList()[0].Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));

			updateResponse.Record.ProductDescriptionID.Should().Be(1);
			updateResponse.Record.Description.Should().Be("B");
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Rowguid.Should().Be(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
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

			IProductDescriptionService service = testServer.Host.Services.GetService(typeof(IProductDescriptionService)) as IProductDescriptionService;
			var model = new ApiProductDescriptionServerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiProductDescriptionServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ProductDescriptionDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiProductDescriptionServerResponseModel verifyResponse = await service.Get(2);

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

			ApiProductDescriptionClientResponseModel response = await client.ProductDescriptionGetAsync(1);

			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductDescriptionID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
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
			ApiProductDescriptionClientResponseModel response = await client.ProductDescriptionGetAsync(default(int));

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
			List<ApiProductDescriptionClientResponseModel> response = await client.ProductDescriptionAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Description.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ProductDescriptionID.Should().Be(1);
			response[0].Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public virtual async void TestByRowguidFound()
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
			ApiProductDescriptionClientResponseModel response = await client.ByProductDescriptionByRowguid(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			response.Should().NotBeNull();

			response.Description.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductDescriptionID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public virtual async void TestByRowguidNotFound()
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
			ApiProductDescriptionClientResponseModel response = await client.ByProductDescriptionByRowguid(default(Guid));

			response.Should().BeNull();
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
				var result = await client.ProductDescriptionAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>219b2d55a2f9642782027e085763bc39</Hash>
</Codenesium>*/