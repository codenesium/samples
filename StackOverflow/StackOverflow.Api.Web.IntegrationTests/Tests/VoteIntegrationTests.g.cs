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
	[Trait("Table", "Vote")]
	[Trait("Area", "Integration")]
	public partial class VoteIntegrationTests
	{
		public VoteIntegrationTests()
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

			var model = new ApiVoteClientRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			var model2 = new ApiVoteClientRequestModel();
			model2.SetProperties(3, DateTime.Parse("1/1/1989 12:00:00 AM"), 3, 3, 3);
			var request = new List<ApiVoteClientRequestModel>() {model, model2};
			CreateResponse<List<ApiVoteClientResponseModel>> result = await client.VoteBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Vote>().ToList()[1].BountyAmount.Should().Be(2);
			context.Set<Vote>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Vote>().ToList()[1].PostId.Should().Be(2);
			context.Set<Vote>().ToList()[1].UserId.Should().Be(2);
			context.Set<Vote>().ToList()[1].VoteTypeId.Should().Be(2);

			context.Set<Vote>().ToList()[2].BountyAmount.Should().Be(3);
			context.Set<Vote>().ToList()[2].CreationDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Vote>().ToList()[2].PostId.Should().Be(3);
			context.Set<Vote>().ToList()[2].UserId.Should().Be(3);
			context.Set<Vote>().ToList()[2].VoteTypeId.Should().Be(3);
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

			var model = new ApiVoteClientRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiVoteClientResponseModel> result = await client.VoteCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Vote>().ToList()[1].BountyAmount.Should().Be(2);
			context.Set<Vote>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Vote>().ToList()[1].PostId.Should().Be(2);
			context.Set<Vote>().ToList()[1].UserId.Should().Be(2);
			context.Set<Vote>().ToList()[1].VoteTypeId.Should().Be(2);

			result.Record.BountyAmount.Should().Be(2);
			result.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.PostId.Should().Be(2);
			result.Record.UserId.Should().Be(2);
			result.Record.VoteTypeId.Should().Be(2);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiVoteServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IVoteService service = testServer.Host.Services.GetService(typeof(IVoteService)) as IVoteService;
			ApiVoteServerResponseModel model = await service.Get(1);

			ApiVoteClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);

			UpdateResponse<ApiVoteClientResponseModel> updateResponse = await client.VoteUpdateAsync(model.Id, request);

			context.Entry(context.Set<Vote>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Vote>().ToList()[0].BountyAmount.Should().Be(2);
			context.Set<Vote>().ToList()[0].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Vote>().ToList()[0].PostId.Should().Be(2);
			context.Set<Vote>().ToList()[0].UserId.Should().Be(2);
			context.Set<Vote>().ToList()[0].VoteTypeId.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.BountyAmount.Should().Be(2);
			updateResponse.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.PostId.Should().Be(2);
			updateResponse.Record.UserId.Should().Be(2);
			updateResponse.Record.VoteTypeId.Should().Be(2);
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

			IVoteService service = testServer.Host.Services.GetService(typeof(IVoteService)) as IVoteService;
			var model = new ApiVoteServerRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiVoteServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.VoteDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiVoteServerResponseModel verifyResponse = await service.Get(2);

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

			ApiVoteClientResponseModel response = await client.VoteGetAsync(1);

			response.Should().NotBeNull();
			response.BountyAmount.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostId.Should().Be(1);
			response.UserId.Should().Be(1);
			response.VoteTypeId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiVoteClientResponseModel response = await client.VoteGetAsync(default(int));

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

			List<ApiVoteClientResponseModel> response = await client.VoteAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].BountyAmount.Should().Be(1);
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].UserId.Should().Be(1);
			response[0].VoteTypeId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiVoteClientResponseModel> response = await client.ByVoteByUserId(1);

			response.Should().NotBeEmpty();
			response[0].BountyAmount.Should().Be(1);
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].UserId.Should().Be(1);
			response[0].VoteTypeId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiVoteClientResponseModel> response = await client.ByVoteByUserId(default(int));

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
				var result = await client.VoteAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>ea31d7aa22a453ce7550d5c21e36eceb</Hash>
</Codenesium>*/