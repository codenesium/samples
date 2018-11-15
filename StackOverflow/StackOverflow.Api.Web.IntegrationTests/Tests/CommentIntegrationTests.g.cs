using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StackOverflowNS.Api.Client;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Comment")]
	[Trait("Area", "Integration")]
	public partial class CommentIntegrationTests
	{
		public CommentIntegrationTests()
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

			var model = new ApiCommentClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B", 2);
			var model2 = new ApiCommentClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), 3, 3, "C", 3);
			var request = new List<ApiCommentClientRequestModel>() {model, model2};
			CreateResponse<List<ApiCommentClientResponseModel>> result = await client.CommentBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Comment>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Comment>().ToList()[1].PostId.Should().Be(2);
			context.Set<Comment>().ToList()[1].Score.Should().Be(2);
			context.Set<Comment>().ToList()[1].Text.Should().Be("B");
			context.Set<Comment>().ToList()[1].UserId.Should().Be(2);

			context.Set<Comment>().ToList()[2].CreationDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Comment>().ToList()[2].PostId.Should().Be(3);
			context.Set<Comment>().ToList()[2].Score.Should().Be(3);
			context.Set<Comment>().ToList()[2].Text.Should().Be("C");
			context.Set<Comment>().ToList()[2].UserId.Should().Be(3);
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

			var model = new ApiCommentClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B", 2);
			CreateResponse<ApiCommentClientResponseModel> result = await client.CommentCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Comment>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Comment>().ToList()[1].PostId.Should().Be(2);
			context.Set<Comment>().ToList()[1].Score.Should().Be(2);
			context.Set<Comment>().ToList()[1].Text.Should().Be("B");
			context.Set<Comment>().ToList()[1].UserId.Should().Be(2);

			result.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.PostId.Should().Be(2);
			result.Record.Score.Should().Be(2);
			result.Record.Text.Should().Be("B");
			result.Record.UserId.Should().Be(2);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiCommentServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ICommentService service = testServer.Host.Services.GetService(typeof(ICommentService)) as ICommentService;
			ApiCommentServerResponseModel model = await service.Get(1);

			ApiCommentClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B", 2);

			UpdateResponse<ApiCommentClientResponseModel> updateResponse = await client.CommentUpdateAsync(model.Id, request);

			context.Entry(context.Set<Comment>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Comment>().ToList()[0].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Comment>().ToList()[0].PostId.Should().Be(2);
			context.Set<Comment>().ToList()[0].Score.Should().Be(2);
			context.Set<Comment>().ToList()[0].Text.Should().Be("B");
			context.Set<Comment>().ToList()[0].UserId.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.PostId.Should().Be(2);
			updateResponse.Record.Score.Should().Be(2);
			updateResponse.Record.Text.Should().Be("B");
			updateResponse.Record.UserId.Should().Be(2);
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

			ICommentService service = testServer.Host.Services.GetService(typeof(ICommentService)) as ICommentService;
			var model = new ApiCommentServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B", 2);
			CreateResponse<ApiCommentServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.CommentDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiCommentServerResponseModel verifyResponse = await service.Get(2);

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

			ApiCommentClientResponseModel response = await client.CommentGetAsync(1);

			response.Should().NotBeNull();
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCommentClientResponseModel response = await client.CommentGetAsync(default(int));

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

			List<ApiCommentClientResponseModel> response = await client.CommentAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].Score.Should().Be(1);
			response[0].Text.Should().Be("A");
			response[0].UserId.Should().Be(1);
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
				var result = await client.CommentAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>4827aab1ec27d6db32586ad3cbf48e86</Hash>
</Codenesium>*/