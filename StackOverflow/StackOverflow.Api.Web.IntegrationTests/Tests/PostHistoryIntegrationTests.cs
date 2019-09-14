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
	[Trait("Table", "PostHistory")]
	[Trait("Area", "Integration")]
	public partial class PostHistoryIntegrationTests
	{
		public PostHistoryIntegrationTests()
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

			var model = new ApiPostHistoryClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B", "B", 1);
			var model2 = new ApiPostHistoryClientRequestModel();
			model2.SetProperties("C", DateTime.Parse("1/1/1989 12:00:00 AM"), 1, 1, "C", "C", "C", 1);
			var request = new List<ApiPostHistoryClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPostHistoryClientResponseModel>> result = await client.PostHistoryBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<PostHistory>().ToList()[1].Comment.Should().Be("B");
			context.Set<PostHistory>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PostHistory>().ToList()[1].PostHistoryTypeId.Should().Be(1);
			context.Set<PostHistory>().ToList()[1].PostId.Should().Be(1);
			context.Set<PostHistory>().ToList()[1].RevisionGUID.Should().Be("B");
			context.Set<PostHistory>().ToList()[1].Text.Should().Be("B");
			context.Set<PostHistory>().ToList()[1].UserDisplayName.Should().Be("B");
			context.Set<PostHistory>().ToList()[1].UserId.Should().Be(1);

			context.Set<PostHistory>().ToList()[2].Comment.Should().Be("C");
			context.Set<PostHistory>().ToList()[2].CreationDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<PostHistory>().ToList()[2].PostHistoryTypeId.Should().Be(1);
			context.Set<PostHistory>().ToList()[2].PostId.Should().Be(1);
			context.Set<PostHistory>().ToList()[2].RevisionGUID.Should().Be("C");
			context.Set<PostHistory>().ToList()[2].Text.Should().Be("C");
			context.Set<PostHistory>().ToList()[2].UserDisplayName.Should().Be("C");
			context.Set<PostHistory>().ToList()[2].UserId.Should().Be(1);
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

			var model = new ApiPostHistoryClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B", "B", 1);
			CreateResponse<ApiPostHistoryClientResponseModel> result = await client.PostHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<PostHistory>().ToList()[1].Comment.Should().Be("B");
			context.Set<PostHistory>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PostHistory>().ToList()[1].PostHistoryTypeId.Should().Be(1);
			context.Set<PostHistory>().ToList()[1].PostId.Should().Be(1);
			context.Set<PostHistory>().ToList()[1].RevisionGUID.Should().Be("B");
			context.Set<PostHistory>().ToList()[1].Text.Should().Be("B");
			context.Set<PostHistory>().ToList()[1].UserDisplayName.Should().Be("B");
			context.Set<PostHistory>().ToList()[1].UserId.Should().Be(1);

			result.Record.Comment.Should().Be("B");
			result.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.PostHistoryTypeId.Should().Be(1);
			result.Record.PostId.Should().Be(1);
			result.Record.RevisionGUID.Should().Be("B");
			result.Record.Text.Should().Be("B");
			result.Record.UserDisplayName.Should().Be("B");
			result.Record.UserId.Should().Be(1);
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
			var mapper = new ApiPostHistoryServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPostHistoryService service = testServer.Host.Services.GetService(typeof(IPostHistoryService)) as IPostHistoryService;
			ApiPostHistoryServerResponseModel model = await service.Get(1);

			ApiPostHistoryClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B", "B", 1);

			UpdateResponse<ApiPostHistoryClientResponseModel> updateResponse = await client.PostHistoryUpdateAsync(model.Id, request);

			context.Entry(context.Set<PostHistory>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<PostHistory>().ToList()[0].Comment.Should().Be("B");
			context.Set<PostHistory>().ToList()[0].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PostHistory>().ToList()[0].PostHistoryTypeId.Should().Be(1);
			context.Set<PostHistory>().ToList()[0].PostId.Should().Be(1);
			context.Set<PostHistory>().ToList()[0].RevisionGUID.Should().Be("B");
			context.Set<PostHistory>().ToList()[0].Text.Should().Be("B");
			context.Set<PostHistory>().ToList()[0].UserDisplayName.Should().Be("B");
			context.Set<PostHistory>().ToList()[0].UserId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Comment.Should().Be("B");
			updateResponse.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.PostHistoryTypeId.Should().Be(1);
			updateResponse.Record.PostId.Should().Be(1);
			updateResponse.Record.RevisionGUID.Should().Be("B");
			updateResponse.Record.Text.Should().Be("B");
			updateResponse.Record.UserDisplayName.Should().Be("B");
			updateResponse.Record.UserId.Should().Be(1);
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

			IPostHistoryService service = testServer.Host.Services.GetService(typeof(IPostHistoryService)) as IPostHistoryService;
			var model = new ApiPostHistoryServerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B", "B", 1);
			CreateResponse<ApiPostHistoryServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PostHistoryDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPostHistoryServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPostHistoryClientResponseModel response = await client.PostHistoryGetAsync(1);

			response.Should().NotBeNull();
			response.Comment.Should().Be("A");
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostHistoryTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RevisionGUID.Should().Be("A");
			response.Text.Should().Be("A");
			response.UserDisplayName.Should().Be("A");
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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApiPostHistoryClientResponseModel response = await client.PostHistoryGetAsync(default(int));

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
			List<ApiPostHistoryClientResponseModel> response = await client.PostHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Comment.Should().Be("A");
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].PostHistoryTypeId.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].RevisionGUID.Should().Be("A");
			response[0].Text.Should().Be("A");
			response[0].UserDisplayName.Should().Be("A");
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByPostHistoryTypeIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostHistoryClientResponseModel> response = await client.ByPostHistoryByPostHistoryTypeId(1);

			response.Should().NotBeEmpty();
			response[0].Comment.Should().Be("A");
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].PostHistoryTypeId.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].RevisionGUID.Should().Be("A");
			response[0].Text.Should().Be("A");
			response[0].UserDisplayName.Should().Be("A");
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByPostHistoryTypeIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostHistoryClientResponseModel> response = await client.ByPostHistoryByPostHistoryTypeId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByPostIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostHistoryClientResponseModel> response = await client.ByPostHistoryByPostId(1);

			response.Should().NotBeEmpty();
			response[0].Comment.Should().Be("A");
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].PostHistoryTypeId.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].RevisionGUID.Should().Be("A");
			response[0].Text.Should().Be("A");
			response[0].UserDisplayName.Should().Be("A");
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostHistoryClientResponseModel> response = await client.ByPostHistoryByPostId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostHistoryClientResponseModel> response = await client.ByPostHistoryByUserId(1);

			response.Should().NotBeEmpty();
			response[0].Comment.Should().Be("A");
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].PostHistoryTypeId.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].RevisionGUID.Should().Be("A");
			response[0].Text.Should().Be("A");
			response[0].UserDisplayName.Should().Be("A");
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostHistoryClientResponseModel> response = await client.ByPostHistoryByUserId(default(int));

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
				var result = await client.PostHistoryAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>2d8a2e80f386ced3d71f56bf65bcb457</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/