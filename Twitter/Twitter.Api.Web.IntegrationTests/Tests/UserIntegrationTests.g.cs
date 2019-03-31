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
	[Trait("Table", "User")]
	[Trait("Area", "Integration")]
	public partial class UserIntegrationTests
	{
		public UserIntegrationTests()
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

			var model = new ApiUserClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", 1, "B", "B", "B", "B", "B");
			var model2 = new ApiUserClientRequestModel();
			model2.SetProperties("C", DateTime.Parse("1/1/1989 12:00:00 AM"), "C", "C", "C", "C", "C", 1, "C", "C", "C", "C", "C");
			var request = new List<ApiUserClientRequestModel>() {model, model2};
			CreateResponse<List<ApiUserClientResponseModel>> result = await client.UserBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<User>().ToList()[1].BioImgUrl.Should().Be("B");
			context.Set<User>().ToList()[1].Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<User>().ToList()[1].ContentDescription.Should().Be("B");
			context.Set<User>().ToList()[1].Email.Should().Be("B");
			context.Set<User>().ToList()[1].FullName.Should().Be("B");
			context.Set<User>().ToList()[1].HeaderImgUrl.Should().Be("B");
			context.Set<User>().ToList()[1].Interest.Should().Be("B");
			context.Set<User>().ToList()[1].LocationLocationId.Should().Be(1);
			context.Set<User>().ToList()[1].Password.Should().Be("B");
			context.Set<User>().ToList()[1].PhoneNumber.Should().Be("B");
			context.Set<User>().ToList()[1].Privacy.Should().Be("B");
			context.Set<User>().ToList()[1].Username.Should().Be("B");
			context.Set<User>().ToList()[1].Website.Should().Be("B");

			context.Set<User>().ToList()[2].BioImgUrl.Should().Be("C");
			context.Set<User>().ToList()[2].Birthday.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<User>().ToList()[2].ContentDescription.Should().Be("C");
			context.Set<User>().ToList()[2].Email.Should().Be("C");
			context.Set<User>().ToList()[2].FullName.Should().Be("C");
			context.Set<User>().ToList()[2].HeaderImgUrl.Should().Be("C");
			context.Set<User>().ToList()[2].Interest.Should().Be("C");
			context.Set<User>().ToList()[2].LocationLocationId.Should().Be(1);
			context.Set<User>().ToList()[2].Password.Should().Be("C");
			context.Set<User>().ToList()[2].PhoneNumber.Should().Be("C");
			context.Set<User>().ToList()[2].Privacy.Should().Be("C");
			context.Set<User>().ToList()[2].Username.Should().Be("C");
			context.Set<User>().ToList()[2].Website.Should().Be("C");
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

			var model = new ApiUserClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", 1, "B", "B", "B", "B", "B");
			CreateResponse<ApiUserClientResponseModel> result = await client.UserCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<User>().ToList()[1].BioImgUrl.Should().Be("B");
			context.Set<User>().ToList()[1].Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<User>().ToList()[1].ContentDescription.Should().Be("B");
			context.Set<User>().ToList()[1].Email.Should().Be("B");
			context.Set<User>().ToList()[1].FullName.Should().Be("B");
			context.Set<User>().ToList()[1].HeaderImgUrl.Should().Be("B");
			context.Set<User>().ToList()[1].Interest.Should().Be("B");
			context.Set<User>().ToList()[1].LocationLocationId.Should().Be(1);
			context.Set<User>().ToList()[1].Password.Should().Be("B");
			context.Set<User>().ToList()[1].PhoneNumber.Should().Be("B");
			context.Set<User>().ToList()[1].Privacy.Should().Be("B");
			context.Set<User>().ToList()[1].Username.Should().Be("B");
			context.Set<User>().ToList()[1].Website.Should().Be("B");

			result.Record.BioImgUrl.Should().Be("B");
			result.Record.Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.ContentDescription.Should().Be("B");
			result.Record.Email.Should().Be("B");
			result.Record.FullName.Should().Be("B");
			result.Record.HeaderImgUrl.Should().Be("B");
			result.Record.Interest.Should().Be("B");
			result.Record.LocationLocationId.Should().Be(1);
			result.Record.Password.Should().Be("B");
			result.Record.PhoneNumber.Should().Be("B");
			result.Record.Privacy.Should().Be("B");
			result.Record.Username.Should().Be("B");
			result.Record.Website.Should().Be("B");
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
			var mapper = new ApiUserServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IUserService service = testServer.Host.Services.GetService(typeof(IUserService)) as IUserService;
			ApiUserServerResponseModel model = await service.Get(1);

			ApiUserClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", 1, "B", "B", "B", "B", "B");

			UpdateResponse<ApiUserClientResponseModel> updateResponse = await client.UserUpdateAsync(model.UserId, request);

			context.Entry(context.Set<User>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.UserId.Should().Be(1);
			context.Set<User>().ToList()[0].BioImgUrl.Should().Be("B");
			context.Set<User>().ToList()[0].Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<User>().ToList()[0].ContentDescription.Should().Be("B");
			context.Set<User>().ToList()[0].Email.Should().Be("B");
			context.Set<User>().ToList()[0].FullName.Should().Be("B");
			context.Set<User>().ToList()[0].HeaderImgUrl.Should().Be("B");
			context.Set<User>().ToList()[0].Interest.Should().Be("B");
			context.Set<User>().ToList()[0].LocationLocationId.Should().Be(1);
			context.Set<User>().ToList()[0].Password.Should().Be("B");
			context.Set<User>().ToList()[0].PhoneNumber.Should().Be("B");
			context.Set<User>().ToList()[0].Privacy.Should().Be("B");
			context.Set<User>().ToList()[0].Username.Should().Be("B");
			context.Set<User>().ToList()[0].Website.Should().Be("B");

			updateResponse.Record.UserId.Should().Be(1);
			updateResponse.Record.BioImgUrl.Should().Be("B");
			updateResponse.Record.Birthday.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.ContentDescription.Should().Be("B");
			updateResponse.Record.Email.Should().Be("B");
			updateResponse.Record.FullName.Should().Be("B");
			updateResponse.Record.HeaderImgUrl.Should().Be("B");
			updateResponse.Record.Interest.Should().Be("B");
			updateResponse.Record.LocationLocationId.Should().Be(1);
			updateResponse.Record.Password.Should().Be("B");
			updateResponse.Record.PhoneNumber.Should().Be("B");
			updateResponse.Record.Privacy.Should().Be("B");
			updateResponse.Record.Username.Should().Be("B");
			updateResponse.Record.Website.Should().Be("B");
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

			IUserService service = testServer.Host.Services.GetService(typeof(IUserService)) as IUserService;
			var model = new ApiUserServerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", 1, "B", "B", "B", "B", "B");
			CreateResponse<ApiUserServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.UserDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiUserServerResponseModel verifyResponse = await service.Get(2);

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

			ApiUserClientResponseModel response = await client.UserGetAsync(1);

			response.Should().NotBeNull();
			response.BioImgUrl.Should().Be("A");
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ContentDescription.Should().Be("A");
			response.Email.Should().Be("A");
			response.FullName.Should().Be("A");
			response.HeaderImgUrl.Should().Be("A");
			response.Interest.Should().Be("A");
			response.LocationLocationId.Should().Be(1);
			response.Password.Should().Be("A");
			response.PhoneNumber.Should().Be("A");
			response.Privacy.Should().Be("A");
			response.UserId.Should().Be(1);
			response.Username.Should().Be("A");
			response.Website.Should().Be("A");
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
			ApiUserClientResponseModel response = await client.UserGetAsync(default(int));

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
			List<ApiUserClientResponseModel> response = await client.UserAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].BioImgUrl.Should().Be("A");
			response[0].Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ContentDescription.Should().Be("A");
			response[0].Email.Should().Be("A");
			response[0].FullName.Should().Be("A");
			response[0].HeaderImgUrl.Should().Be("A");
			response[0].Interest.Should().Be("A");
			response[0].LocationLocationId.Should().Be(1);
			response[0].Password.Should().Be("A");
			response[0].PhoneNumber.Should().Be("A");
			response[0].Privacy.Should().Be("A");
			response[0].UserId.Should().Be(1);
			response[0].Username.Should().Be("A");
			response[0].Website.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByLocationLocationIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiUserClientResponseModel> response = await client.ByUserByLocationLocationId(1);

			response.Should().NotBeEmpty();
			response[0].BioImgUrl.Should().Be("A");
			response[0].Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].ContentDescription.Should().Be("A");
			response[0].Email.Should().Be("A");
			response[0].FullName.Should().Be("A");
			response[0].HeaderImgUrl.Should().Be("A");
			response[0].Interest.Should().Be("A");
			response[0].LocationLocationId.Should().Be(1);
			response[0].Password.Should().Be("A");
			response[0].PhoneNumber.Should().Be("A");
			response[0].Privacy.Should().Be("A");
			response[0].UserId.Should().Be(1);
			response[0].Username.Should().Be("A");
			response[0].Website.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByLocationLocationIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiUserClientResponseModel> response = await client.ByUserByLocationLocationId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyDirectTweetsByTaggedUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiDirectTweetClientResponseModel> response = await client.DirectTweetsByTaggedUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyDirectTweetsByTaggedUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiDirectTweetClientResponseModel> response = await client.DirectTweetsByTaggedUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyFollowersByFollowedUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiFollowerClientResponseModel> response = await client.FollowersByFollowedUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyFollowersByFollowedUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiFollowerClientResponseModel> response = await client.FollowersByFollowedUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyFollowersByFollowingUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiFollowerClientResponseModel> response = await client.FollowersByFollowingUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyFollowersByFollowingUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiFollowerClientResponseModel> response = await client.FollowersByFollowingUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyMessagesBySenderUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiMessageClientResponseModel> response = await client.MessagesBySenderUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyMessagesBySenderUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiMessageClientResponseModel> response = await client.MessagesBySenderUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyMessengersByToUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiMessengerClientResponseModel> response = await client.MessengersByToUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyMessengersByToUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiMessengerClientResponseModel> response = await client.MessengersByToUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyMessengersByUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiMessengerClientResponseModel> response = await client.MessengersByUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyMessengersByUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiMessengerClientResponseModel> response = await client.MessengersByUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyQuoteTweetsByRetweeterUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiQuoteTweetClientResponseModel> response = await client.QuoteTweetsByRetweeterUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyQuoteTweetsByRetweeterUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiQuoteTweetClientResponseModel> response = await client.QuoteTweetsByRetweeterUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyRepliesByReplierUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiReplyClientResponseModel> response = await client.RepliesByReplierUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyRepliesByReplierUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiReplyClientResponseModel> response = await client.RepliesByReplierUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyRetweetsByRetwitterUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiRetweetClientResponseModel> response = await client.RetweetsByRetwitterUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyRetweetsByRetwitterUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiRetweetClientResponseModel> response = await client.RetweetsByRetwitterUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTweetsByUserUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTweetClientResponseModel> response = await client.TweetsByUserUserId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTweetsByUserUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTweetClientResponseModel> response = await client.TweetsByUserUserId(default(int));

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
				var result = await client.UserAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>7946c0ee56af1b059e7257c40018219e</Hash>
</Codenesium>*/