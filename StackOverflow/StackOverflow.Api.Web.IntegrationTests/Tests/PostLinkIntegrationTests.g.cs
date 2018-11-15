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
	[Trait("Table", "PostLink")]
	[Trait("Area", "Integration")]
	public partial class PostLinkIntegrationTests
	{
		public PostLinkIntegrationTests()
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

			var model = new ApiPostLinkClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			var model2 = new ApiPostLinkClientRequestModel();
			model2.SetProperties(DateTime.Parse("1/1/1989 12:00:00 AM"), 3, 3, 3);
			var request = new List<ApiPostLinkClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPostLinkClientResponseModel>> result = await client.PostLinkBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<PostLink>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PostLink>().ToList()[1].LinkTypeId.Should().Be(2);
			context.Set<PostLink>().ToList()[1].PostId.Should().Be(2);
			context.Set<PostLink>().ToList()[1].RelatedPostId.Should().Be(2);

			context.Set<PostLink>().ToList()[2].CreationDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<PostLink>().ToList()[2].LinkTypeId.Should().Be(3);
			context.Set<PostLink>().ToList()[2].PostId.Should().Be(3);
			context.Set<PostLink>().ToList()[2].RelatedPostId.Should().Be(3);
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

			var model = new ApiPostLinkClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiPostLinkClientResponseModel> result = await client.PostLinkCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<PostLink>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PostLink>().ToList()[1].LinkTypeId.Should().Be(2);
			context.Set<PostLink>().ToList()[1].PostId.Should().Be(2);
			context.Set<PostLink>().ToList()[1].RelatedPostId.Should().Be(2);

			result.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.LinkTypeId.Should().Be(2);
			result.Record.PostId.Should().Be(2);
			result.Record.RelatedPostId.Should().Be(2);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiPostLinkServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPostLinkService service = testServer.Host.Services.GetService(typeof(IPostLinkService)) as IPostLinkService;
			ApiPostLinkServerResponseModel model = await service.Get(1);

			ApiPostLinkClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);

			UpdateResponse<ApiPostLinkClientResponseModel> updateResponse = await client.PostLinkUpdateAsync(model.Id, request);

			context.Entry(context.Set<PostLink>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<PostLink>().ToList()[0].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<PostLink>().ToList()[0].LinkTypeId.Should().Be(2);
			context.Set<PostLink>().ToList()[0].PostId.Should().Be(2);
			context.Set<PostLink>().ToList()[0].RelatedPostId.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.LinkTypeId.Should().Be(2);
			updateResponse.Record.PostId.Should().Be(2);
			updateResponse.Record.RelatedPostId.Should().Be(2);
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

			IPostLinkService service = testServer.Host.Services.GetService(typeof(IPostLinkService)) as IPostLinkService;
			var model = new ApiPostLinkServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiPostLinkServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PostLinkDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPostLinkServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPostLinkClientResponseModel response = await client.PostLinkGetAsync(1);

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
			ApiPostLinkClientResponseModel response = await client.PostLinkGetAsync(default(int));

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

			List<ApiPostLinkClientResponseModel> response = await client.PostLinkAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].Id.Should().Be(1);
			response[0].LinkTypeId.Should().Be(1);
			response[0].PostId.Should().Be(1);
			response[0].RelatedPostId.Should().Be(1);
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
				var result = await client.PostLinkAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>c225ea774fcf46986278fdf5e5bd1f11</Hash>
</Codenesium>*/