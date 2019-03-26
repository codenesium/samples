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
	[Trait("Table", "ProductReview")]
	[Trait("Area", "Integration")]
	public partial class ProductReviewIntegrationTests
	{
		public ProductReviewIntegrationTests()
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

			var model = new ApiProductReviewClientRequestModel();
			model.SetProperties("B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			var model2 = new ApiProductReviewClientRequestModel();
			model2.SetProperties("C", "C", DateTime.Parse("1/1/1989 12:00:00 AM"), 1, 3, DateTime.Parse("1/1/1989 12:00:00 AM"), "C");
			var request = new List<ApiProductReviewClientRequestModel>() {model, model2};
			CreateResponse<List<ApiProductReviewClientResponseModel>> result = await client.ProductReviewBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<ProductReview>().ToList()[1].Comment.Should().Be("B");
			context.Set<ProductReview>().ToList()[1].EmailAddress.Should().Be("B");
			context.Set<ProductReview>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductReview>().ToList()[1].ProductID.Should().Be(1);
			context.Set<ProductReview>().ToList()[1].Rating.Should().Be(2);
			context.Set<ProductReview>().ToList()[1].ReviewDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductReview>().ToList()[1].ReviewerName.Should().Be("B");

			context.Set<ProductReview>().ToList()[2].Comment.Should().Be("C");
			context.Set<ProductReview>().ToList()[2].EmailAddress.Should().Be("C");
			context.Set<ProductReview>().ToList()[2].ModifiedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<ProductReview>().ToList()[2].ProductID.Should().Be(1);
			context.Set<ProductReview>().ToList()[2].Rating.Should().Be(3);
			context.Set<ProductReview>().ToList()[2].ReviewDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<ProductReview>().ToList()[2].ReviewerName.Should().Be("C");
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

			var model = new ApiProductReviewClientRequestModel();
			model.SetProperties("B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiProductReviewClientResponseModel> result = await client.ProductReviewCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<ProductReview>().ToList()[1].Comment.Should().Be("B");
			context.Set<ProductReview>().ToList()[1].EmailAddress.Should().Be("B");
			context.Set<ProductReview>().ToList()[1].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductReview>().ToList()[1].ProductID.Should().Be(1);
			context.Set<ProductReview>().ToList()[1].Rating.Should().Be(2);
			context.Set<ProductReview>().ToList()[1].ReviewDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductReview>().ToList()[1].ReviewerName.Should().Be("B");

			result.Record.Comment.Should().Be("B");
			result.Record.EmailAddress.Should().Be("B");
			result.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ProductID.Should().Be(1);
			result.Record.Rating.Should().Be(2);
			result.Record.ReviewDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ReviewerName.Should().Be("B");
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
			var mapper = new ApiProductReviewServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IProductReviewService service = testServer.Host.Services.GetService(typeof(IProductReviewService)) as IProductReviewService;
			ApiProductReviewServerResponseModel model = await service.Get(1);

			ApiProductReviewClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");

			UpdateResponse<ApiProductReviewClientResponseModel> updateResponse = await client.ProductReviewUpdateAsync(model.ProductReviewID, request);

			context.Entry(context.Set<ProductReview>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.ProductReviewID.Should().Be(1);
			context.Set<ProductReview>().ToList()[0].Comment.Should().Be("B");
			context.Set<ProductReview>().ToList()[0].EmailAddress.Should().Be("B");
			context.Set<ProductReview>().ToList()[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductReview>().ToList()[0].ProductID.Should().Be(1);
			context.Set<ProductReview>().ToList()[0].Rating.Should().Be(2);
			context.Set<ProductReview>().ToList()[0].ReviewDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<ProductReview>().ToList()[0].ReviewerName.Should().Be("B");

			updateResponse.Record.ProductReviewID.Should().Be(1);
			updateResponse.Record.Comment.Should().Be("B");
			updateResponse.Record.EmailAddress.Should().Be("B");
			updateResponse.Record.ModifiedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ProductID.Should().Be(1);
			updateResponse.Record.Rating.Should().Be(2);
			updateResponse.Record.ReviewDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ReviewerName.Should().Be("B");
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

			IProductReviewService service = testServer.Host.Services.GetService(typeof(IProductReviewService)) as IProductReviewService;
			var model = new ApiProductReviewServerRequestModel();
			model.SetProperties("B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiProductReviewServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ProductReviewDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiProductReviewServerResponseModel verifyResponse = await service.Get(2);

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

			ApiProductReviewClientResponseModel response = await client.ProductReviewGetAsync(1);

			response.Should().NotBeNull();
			response.Comment.Should().Be("A");
			response.EmailAddress.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.ProductReviewID.Should().Be(1);
			response.Rating.Should().Be(1);
			response.ReviewDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReviewerName.Should().Be("A");
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
			ApiProductReviewClientResponseModel response = await client.ProductReviewGetAsync(default(int));

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
			List<ApiProductReviewClientResponseModel> response = await client.ProductReviewAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Comment.Should().Be("A");
			response[0].EmailAddress.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ProductID.Should().Be(1);
			response[0].ProductReviewID.Should().Be(1);
			response[0].Rating.Should().Be(1);
			response[0].ReviewDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ReviewerName.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByProductIDReviewerNameFound()
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
			List<ApiProductReviewClientResponseModel> response = await client.ByProductReviewByProductIDReviewerName(1, "A");

			response.Should().NotBeEmpty();
			response[0].Comment.Should().Be("A");
			response[0].EmailAddress.Should().Be("A");
			response[0].ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ProductID.Should().Be(1);
			response[0].ProductReviewID.Should().Be(1);
			response[0].Rating.Should().Be(1);
			response[0].ReviewDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ReviewerName.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByProductIDReviewerNameNotFound()
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
			List<ApiProductReviewClientResponseModel> response = await client.ByProductReviewByProductIDReviewerName(default(int), "test_value");

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
				var result = await client.ProductReviewAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>cc526ea813c0207490da990b7b0047bd</Hash>
</Codenesium>*/