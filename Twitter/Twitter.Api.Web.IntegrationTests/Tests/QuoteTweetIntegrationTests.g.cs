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
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "Integration")]
	public partial class QuoteTweetIntegrationTests
	{
		public QuoteTweetIntegrationTests()
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

			var model = new ApiQuoteTweetClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("02:00:00"));
			var model2 = new ApiQuoteTweetClientRequestModel();
			model2.SetProperties("C", DateTime.Parse("1/1/1989 12:00:00 AM"), 1, 1, TimeSpan.Parse("03:00:00"));
			var request = new List<ApiQuoteTweetClientRequestModel>() {model, model2};
			CreateResponse<List<ApiQuoteTweetClientResponseModel>> result = await client.QuoteTweetBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<QuoteTweet>().ToList()[1].Content.Should().Be("B");
			context.Set<QuoteTweet>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<QuoteTweet>().ToList()[1].RetweeterUserId.Should().Be(1);
			context.Set<QuoteTweet>().ToList()[1].SourceTweetId.Should().Be(1);
			context.Set<QuoteTweet>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));

			context.Set<QuoteTweet>().ToList()[2].Content.Should().Be("C");
			context.Set<QuoteTweet>().ToList()[2].Date.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<QuoteTweet>().ToList()[2].RetweeterUserId.Should().Be(1);
			context.Set<QuoteTweet>().ToList()[2].SourceTweetId.Should().Be(1);
			context.Set<QuoteTweet>().ToList()[2].Time.Should().Be(TimeSpan.Parse("03:00:00"));
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

			var model = new ApiQuoteTweetClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("02:00:00"));
			CreateResponse<ApiQuoteTweetClientResponseModel> result = await client.QuoteTweetCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<QuoteTweet>().ToList()[1].Content.Should().Be("B");
			context.Set<QuoteTweet>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<QuoteTweet>().ToList()[1].RetweeterUserId.Should().Be(1);
			context.Set<QuoteTweet>().ToList()[1].SourceTweetId.Should().Be(1);
			context.Set<QuoteTweet>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));

			result.Record.Content.Should().Be("B");
			result.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.RetweeterUserId.Should().Be(1);
			result.Record.SourceTweetId.Should().Be(1);
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
			var mapper = new ApiQuoteTweetServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IQuoteTweetService service = testServer.Host.Services.GetService(typeof(IQuoteTweetService)) as IQuoteTweetService;
			ApiQuoteTweetServerResponseModel model = await service.Get(1);

			ApiQuoteTweetClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("02:00:00"));

			UpdateResponse<ApiQuoteTweetClientResponseModel> updateResponse = await client.QuoteTweetUpdateAsync(model.QuoteTweetId, request);

			context.Entry(context.Set<QuoteTweet>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.QuoteTweetId.Should().Be(1);
			context.Set<QuoteTweet>().ToList()[0].Content.Should().Be("B");
			context.Set<QuoteTweet>().ToList()[0].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<QuoteTweet>().ToList()[0].RetweeterUserId.Should().Be(1);
			context.Set<QuoteTweet>().ToList()[0].SourceTweetId.Should().Be(1);
			context.Set<QuoteTweet>().ToList()[0].Time.Should().Be(TimeSpan.Parse("02:00:00"));

			updateResponse.Record.QuoteTweetId.Should().Be(1);
			updateResponse.Record.Content.Should().Be("B");
			updateResponse.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.RetweeterUserId.Should().Be(1);
			updateResponse.Record.SourceTweetId.Should().Be(1);
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

			IQuoteTweetService service = testServer.Host.Services.GetService(typeof(IQuoteTweetService)) as IQuoteTweetService;
			var model = new ApiQuoteTweetServerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("02:00:00"));
			CreateResponse<ApiQuoteTweetServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.QuoteTweetDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiQuoteTweetServerResponseModel verifyResponse = await service.Get(2);

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

			ApiQuoteTweetClientResponseModel response = await client.QuoteTweetGetAsync(1);

			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuoteTweetId.Should().Be(1);
			response.RetweeterUserId.Should().Be(1);
			response.SourceTweetId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiQuoteTweetClientResponseModel response = await client.QuoteTweetGetAsync(default(int));

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

			List<ApiQuoteTweetClientResponseModel> response = await client.QuoteTweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Content.Should().Be("A");
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].QuoteTweetId.Should().Be(1);
			response[0].RetweeterUserId.Should().Be(1);
			response[0].SourceTweetId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public virtual async void TestByRetweeterUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiQuoteTweetClientResponseModel> response = await client.ByQuoteTweetByRetweeterUserId(1);

			response.Should().NotBeEmpty();
			response[0].Content.Should().Be("A");
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].QuoteTweetId.Should().Be(1);
			response[0].RetweeterUserId.Should().Be(1);
			response[0].SourceTweetId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public virtual async void TestByRetweeterUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiQuoteTweetClientResponseModel> response = await client.ByQuoteTweetByRetweeterUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestBySourceTweetIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiQuoteTweetClientResponseModel> response = await client.ByQuoteTweetBySourceTweetId(1);

			response.Should().NotBeEmpty();
			response[0].Content.Should().Be("A");
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].QuoteTweetId.Should().Be(1);
			response[0].RetweeterUserId.Should().Be(1);
			response[0].SourceTweetId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public virtual async void TestBySourceTweetIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiQuoteTweetClientResponseModel> response = await client.ByQuoteTweetBySourceTweetId(default(int));

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
				var result = await client.QuoteTweetAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>e0dab768300d14e104400f81731a5330</Hash>
</Codenesium>*/