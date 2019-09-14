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
	[Trait("Table", "Tag")]
	[Trait("Area", "Integration")]
	public partial class TagIntegrationTests
	{
		public TagIntegrationTests()
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

			var model = new ApiTagClientRequestModel();
			model.SetProperties(2, 1, "B", 1);
			var model2 = new ApiTagClientRequestModel();
			model2.SetProperties(3, 1, "C", 1);
			var request = new List<ApiTagClientRequestModel>() {model, model2};
			CreateResponse<List<ApiTagClientResponseModel>> result = await client.TagBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Tag>().ToList()[1].Count.Should().Be(2);
			context.Set<Tag>().ToList()[1].ExcerptPostId.Should().Be(1);
			context.Set<Tag>().ToList()[1].TagName.Should().Be("B");
			context.Set<Tag>().ToList()[1].WikiPostId.Should().Be(1);

			context.Set<Tag>().ToList()[2].Count.Should().Be(3);
			context.Set<Tag>().ToList()[2].ExcerptPostId.Should().Be(1);
			context.Set<Tag>().ToList()[2].TagName.Should().Be("C");
			context.Set<Tag>().ToList()[2].WikiPostId.Should().Be(1);
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

			var model = new ApiTagClientRequestModel();
			model.SetProperties(2, 1, "B", 1);
			CreateResponse<ApiTagClientResponseModel> result = await client.TagCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Tag>().ToList()[1].Count.Should().Be(2);
			context.Set<Tag>().ToList()[1].ExcerptPostId.Should().Be(1);
			context.Set<Tag>().ToList()[1].TagName.Should().Be("B");
			context.Set<Tag>().ToList()[1].WikiPostId.Should().Be(1);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			var mapper = new ApiTagServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			ITagService service = testServer.Host.Services.GetService(typeof(ITagService)) as ITagService;
			ApiTagServerResponseModel model = await service.Get(1);

			ApiTagClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, 1, "B", 1);

			UpdateResponse<ApiTagClientResponseModel> updateResponse = await client.TagUpdateAsync(model.Id, request);

			context.Entry(context.Set<Tag>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Tag>().ToList()[0].Count.Should().Be(2);
			context.Set<Tag>().ToList()[0].ExcerptPostId.Should().Be(1);
			context.Set<Tag>().ToList()[0].TagName.Should().Be("B");
			context.Set<Tag>().ToList()[0].WikiPostId.Should().Be(1);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

			ITagService service = testServer.Host.Services.GetService(typeof(ITagService)) as ITagService;
			var model = new ApiTagServerRequestModel();
			model.SetProperties(2, 1, "B", 1);
			CreateResponse<ApiTagServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.TagDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiTagServerResponseModel verifyResponse = await service.Get(2);

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

			ApiTagClientResponseModel response = await client.TagGetAsync(1);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			ApiTagClientResponseModel response = await client.TagGetAsync(default(int));

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
			List<ApiTagClientResponseModel> response = await client.TagAllAsync();

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTagClientResponseModel> response = await client.ByTagByExcerptPostId(1);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTagClientResponseModel> response = await client.ByTagByExcerptPostId(default(int));

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTagClientResponseModel> response = await client.ByTagByWikiPostId(1);

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
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTagClientResponseModel> response = await client.ByTagByWikiPostId(default(int));

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
				var result = await client.TagAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>e71fc046bec8343be932a0818ee12342</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/