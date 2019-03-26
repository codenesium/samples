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
	[Trait("Table", "Comments")]
	[Trait("Area", "Integration")]
	public partial class CommentsIntegrationTests
	{
		public CommentsIntegrationTests()
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

			var model = new ApiCommentsClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, "B", 1);
			var model2 = new ApiCommentsClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), 1, 3, "C", 1);
			var request = new List<ApiCommentsClientRequestModel>() {model, model2};
			CreateResponse<List<ApiCommentsClientResponseModel>> result = await client.CommentsBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Comments>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Comments>().ToList()[1].PostId.Should().Be(1);
			context.Set<Comments>().ToList()[1].Score.Should().Be(2);
			context.Set<Comments>().ToList()[1].Text.Should().Be("B");
			context.Set<Comments>().ToList()[1].UserId.Should().Be(1);

			context.Set<Comments>().ToList()[2].CreationDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Comments>().ToList()[2].PostId.Should().Be(1);
			context.Set<Comments>().ToList()[2].Score.Should().Be(3);
			context.Set<Comments>().ToList()[2].Text.Should().Be("C");
			context.Set<Comments>().ToList()[2].UserId.Should().Be(1);
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

			var model = new ApiCommentsClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, "B", 1);
			CreateResponse<ApiCommentsClientResponseModel> result = await client.CommentsCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Comments>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Comments>().ToList()[1].PostId.Should().Be(1);
			context.Set<Comments>().ToList()[1].Score.Should().Be(2);
			context.Set<Comments>().ToList()[1].Text.Should().Be("B");
			context.Set<Comments>().ToList()[1].UserId.Should().Be(1);

			result.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.PostId.Should().Be(1);
			result.Record.Score.Should().Be(2);
			result.Record.Text.Should().Be("B");
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			var mapper = new ApiCommentsServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ICommentsService service = testServer.Host.Services.GetService(typeof(ICommentsService)) as ICommentsService;
			ApiCommentsServerResponseModel model = await service.Get(1);

			ApiCommentsClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, "B", 1);

			UpdateResponse<ApiCommentsClientResponseModel> updateResponse = await client.CommentsUpdateAsync(model.Id, request);

			context.Entry(context.Set<Comments>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Comments>().ToList()[0].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Comments>().ToList()[0].PostId.Should().Be(1);
			context.Set<Comments>().ToList()[0].Score.Should().Be(2);
			context.Set<Comments>().ToList()[0].Text.Should().Be("B");
			context.Set<Comments>().ToList()[0].UserId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.PostId.Should().Be(1);
			updateResponse.Record.Score.Should().Be(2);
			updateResponse.Record.Text.Should().Be("B");
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ICommentsService service = testServer.Host.Services.GetService(typeof(ICommentsService)) as ICommentsService;
			var model = new ApiCommentsServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 2, "B", 1);
			CreateResponse<ApiCommentsServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.CommentsDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiCommentsServerResponseModel verifyResponse = await service.Get(2);

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

			ApiCommentsClientResponseModel response = await client.CommentsGetAsync(1);

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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			ApiCommentsClientResponseModel response = await client.CommentsGetAsync(default(int));

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
			List<ApiCommentsClientResponseModel> response = await client.CommentsAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].Score.Should().Be(1);
			response[0].Text.Should().Be("A");
			response[0].UserId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByPostIdFound()
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
			List<ApiCommentsClientResponseModel> response = await client.ByCommentsByPostId(1);

			response.Should().NotBeEmpty();
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].Score.Should().Be(1);
			response[0].Text.Should().Be("A");
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiCommentsClientResponseModel> response = await client.ByCommentsByPostId(default(int));

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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiCommentsClientResponseModel> response = await client.ByCommentsByUserId(1);

			response.Should().NotBeEmpty();
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].Score.Should().Be(1);
			response[0].Text.Should().Be("A");
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
			JWTHelper jwtHelper = new JWTHelper();
			client.SetBearerToken(jwtHelper.GenerateBearerToken(
									  "defaultJWTPassword",
									  "https://www.codenesium.com",
									  "https://www.codenesium.com",
									  "test@test.com",
									  "Passw0rd$"));
			List<ApiCommentsClientResponseModel> response = await client.ByCommentsByUserId(default(int));

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
				var result = await client.CommentsAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>ed9d26b76ad940eb6240d77bf192d300</Hash>
</Codenesium>*/