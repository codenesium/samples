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
	[Trait("Table", "Tags")]
	[Trait("Area", "Integration")]
	public partial class TagsIntegrationTests
	{
		public TagsIntegrationTests()
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

			var model = new ApiTagsClientRequestModel();
			model.SetProperties(2, 1, "B", 1);
			var model2 = new ApiTagsClientRequestModel();
			model2.SetProperties(3, 1, "C", 1);
			var request = new List<ApiTagsClientRequestModel>() {model, model2};
			CreateResponse<List<ApiTagsClientResponseModel>> result = await client.TagsBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Tags>().ToList()[1].Count.Should().Be(2);
			context.Set<Tags>().ToList()[1].ExcerptPostId.Should().Be(1);
			context.Set<Tags>().ToList()[1].TagName.Should().Be("B");
			context.Set<Tags>().ToList()[1].WikiPostId.Should().Be(1);

			context.Set<Tags>().ToList()[2].Count.Should().Be(3);
			context.Set<Tags>().ToList()[2].ExcerptPostId.Should().Be(1);
			context.Set<Tags>().ToList()[2].TagName.Should().Be("C");
			context.Set<Tags>().ToList()[2].WikiPostId.Should().Be(1);
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

			var model = new ApiTagsClientRequestModel();
			model.SetProperties(2, 1, "B", 1);
			CreateResponse<ApiTagsClientResponseModel> result = await client.TagsCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Tags>().ToList()[1].Count.Should().Be(2);
			context.Set<Tags>().ToList()[1].ExcerptPostId.Should().Be(1);
			context.Set<Tags>().ToList()[1].TagName.Should().Be("B");
			context.Set<Tags>().ToList()[1].WikiPostId.Should().Be(1);

			result.Record.Count.Should().Be(2);
			result.Record.ExcerptPostId.Should().Be(1);
			result.Record.TagName.Should().Be("B");
			result.Record.WikiPostId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			var mapper = new ApiTagsServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ITagsService service = testServer.Host.Services.GetService(typeof(ITagsService)) as ITagsService;
			ApiTagsServerResponseModel model = await service.Get(1);

			ApiTagsClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, 1, "B", 1);

			UpdateResponse<ApiTagsClientResponseModel> updateResponse = await client.TagsUpdateAsync(model.Id, request);

			context.Entry(context.Set<Tags>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Tags>().ToList()[0].Count.Should().Be(2);
			context.Set<Tags>().ToList()[0].ExcerptPostId.Should().Be(1);
			context.Set<Tags>().ToList()[0].TagName.Should().Be("B");
			context.Set<Tags>().ToList()[0].WikiPostId.Should().Be(1);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.Count.Should().Be(2);
			updateResponse.Record.ExcerptPostId.Should().Be(1);
			updateResponse.Record.TagName.Should().Be("B");
			updateResponse.Record.WikiPostId.Should().Be(1);
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

			ITagsService service = testServer.Host.Services.GetService(typeof(ITagsService)) as ITagsService;
			var model = new ApiTagsServerRequestModel();
			model.SetProperties(2, 1, "B", 1);
			CreateResponse<ApiTagsServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.TagsDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiTagsServerResponseModel verifyResponse = await service.Get(2);

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

			ApiTagsClientResponseModel response = await client.TagsGetAsync(1);

			response.Should().NotBeNull();
			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.Id.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestGetNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiTagsClientResponseModel response = await client.TagsGetAsync(default(int));

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

			List<ApiTagsClientResponseModel> response = await client.TagsAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].Count.Should().Be(1);
			response[0].ExcerptPostId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].TagName.Should().Be("A");
			response[0].WikiPostId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByExcerptPostIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiTagsClientResponseModel> response = await client.ByTagsByExcerptPostId(1);

			response.Should().NotBeEmpty();
			response[0].Count.Should().Be(1);
			response[0].ExcerptPostId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].TagName.Should().Be("A");
			response[0].WikiPostId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByExcerptPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiTagsClientResponseModel> response = await client.ByTagsByExcerptPostId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByWikiPostIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiTagsClientResponseModel> response = await client.ByTagsByWikiPostId(1);

			response.Should().NotBeEmpty();
			response[0].Count.Should().Be(1);
			response[0].ExcerptPostId.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].TagName.Should().Be("A");
			response[0].WikiPostId.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByWikiPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			List<ApiTagsClientResponseModel> response = await client.ByTagsByWikiPostId(default(int));

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
				var result = await client.TagsAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>ed9f3bd4c57ada4f757bd8f8b95e4765</Hash>
</Codenesium>*/