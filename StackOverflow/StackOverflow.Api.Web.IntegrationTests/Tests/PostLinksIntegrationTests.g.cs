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
	[Trait("Table", "PostLinks")]
	[Trait("Area", "Integration")]
	public partial class PostLinksIntegrationTests
	{
		public PostLinksIntegrationTests()
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

			var model = new ApiPostLinksClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, 1);
			var model2 = new ApiPostLinksClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), 1, 1, 1);
			var request = new List<ApiPostLinksClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPostLinksClientResponseModel>> result = await client.PostLinksBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<PostLinks>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PostLinks>().ToList()[1].LinkTypeId.Should().Be(1);
			context.Set<PostLinks>().ToList()[1].PostId.Should().Be(1);
			context.Set<PostLinks>().ToList()[1].RelatedPostId.Should().Be(1);

			context.Set<PostLinks>().ToList()[2].CreationDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<PostLinks>().ToList()[2].LinkTypeId.Should().Be(1);
			context.Set<PostLinks>().ToList()[2].PostId.Should().Be(1);
			context.Set<PostLinks>().ToList()[2].RelatedPostId.Should().Be(1);
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

			var model = new ApiPostLinksClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, 1);
			CreateResponse<ApiPostLinksClientResponseModel> result = await client.PostLinksCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<PostLinks>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PostLinks>().ToList()[1].LinkTypeId.Should().Be(1);
			context.Set<PostLinks>().ToList()[1].PostId.Should().Be(1);
			context.Set<PostLinks>().ToList()[1].RelatedPostId.Should().Be(1);

			result.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.LinkTypeId.Should().Be(1);
			result.Record.PostId.Should().Be(1);
			result.Record.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiPostLinksServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPostLinksService service = testServer.Host.Services.GetService(typeof(IPostLinksService)) as IPostLinksService;
			ApiPostLinksServerResponseModel model = await service.Get(1);

			ApiPostLinksClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, 1);

			UpdateResponse<ApiPostLinksClientResponseModel> updateResponse = await client.PostLinksUpdateAsync(model.Id, request);

			context.Entry(context.Set<PostLinks>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<PostLinks>().ToList()[0].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PostLinks>().ToList()[0].LinkTypeId.Should().Be(1);
			context.Set<PostLinks>().ToList()[0].PostId.Should().Be(1);
			context.Set<PostLinks>().ToList()[0].RelatedPostId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.LinkTypeId.Should().Be(1);
			updateResponse.Record.PostId.Should().Be(1);
			updateResponse.Record.RelatedPostId.Should().Be(1);
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

			IPostLinksService service = testServer.Host.Services.GetService(typeof(IPostLinksService)) as IPostLinksService;
			var model = new ApiPostLinksServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, 1);
			CreateResponse<ApiPostLinksServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PostLinksDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPostLinksServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPostLinksClientResponseModel response = await client.PostLinksGetAsync(1);

			response.Should().NotBeNull();
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiPostLinksClientResponseModel response = await client.PostLinksGetAsync(default(int));

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

			List<ApiPostLinksClientResponseModel> response = await client.PostLinksAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].LinkTypeId.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].RelatedPostId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByLinkTypeIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPostLinksClientResponseModel> response = await client.ByPostLinksByLinkTypeId(1);

			response.Should().NotBeEmpty();
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].LinkTypeId.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].RelatedPostId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByLinkTypeIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPostLinksClientResponseModel> response = await client.ByPostLinksByLinkTypeId(default(int));

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
			List<ApiPostLinksClientResponseModel> response = await client.ByPostLinksByPostId(1);

			response.Should().NotBeEmpty();
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].LinkTypeId.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].RelatedPostId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPostLinksClientResponseModel> response = await client.ByPostLinksByPostId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByRelatedPostIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPostLinksClientResponseModel> response = await client.ByPostLinksByRelatedPostId(1);

			response.Should().NotBeEmpty();
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].LinkTypeId.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].RelatedPostId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByRelatedPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiPostLinksClientResponseModel> response = await client.ByPostLinksByRelatedPostId(default(int));

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
				var result = await client.PostLinksAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>b6b710b358f5adc74a23c8c21a30497e</Hash>
</Codenesium>*/