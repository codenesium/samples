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
	[Trait("Table", "Users")]
	[Trait("Area", "Integration")]
	public partial class UsersIntegrationTests
	{
		public UsersIntegrationTests()
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

			var model = new ApiUsersClientRequestModel();
			model.SetProperties("B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			var model2 = new ApiUsersClientRequestModel();
			model2.SetProperties("C", 3, 3, DateTime.Parse("1/1/1989 12:00:00 AM"), "C", 3, "C", DateTime.Parse("1/1/1989 12:00:00 AM"), "C", 3, 3, 3, "C");
			var request = new List<ApiUsersClientRequestModel>() {model, model2};
			CreateResponse<List<ApiUsersClientResponseModel>> result = await client.UsersBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Users>().ToList()[1].AboutMe.Should().Be("B");
			context.Set<Users>().ToList()[1].AccountId.Should().Be(2);
			context.Set<Users>().ToList()[1].Age.Should().Be(2);
			context.Set<Users>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Users>().ToList()[1].DisplayName.Should().Be("B");
			context.Set<Users>().ToList()[1].DownVote.Should().Be(2);
			context.Set<Users>().ToList()[1].EmailHash.Should().Be("B");
			context.Set<Users>().ToList()[1].LastAccessDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Users>().ToList()[1].Location.Should().Be("B");
			context.Set<Users>().ToList()[1].Reputation.Should().Be(2);
			context.Set<Users>().ToList()[1].UpVote.Should().Be(2);
			context.Set<Users>().ToList()[1].View.Should().Be(2);
			context.Set<Users>().ToList()[1].WebsiteUrl.Should().Be("B");

			context.Set<Users>().ToList()[2].AboutMe.Should().Be("C");
			context.Set<Users>().ToList()[2].AccountId.Should().Be(3);
			context.Set<Users>().ToList()[2].Age.Should().Be(3);
			context.Set<Users>().ToList()[2].CreationDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Users>().ToList()[2].DisplayName.Should().Be("C");
			context.Set<Users>().ToList()[2].DownVote.Should().Be(3);
			context.Set<Users>().ToList()[2].EmailHash.Should().Be("C");
			context.Set<Users>().ToList()[2].LastAccessDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Users>().ToList()[2].Location.Should().Be("C");
			context.Set<Users>().ToList()[2].Reputation.Should().Be(3);
			context.Set<Users>().ToList()[2].UpVote.Should().Be(3);
			context.Set<Users>().ToList()[2].View.Should().Be(3);
			context.Set<Users>().ToList()[2].WebsiteUrl.Should().Be("C");
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

			var model = new ApiUsersClientRequestModel();
			model.SetProperties("B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			CreateResponse<ApiUsersClientResponseModel> result = await client.UsersCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Users>().ToList()[1].AboutMe.Should().Be("B");
			context.Set<Users>().ToList()[1].AccountId.Should().Be(2);
			context.Set<Users>().ToList()[1].Age.Should().Be(2);
			context.Set<Users>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Users>().ToList()[1].DisplayName.Should().Be("B");
			context.Set<Users>().ToList()[1].DownVote.Should().Be(2);
			context.Set<Users>().ToList()[1].EmailHash.Should().Be("B");
			context.Set<Users>().ToList()[1].LastAccessDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Users>().ToList()[1].Location.Should().Be("B");
			context.Set<Users>().ToList()[1].Reputation.Should().Be(2);
			context.Set<Users>().ToList()[1].UpVote.Should().Be(2);
			context.Set<Users>().ToList()[1].View.Should().Be(2);
			context.Set<Users>().ToList()[1].WebsiteUrl.Should().Be("B");

			result.Record.AboutMe.Should().Be("B");
			result.Record.AccountId.Should().Be(2);
			result.Record.Age.Should().Be(2);
			result.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.DisplayName.Should().Be("B");
			result.Record.DownVote.Should().Be(2);
			result.Record.EmailHash.Should().Be("B");
			result.Record.LastAccessDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.Location.Should().Be("B");
			result.Record.Reputation.Should().Be(2);
			result.Record.UpVote.Should().Be(2);
			result.Record.View.Should().Be(2);
			result.Record.WebsiteUrl.Should().Be("B");
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
			var mapper = new ApiUsersServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IUsersService service = testServer.Host.Services.GetService(typeof(IUsersService)) as IUsersService;
			ApiUsersServerResponseModel model = await service.Get(1);

			ApiUsersClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");

			UpdateResponse<ApiUsersClientResponseModel> updateResponse = await client.UsersUpdateAsync(model.Id, request);

			context.Entry(context.Set<Users>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Users>().ToList()[0].AboutMe.Should().Be("B");
			context.Set<Users>().ToList()[0].AccountId.Should().Be(2);
			context.Set<Users>().ToList()[0].Age.Should().Be(2);
			context.Set<Users>().ToList()[0].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Users>().ToList()[0].DisplayName.Should().Be("B");
			context.Set<Users>().ToList()[0].DownVote.Should().Be(2);
			context.Set<Users>().ToList()[0].EmailHash.Should().Be("B");
			context.Set<Users>().ToList()[0].LastAccessDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Users>().ToList()[0].Location.Should().Be("B");
			context.Set<Users>().ToList()[0].Reputation.Should().Be(2);
			context.Set<Users>().ToList()[0].UpVote.Should().Be(2);
			context.Set<Users>().ToList()[0].View.Should().Be(2);
			context.Set<Users>().ToList()[0].WebsiteUrl.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.AboutMe.Should().Be("B");
			updateResponse.Record.AccountId.Should().Be(2);
			updateResponse.Record.Age.Should().Be(2);
			updateResponse.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.DisplayName.Should().Be("B");
			updateResponse.Record.DownVote.Should().Be(2);
			updateResponse.Record.EmailHash.Should().Be("B");
			updateResponse.Record.LastAccessDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.Location.Should().Be("B");
			updateResponse.Record.Reputation.Should().Be(2);
			updateResponse.Record.UpVote.Should().Be(2);
			updateResponse.Record.View.Should().Be(2);
			updateResponse.Record.WebsiteUrl.Should().Be("B");
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

			IUsersService service = testServer.Host.Services.GetService(typeof(IUsersService)) as IUsersService;
			var model = new ApiUsersServerRequestModel();
			model.SetProperties("B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, 2, 2, "B");
			CreateResponse<ApiUsersServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.UsersDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiUsersServerResponseModel verifyResponse = await service.Get(2);

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

			ApiUsersClientResponseModel response = await client.UsersGetAsync(1);

			response.Should().NotBeNull();
			response.AboutMe.Should().Be("A");
			response.AccountId.Should().Be(1);
			response.Age.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DisplayName.Should().Be("A");
			response.DownVote.Should().Be(1);
			response.EmailHash.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastAccessDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Location.Should().Be("A");
			response.Reputation.Should().Be(1);
			response.UpVote.Should().Be(1);
			response.View.Should().Be(1);
			response.WebsiteUrl.Should().Be("A");
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
			ApiUsersClientResponseModel response = await client.UsersGetAsync(default(int));

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
			List<ApiUsersClientResponseModel> response = await client.UsersAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AboutMe.Should().Be("A");
			response[0].AccountId.Should().Be(1);
			response[0].Age.Should().Be(1);
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].DisplayName.Should().Be("A");
			response[0].DownVote.Should().Be(1);
			response[0].EmailHash.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].LastAccessDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Location.Should().Be("A");
			response[0].Reputation.Should().Be(1);
			response[0].UpVote.Should().Be(1);
			response[0].View.Should().Be(1);
			response[0].WebsiteUrl.Should().Be("A");
		}

		[Fact]
		public virtual async void TestForeignKeyBadgesByUserIdFound()
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
			List<ApiBadgesClientResponseModel> response = await client.BadgesByUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyBadgesByUserIdNotFound()
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
			List<ApiBadgesClientResponseModel> response = await client.BadgesByUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyCommentsByUserIdFound()
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
			List<ApiCommentsClientResponseModel> response = await client.CommentsByUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyCommentsByUserIdNotFound()
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
			List<ApiCommentsClientResponseModel> response = await client.CommentsByUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostsByLastEditorUserIdFound()
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
			List<ApiPostsClientResponseModel> response = await client.PostsByLastEditorUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostsByLastEditorUserIdNotFound()
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
			List<ApiPostsClientResponseModel> response = await client.PostsByLastEditorUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostsByOwnerUserIdFound()
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
			List<ApiPostsClientResponseModel> response = await client.PostsByOwnerUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostsByOwnerUserIdNotFound()
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
			List<ApiPostsClientResponseModel> response = await client.PostsByOwnerUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyVotesByUserIdFound()
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
			List<ApiVotesClientResponseModel> response = await client.VotesByUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyVotesByUserIdNotFound()
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
			List<ApiVotesClientResponseModel> response = await client.VotesByUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostHistoryByUserIdFound()
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
			List<ApiPostHistoryClientResponseModel> response = await client.PostHistoryByUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostHistoryByUserIdNotFound()
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
			List<ApiPostHistoryClientResponseModel> response = await client.PostHistoryByUserId(default(int));

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
				var result = await client.UsersAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>224188e333c36c166f26912987ab8a46</Hash>
</Codenesium>*/