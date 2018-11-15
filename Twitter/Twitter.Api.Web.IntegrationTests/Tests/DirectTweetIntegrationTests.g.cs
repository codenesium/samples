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
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "Integration")]
	public partial class DirectTweetIntegrationTests
	{
		public DirectTweetIntegrationTests()
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

			var model = new ApiDirectTweetClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));
			var model2 = new ApiDirectTweetClientRequestModel();
			model2.SetProperties("C", DateTime.Parse("1/1/1989 12:00:00 AM"), 1, TimeSpan.Parse("03:00:00"));
			var request = new List<ApiDirectTweetClientRequestModel>() {model, model2};
			CreateResponse<List<ApiDirectTweetClientResponseModel>> result = await client.DirectTweetBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<DirectTweet>().ToList()[1].Content.Should().Be("B");
			context.Set<DirectTweet>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<DirectTweet>().ToList()[1].TaggedUserId.Should().Be(1);
			context.Set<DirectTweet>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));

			context.Set<DirectTweet>().ToList()[2].Content.Should().Be("C");
			context.Set<DirectTweet>().ToList()[2].Date.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<DirectTweet>().ToList()[2].TaggedUserId.Should().Be(1);
			context.Set<DirectTweet>().ToList()[2].Time.Should().Be(TimeSpan.Parse("03:00:00"));
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

			var model = new ApiDirectTweetClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));
			CreateResponse<ApiDirectTweetClientResponseModel> result = await client.DirectTweetCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<DirectTweet>().ToList()[1].Content.Should().Be("B");
			context.Set<DirectTweet>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<DirectTweet>().ToList()[1].TaggedUserId.Should().Be(1);
			context.Set<DirectTweet>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));

			result.Record.Content.Should().Be("B");
			result.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.TaggedUserId.Should().Be(1);
			result.Record.Time.Should().Be(TimeSpan.Parse("02:00:00"));
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiDirectTweetServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IDirectTweetService service = testServer.Host.Services.GetService(typeof(IDirectTweetService)) as IDirectTweetService;
			ApiDirectTweetServerResponseModel model = await service.Get(1);

			ApiDirectTweetClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));

			UpdateResponse<ApiDirectTweetClientResponseModel> updateResponse = await client.DirectTweetUpdateAsync(model.TweetId, request);

			context.Entry(context.Set<DirectTweet>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.TweetId.Should().Be(1);
			context.Set<DirectTweet>().ToList()[0].Content.Should().Be("B");
			context.Set<DirectTweet>().ToList()[0].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<DirectTweet>().ToList()[0].TaggedUserId.Should().Be(1);
			context.Set<DirectTweet>().ToList()[0].Time.Should().Be(TimeSpan.Parse("02:00:00"));

			updateResponse.Record.TweetId.Should().Be(1);
			updateResponse.Record.Content.Should().Be("B");
			updateResponse.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.TaggedUserId.Should().Be(1);
			updateResponse.Record.Time.Should().Be(TimeSpan.Parse("02:00:00"));
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

			IDirectTweetService service = testServer.Host.Services.GetService(typeof(IDirectTweetService)) as IDirectTweetService;
			var model = new ApiDirectTweetServerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));
			CreateResponse<ApiDirectTweetServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.DirectTweetDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiDirectTweetServerResponseModel verifyResponse = await service.Get(2);

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

			ApiDirectTweetClientResponseModel response = await client.DirectTweetGetAsync(1);

			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TaggedUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiDirectTweetClientResponseModel response = await client.DirectTweetGetAsync(default(int));

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

			List<ApiDirectTweetClientResponseModel> response = await client.DirectTweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Content.Should().Be("A");
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].TaggedUserId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].TweetId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTaggedUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiDirectTweetClientResponseModel> response = await client.ByDirectTweetByTaggedUserId(1);

			response.Should().NotBeEmpty();
			response[0].Content.Should().Be("A");
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].TaggedUserId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response[0].TweetId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByTaggedUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiDirectTweetClientResponseModel> response = await client.ByDirectTweetByTaggedUserId(default(int));

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
				var result = await client.DirectTweetAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>d819020e59803d0effb4ea228bd57d5f</Hash>
</Codenesium>*/