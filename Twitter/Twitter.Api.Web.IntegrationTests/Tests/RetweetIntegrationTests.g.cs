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
	[Trait("Table", "Retweet")]
	[Trait("Area", "Integration")]
	public partial class RetweetIntegrationTests
	{
		public RetweetIntegrationTests()
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

			var model = new ApiRetweetClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);
			var model2 = new ApiRetweetClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), 1, TimeSpan.Parse("03:00:00"), 1);
			var request = new List<ApiRetweetClientRequestModel>() {model, model2};
			CreateResponse<List<ApiRetweetClientResponseModel>> result = await client.RetweetBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Retweet>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Retweet>().ToList()[1].RetwitterUserId.Should().Be(1);
			context.Set<Retweet>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Retweet>().ToList()[1].TweetTweetId.Should().Be(1);

			context.Set<Retweet>().ToList()[2].Date.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Retweet>().ToList()[2].RetwitterUserId.Should().Be(1);
			context.Set<Retweet>().ToList()[2].Time.Should().Be(TimeSpan.Parse("03:00:00"));
			context.Set<Retweet>().ToList()[2].TweetTweetId.Should().Be(1);
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

			var model = new ApiRetweetClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);
			CreateResponse<ApiRetweetClientResponseModel> result = await client.RetweetCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Retweet>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Retweet>().ToList()[1].RetwitterUserId.Should().Be(1);
			context.Set<Retweet>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Retweet>().ToList()[1].TweetTweetId.Should().Be(1);

			result.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.RetwitterUserId.Should().Be(1);
			result.Record.Time.Should().Be(TimeSpan.Parse("02:00:00"));
			result.Record.TweetTweetId.Should().Be(1);
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
			var mapper = new ApiRetweetServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IRetweetService service = testServer.Host.Services.GetService(typeof(IRetweetService)) as IRetweetService;
			ApiRetweetServerResponseModel model = await service.Get(1);

			ApiRetweetClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);

			UpdateResponse<ApiRetweetClientResponseModel> updateResponse = await client.RetweetUpdateAsync(model.Id, request);

			context.Entry(context.Set<Retweet>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Retweet>().ToList()[0].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Retweet>().ToList()[0].RetwitterUserId.Should().Be(1);
			context.Set<Retweet>().ToList()[0].Time.Should().Be(TimeSpan.Parse("02:00:00"));
			context.Set<Retweet>().ToList()[0].TweetTweetId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.RetwitterUserId.Should().Be(1);
			updateResponse.Record.Time.Should().Be(TimeSpan.Parse("02:00:00"));
			updateResponse.Record.TweetTweetId.Should().Be(1);
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

			IRetweetService service = testServer.Host.Services.GetService(typeof(IRetweetService)) as IRetweetService;
			var model = new ApiRetweetServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"), 1);
			CreateResponse<ApiRetweetServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.RetweetDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiRetweetServerResponseModel verifyResponse = await service.Get(2);

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

			ApiRetweetClientResponseModel response = await client.RetweetGetAsync(1);

			response.Should().NotBeNull();
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.RetwitterUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetTweetId.Should().Be(1);
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
			ApiRetweetClientResponseModel response = await client.RetweetGetAsync(default(int));

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
			List<ApiRetweetClientResponseModel> response = await client.RetweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].RetwitterUserId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].TweetTweetId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByRetwitterUserIdFound()
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
			List<ApiRetweetClientResponseModel> response = await client.ByRetweetByRetwitterUserId(1);

			response.Should().NotBeEmpty();
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].RetwitterUserId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].TweetTweetId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByRetwitterUserIdNotFound()
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
			List<ApiRetweetClientResponseModel> response = await client.ByRetweetByRetwitterUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByTweetTweetIdFound()
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
			List<ApiRetweetClientResponseModel> response = await client.ByRetweetByTweetTweetId(1);

			response.Should().NotBeEmpty();
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].RetwitterUserId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].TweetTweetId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTweetTweetIdNotFound()
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
			List<ApiRetweetClientResponseModel> response = await client.ByRetweetByTweetTweetId(default(int));

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
				var result = await client.RetweetAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>0bbc873fca8246a0797b3e82a98f33b2</Hash>
</Codenesium>*/