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
	[Trait("Table", "Follower")]
	[Trait("Area", "Integration")]
	public partial class FollowerIntegrationTests
	{
		public FollowerIntegrationTests()
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

			var model = new ApiFollowerClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B");
			var model2 = new ApiFollowerClientRequestModel();
			model2.SetProperties("C", DateTime.Parse("1/1/1989 12:00:00 AM"), 1, 1, "C", "C");
			var request = new List<ApiFollowerClientRequestModel>() {model, model2};
			CreateResponse<List<ApiFollowerClientResponseModel>> result = await client.FollowerBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Follower>().ToList()[1].Blocked.Should().Be("B");
			context.Set<Follower>().ToList()[1].DateFollowed.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Follower>().ToList()[1].FollowedUserId.Should().Be(1);
			context.Set<Follower>().ToList()[1].FollowingUserId.Should().Be(1);
			context.Set<Follower>().ToList()[1].FollowRequestStatu.Should().Be("B");
			context.Set<Follower>().ToList()[1].Muted.Should().Be("B");

			context.Set<Follower>().ToList()[2].Blocked.Should().Be("C");
			context.Set<Follower>().ToList()[2].DateFollowed.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Follower>().ToList()[2].FollowedUserId.Should().Be(1);
			context.Set<Follower>().ToList()[2].FollowingUserId.Should().Be(1);
			context.Set<Follower>().ToList()[2].FollowRequestStatu.Should().Be("C");
			context.Set<Follower>().ToList()[2].Muted.Should().Be("C");
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

			var model = new ApiFollowerClientRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B");
			CreateResponse<ApiFollowerClientResponseModel> result = await client.FollowerCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Follower>().ToList()[1].Blocked.Should().Be("B");
			context.Set<Follower>().ToList()[1].DateFollowed.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Follower>().ToList()[1].FollowedUserId.Should().Be(1);
			context.Set<Follower>().ToList()[1].FollowingUserId.Should().Be(1);
			context.Set<Follower>().ToList()[1].FollowRequestStatu.Should().Be("B");
			context.Set<Follower>().ToList()[1].Muted.Should().Be("B");

			result.Record.Blocked.Should().Be("B");
			result.Record.DateFollowed.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.FollowedUserId.Should().Be(1);
			result.Record.FollowingUserId.Should().Be(1);
			result.Record.FollowRequestStatu.Should().Be("B");
			result.Record.Muted.Should().Be("B");
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
			var mapper = new ApiFollowerServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IFollowerService service = testServer.Host.Services.GetService(typeof(IFollowerService)) as IFollowerService;
			ApiFollowerServerResponseModel model = await service.Get(1);

			ApiFollowerClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B");

			UpdateResponse<ApiFollowerClientResponseModel> updateResponse = await client.FollowerUpdateAsync(model.Id, request);

			context.Entry(context.Set<Follower>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Follower>().ToList()[0].Blocked.Should().Be("B");
			context.Set<Follower>().ToList()[0].DateFollowed.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Follower>().ToList()[0].FollowedUserId.Should().Be(1);
			context.Set<Follower>().ToList()[0].FollowingUserId.Should().Be(1);
			context.Set<Follower>().ToList()[0].FollowRequestStatu.Should().Be("B");
			context.Set<Follower>().ToList()[0].Muted.Should().Be("B");

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Blocked.Should().Be("B");
			updateResponse.Record.DateFollowed.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.FollowedUserId.Should().Be(1);
			updateResponse.Record.FollowingUserId.Should().Be(1);
			updateResponse.Record.FollowRequestStatu.Should().Be("B");
			updateResponse.Record.Muted.Should().Be("B");
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

			IFollowerService service = testServer.Host.Services.GetService(typeof(IFollowerService)) as IFollowerService;
			var model = new ApiFollowerServerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, "B", "B");
			CreateResponse<ApiFollowerServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.FollowerDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiFollowerServerResponseModel verifyResponse = await service.Get(2);

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

			ApiFollowerClientResponseModel response = await client.FollowerGetAsync(1);

			response.Should().NotBeNull();
			response.Blocked.Should().Be("A");
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FollowedUserId.Should().Be(1);
			response.FollowingUserId.Should().Be(1);
			response.FollowRequestStatu.Should().Be("A");
			response.Id.Should().Be(1);
			response.Muted.Should().Be("A");
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
			ApiFollowerClientResponseModel response = await client.FollowerGetAsync(default(int));

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
			List<ApiFollowerClientResponseModel> response = await client.FollowerAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Blocked.Should().Be("A");
			response[0].DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FollowedUserId.Should().Be(1);
			response[0].FollowingUserId.Should().Be(1);
			response[0].FollowRequestStatu.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Muted.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByFollowedUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiFollowerClientResponseModel> response = await client.ByFollowerByFollowedUserId(1);

			response.Should().NotBeEmpty();
			response[0].Blocked.Should().Be("A");
			response[0].DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FollowedUserId.Should().Be(1);
			response[0].FollowingUserId.Should().Be(1);
			response[0].FollowRequestStatu.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Muted.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByFollowedUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiFollowerClientResponseModel> response = await client.ByFollowerByFollowedUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByFollowingUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiFollowerClientResponseModel> response = await client.ByFollowerByFollowingUserId(1);

			response.Should().NotBeEmpty();
			response[0].Blocked.Should().Be("A");
			response[0].DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FollowedUserId.Should().Be(1);
			response[0].FollowingUserId.Should().Be(1);
			response[0].FollowRequestStatu.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Muted.Should().Be("A");
		}

		[Fact]
		public virtual async void TestByFollowingUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiFollowerClientResponseModel> response = await client.ByFollowerByFollowingUserId(default(int));

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
				var result = await client.FollowerAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>daabbcf9366205aee1faeaa11a9bcae9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/