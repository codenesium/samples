using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using SecureVideoCRMNS.Api.Client;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using SecureVideoCRMNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SecureVideoCRMNS.Api.Web.IntegrationTests
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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			var model = new ApiUserClientRequestModel();
			model.SetProperties("B", "B", 1);
			var model2 = new ApiUserClientRequestModel();
			model2.SetProperties("C", "C", 1);
			var request = new List<ApiUserClientRequestModel>() {model, model2};
			CreateResponse<List<ApiUserClientResponseModel>> result = await client.UserBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<User>().ToList()[1].Email.Should().Be("B");
			context.Set<User>().ToList()[1].Password.Should().Be("B");
			context.Set<User>().ToList()[1].SubscriptionId.Should().Be(1);

			context.Set<User>().ToList()[2].Email.Should().Be("C");
			context.Set<User>().ToList()[2].Password.Should().Be("C");
			context.Set<User>().ToList()[2].SubscriptionId.Should().Be(1);
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

			var model = new ApiUserClientRequestModel();
			model.SetProperties("B", "B", 1);
			CreateResponse<ApiUserClientResponseModel> result = await client.UserCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<User>().ToList()[1].Email.Should().Be("B");
			context.Set<User>().ToList()[1].Password.Should().Be("B");
			context.Set<User>().ToList()[1].SubscriptionId.Should().Be(1);

			result.Record.Email.Should().Be("B");
			result.Record.Password.Should().Be("B");
			result.Record.SubscriptionId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiUserServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IUserService service = testServer.Host.Services.GetService(typeof(IUserService)) as IUserService;
			ApiUserServerResponseModel model = await service.Get(1);

			ApiUserClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties("B", "B", 1);

			UpdateResponse<ApiUserClientResponseModel> updateResponse = await client.UserUpdateAsync(model.Id, request);

			context.Entry(context.Set<User>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<User>().ToList()[0].Email.Should().Be("B");
			context.Set<User>().ToList()[0].Password.Should().Be("B");
			context.Set<User>().ToList()[0].SubscriptionId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Email.Should().Be("B");
			updateResponse.Record.Password.Should().Be("B");
			updateResponse.Record.SubscriptionId.Should().Be(1);
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

			IUserService service = testServer.Host.Services.GetService(typeof(IUserService)) as IUserService;
			var model = new ApiUserServerRequestModel();
			model.SetProperties("B", "B", 1);
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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ApiUserClientResponseModel response = await client.UserGetAsync(1);

			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.Id.Should().Be(1);
			response.Password.Should().Be("A");
			response.SubscriptionId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
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

			List<ApiUserClientResponseModel> response = await client.UserAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Email.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Password.Should().Be("A");
			response[0].SubscriptionId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestBySubscriptionIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiUserClientResponseModel> response = await client.ByUserBySubscriptionId(1);

			response.Should().NotBeEmpty();
			response[0].Email.Should().Be("A");
			response[0].Id.Should().Be(1);
			response[0].Password.Should().Be("A");
			response[0].SubscriptionId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestBySubscriptionIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiUserClientResponseModel> response = await client.ByUserBySubscriptionId(default(int));

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
    <Hash>56f2e87f67600058d09ccd960030c7c0</Hash>
</Codenesium>*/