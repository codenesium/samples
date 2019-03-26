using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.Client;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Tweet")]
	[Trait("Area", "Integration")]
	public partial class TweetIntegrationTests
	{
		public TweetIntegrationTests()
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

			var model = new ApiTweetClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);
			var model2 = new ApiTweetClientRequestModel();
			model2.SetProperties("C", DateTime.Parse("1/1/1989 12:00:00 AM"), 1, TimeSpan.Parse("03:00:00"), 1);
			var request = new List<ApiTweetClientRequestModel>() {model, model2};
			CreateResponse<List<ApiTweetClientResponseModel>> result = await client.TweetBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Tweet>().ToList()[1].Content.Should().Be("B");
			context.Set<Tweet>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Tweet>().ToList()[1].LocationId.Should().Be(1);
			context.Set<Tweet>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Tweet>().ToList()[1].UserUserId.Should().Be(1);

			context.Set<Tweet>().ToList()[2].Content.Should().Be("C");
			context.Set<Tweet>().ToList()[2].Date.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Tweet>().ToList()[2].LocationId.Should().Be(1);
			context.Set<Tweet>().ToList()[2].Time.Should().Be(TimeSpan.Parse("03:00:00"));
			context.Set<Tweet>().ToList()[2].UserUserId.Should().Be(1);
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

			var model = new ApiTweetClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);
			CreateResponse<ApiTweetClientResponseModel> result = await client.TweetCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Tweet>().ToList()[1].Content.Should().Be("B");
			context.Set<Tweet>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Tweet>().ToList()[1].LocationId.Should().Be(1);
			context.Set<Tweet>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Tweet>().ToList()[1].UserUserId.Should().Be(1);

			result.Record.Content.Should().Be("B");
			result.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.LocationId.Should().Be(1);
			result.Record.Time.Should().Be(TimeSpan.Parse("02:00:00"));
			result.Record.UserUserId.Should().Be(1);
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
			var mapper = new ApiTweetServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ITweetService service = testServer.Host.Services.GetService(typeof(ITweetService)) as ITweetService;
			ApiTweetServerResponseModel model = await service.Get(1);

			ApiTweetClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);

			UpdateResponse<ApiTweetClientResponseModel> updateResponse = await client.TweetUpdateAsync(model.TweetId, request);

			context.Entry(context.Set<Tweet>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.TweetId.Should().Be(1);
			context.Set<Tweet>().ToList()[0].Content.Should().Be("B");
			context.Set<Tweet>().ToList()[0].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Tweet>().ToList()[0].LocationId.Should().Be(1);
			context.Set<Tweet>().ToList()[0].Time.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Tweet>().ToList()[0].UserUserId.Should().Be(1);

			updateResponse.Record.TweetId.Should().Be(1);
			updateResponse.Record.Content.Should().Be("B");
			updateResponse.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.LocationId.Should().Be(1);
			updateResponse.Record.Time.Should().Be(TimeSpan.Parse("02:00:00"));
			updateResponse.Record.UserUserId.Should().Be(1);
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

			ITweetService service = testServer.Host.Services.GetService(typeof(ITweetService)) as ITweetService;
			var model = new ApiTweetServerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);
			CreateResponse<ApiTweetServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.TweetDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiTweetServerResponseModel verifyResponse = await service.Get(2);

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

			ApiTweetClientResponseModel response = await client.TweetGetAsync(1);

			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LocationId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetId.Should().Be(1);
			response.UserUserId.Should().Be(1);
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
			ApiTweetClientResponseModel response = await client.TweetGetAsync(default(int));

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
			List<ApiTweetClientResponseModel> response = await client.TweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Content.Should().Be("A");
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LocationId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].TweetId.Should().Be(1);
			response[0].UserUserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByLocationIdFound()
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
			List<ApiTweetClientResponseModel> response = await client.ByTweetByLocationId(1);

			response.Should().NotBeEmpty();
			response[0].Content.Should().Be("A");
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LocationId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].TweetId.Should().Be(1);
			response[0].UserUserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByLocationIdNotFound()
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
			List<ApiTweetClientResponseModel> response = await client.ByTweetByLocationId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByUserUserIdFound()
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
			List<ApiTweetClientResponseModel> response = await client.ByTweetByUserUserId(1);

			response.Should().NotBeEmpty();
			response[0].Content.Should().Be("A");
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LocationId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].TweetId.Should().Be(1);
			response[0].UserUserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByUserUserIdNotFound()
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
			List<ApiTweetClientResponseModel> response = await client.ByTweetByUserUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyQuoteTweetsBySourceTweetIdFound()
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
			List<ApiQuoteTweetClientResponseModel> response = await client.QuoteTweetsBySourceTweetId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyQuoteTweetsBySourceTweetIdNotFound()
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
			List<ApiQuoteTweetClientResponseModel> response = await client.QuoteTweetsBySourceTweetId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyRetweetsByTweetTweetIdFound()
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
			List<ApiRetweetClientResponseModel> response = await client.RetweetsByTweetTweetId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyRetweetsByTweetTweetIdNotFound()
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
			List<ApiRetweetClientResponseModel> response = await client.RetweetsByTweetTweetId(default(int));

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
				var result = await client.TweetAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>bba76d13e1f2e0def3daed9647d267f8</Hash>
</Codenesium>*/