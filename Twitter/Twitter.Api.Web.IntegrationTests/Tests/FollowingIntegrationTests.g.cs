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
	[Trait("Table", "Following")]
	[Trait("Area", "Integration")]
	public partial class FollowingIntegrationTests
	{
		public FollowingIntegrationTests()
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

			var model = new ApiFollowingClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			var model2 = new ApiFollowingClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), "C");
			var request = new List<ApiFollowingClientRequestModel>() {model, model2};
			CreateResponse<List<ApiFollowingClientResponseModel>> result = await client.FollowingBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Following>().ToList()[1].DateFollowed.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Following>().ToList()[1].Muted.Should().Be("B");

			context.Set<Following>().ToList()[2].DateFollowed.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Following>().ToList()[2].Muted.Should().Be("C");
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

			var model = new ApiFollowingClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiFollowingClientResponseModel> result = await client.FollowingCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Following>().ToList()[1].DateFollowed.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Following>().ToList()[1].Muted.Should().Be("B");

			result.Record.DateFollowed.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
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
			var mapper = new ApiFollowingServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IFollowingService service = testServer.Host.Services.GetService(typeof(IFollowingService)) as IFollowingService;
			ApiFollowingServerResponseModel model = await service.Get(1);

			ApiFollowingClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");

			UpdateResponse<ApiFollowingClientResponseModel> updateResponse = await client.FollowingUpdateAsync(model.UserId, request);

			context.Entry(context.Set<Following>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.UserId.Should().Be(1);
			context.Set<Following>().ToList()[0].DateFollowed.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Following>().ToList()[0].Muted.Should().Be("B");

			updateResponse.Record.UserId.Should().Be(1);
			updateResponse.Record.DateFollowed.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
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
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			IFollowingService service = testServer.Host.Services.GetService(typeof(IFollowingService)) as IFollowingService;
			var model = new ApiFollowingServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiFollowingServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.FollowingDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiFollowingServerResponseModel verifyResponse = await service.Get(2);

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

			ApiFollowingClientResponseModel response = await client.FollowingGetAsync(1);

			response.Should().NotBeNull();
			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
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
			ApiFollowingClientResponseModel response = await client.FollowingGetAsync(default(int));

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

			List<ApiFollowingClientResponseModel> response = await client.FollowingAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Muted.Should().Be("A");
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
				var result = await client.FollowingAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>fd4306dc849955128152ce44a4b4b039</Hash>
</Codenesium>*/