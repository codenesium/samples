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
	[Trait("Table", "Reply")]
	[Trait("Area", "Integration")]
	public partial class ReplyIntegrationTests
	{
		public ReplyIntegrationTests()
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

			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());

			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiReplyClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));
			var model2 = new ApiReplyClientRequestModel();
			model2.SetProperties("C", DateTime.Parse("1/1/1989 12:00:00 AM"), 1, TimeSpan.Parse("03:00:00"));
			var request = new List<ApiReplyClientRequestModel>() {model, model2};
			CreateResponse<List<ApiReplyClientResponseModel>> result = await client.ReplyBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Reply>().ToList()[1].Content.Should().Be("B");
			context.Set<Reply>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Reply>().ToList()[1].ReplierUserId.Should().Be(1);
			context.Set<Reply>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));

			context.Set<Reply>().ToList()[2].Content.Should().Be("C");
			context.Set<Reply>().ToList()[2].Date.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Reply>().ToList()[2].ReplierUserId.Should().Be(1);
			context.Set<Reply>().ToList()[2].Time.Should().Be(TimeSpan.Parse("03:00:00"));
		}

		[Fact]
		public virtual async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);
			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiReplyClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));
			CreateResponse<ApiReplyClientResponseModel> result = await client.ReplyCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Reply>().ToList()[1].Content.Should().Be("B");
			context.Set<Reply>().ToList()[1].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Reply>().ToList()[1].ReplierUserId.Should().Be(1);
			context.Set<Reply>().ToList()[1].Time.Should().Be(TimeSpan.Parse("02:00:00"));

			result.Record.Content.Should().Be("B");
			result.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ReplierUserId.Should().Be(1);
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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			var mapper = new ApiReplyServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IReplyService service = testServer.Host.Services.GetService(typeof(IReplyService)) as IReplyService;
			ApiReplyServerResponseModel model = await service.Get(1);

			ApiReplyClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));

			UpdateResponse<ApiReplyClientResponseModel> updateResponse = await client.ReplyUpdateAsync(model.ReplyId, request);

			context.Entry(context.Set<Reply>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.ReplyId.Should().Be(1);
			context.Set<Reply>().ToList()[0].Content.Should().Be("B");
			context.Set<Reply>().ToList()[0].Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Reply>().ToList()[0].ReplierUserId.Should().Be(1);
			context.Set<Reply>().ToList()[0].Time.Should().Be(TimeSpan.Parse("02:00:00"));

			updateResponse.Record.ReplyId.Should().Be(1);
			updateResponse.Record.Content.Should().Be("B");
			updateResponse.Record.Date.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ReplierUserId.Should().Be(1);
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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IReplyService service = testServer.Host.Services.GetService(typeof(IReplyService)) as IReplyService;
			var model = new ApiReplyServerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("02:00:00"));
			CreateResponse<ApiReplyServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.ReplyDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiReplyServerResponseModel verifyResponse = await service.Get(2);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiReplyClientResponseModel response = await client.ReplyGetAsync(1);

			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.ReplyId.Should().Be(1);
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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApiReplyClientResponseModel response = await client.ReplyGetAsync(default(int));

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiReplyClientResponseModel> response = await client.ReplyAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Content.Should().Be("A");
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ReplierUserId.Should().Be(1);
			response[0].ReplyId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public virtual async void TestByReplierUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiReplyClientResponseModel> response = await client.ByReplyByReplierUserId(1);

			response.Should().NotBeEmpty();
			response[0].Content.Should().Be("A");
			response[0].Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ReplierUserId.Should().Be(1);
			response[0].ReplyId.Should().Be(1);
			response[0].Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public virtual async void TestByReplierUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiReplyClientResponseModel> response = await client.ByReplyByReplierUserId(default(int));

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
				var result = await client.ReplyAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>16dcbfebd45132730aa7a8bb10285141</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/