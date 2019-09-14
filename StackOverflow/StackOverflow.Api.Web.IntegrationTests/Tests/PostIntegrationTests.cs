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
	[Trait("Table", "Post")]
	[Trait("Area", "Integration")]
	public partial class PostIntegrationTests
	{
		public PostIntegrationTests()
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

			var model = new ApiPostClientRequestModel();
			model.SetProperties(2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, 1, 1, 2, "B", "B", 2);
			var model2 = new ApiPostClientRequestModel();
			model2.SetProperties(3, 3, "C", DateTime.Parse("1/1/1989 12:00:00 AM"), 3, DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), 3, DateTime.Parse("1/1/1989 12:00:00 AM"), DateTime.Parse("1/1/1989 12:00:00 AM"), "C", 1, 1, 1, 1, 3, "C", "C", 3);
			var request = new List<ApiPostClientRequestModel>() {model, model2};
			CreateResponse<List<ApiPostClientResponseModel>> result = await client.PostBulkInsertAsync(request);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();

			context.Set<Post>().ToList()[1].AcceptedAnswerId.Should().Be(2);
			context.Set<Post>().ToList()[1].AnswerCount.Should().Be(2);
			context.Set<Post>().ToList()[1].Body.Should().Be("B");
			context.Set<Post>().ToList()[1].ClosedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[1].CommentCount.Should().Be(2);
			context.Set<Post>().ToList()[1].CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[1].FavoriteCount.Should().Be(2);
			context.Set<Post>().ToList()[1].LastActivityDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[1].LastEditDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[1].LastEditorDisplayName.Should().Be("B");
			context.Set<Post>().ToList()[1].LastEditorUserId.Should().Be(1);
			context.Set<Post>().ToList()[1].OwnerUserId.Should().Be(1);
			context.Set<Post>().ToList()[1].ParentId.Should().Be(1);
			context.Set<Post>().ToList()[1].PostTypeId.Should().Be(1);
			context.Set<Post>().ToList()[1].Score.Should().Be(2);
			context.Set<Post>().ToList()[1].Tag.Should().Be("B");
			context.Set<Post>().ToList()[1].Title.Should().Be("B");
			context.Set<Post>().ToList()[1].ViewCount.Should().Be(2);

			context.Set<Post>().ToList()[2].AcceptedAnswerId.Should().Be(3);
			context.Set<Post>().ToList()[2].AnswerCount.Should().Be(3);
			context.Set<Post>().ToList()[2].Body.Should().Be("C");
			context.Set<Post>().ToList()[2].ClosedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Post>().ToList()[2].CommentCount.Should().Be(3);
			context.Set<Post>().ToList()[2].CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Post>().ToList()[2].CreationDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Post>().ToList()[2].FavoriteCount.Should().Be(3);
			context.Set<Post>().ToList()[2].LastActivityDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Post>().ToList()[2].LastEditDate.Should().Be(DateTime.Parse("1/1/1989 12:00:00 AM"));
			context.Set<Post>().ToList()[2].LastEditorDisplayName.Should().Be("C");
			context.Set<Post>().ToList()[2].LastEditorUserId.Should().Be(1);
			context.Set<Post>().ToList()[2].OwnerUserId.Should().Be(1);
			context.Set<Post>().ToList()[2].ParentId.Should().Be(1);
			context.Set<Post>().ToList()[2].PostTypeId.Should().Be(1);
			context.Set<Post>().ToList()[2].Score.Should().Be(3);
			context.Set<Post>().ToList()[2].Tag.Should().Be("C");
			context.Set<Post>().ToList()[2].Title.Should().Be("C");
			context.Set<Post>().ToList()[2].ViewCount.Should().Be(3);
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

			var model = new ApiPostClientRequestModel();
			model.SetProperties(2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, 1, 1, 2, "B", "B", 2);
			CreateResponse<ApiPostClientResponseModel> result = await client.PostCreateAsync(model);

			result.Success.Should().BeTrue();
			result.Record.Should().NotBeNull();
			context.Set<Post>().ToList()[1].AcceptedAnswerId.Should().Be(2);
			context.Set<Post>().ToList()[1].AnswerCount.Should().Be(2);
			context.Set<Post>().ToList()[1].Body.Should().Be("B");
			context.Set<Post>().ToList()[1].ClosedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[1].CommentCount.Should().Be(2);
			context.Set<Post>().ToList()[1].CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[1].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[1].FavoriteCount.Should().Be(2);
			context.Set<Post>().ToList()[1].LastActivityDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[1].LastEditDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[1].LastEditorDisplayName.Should().Be("B");
			context.Set<Post>().ToList()[1].LastEditorUserId.Should().Be(1);
			context.Set<Post>().ToList()[1].OwnerUserId.Should().Be(1);
			context.Set<Post>().ToList()[1].ParentId.Should().Be(1);
			context.Set<Post>().ToList()[1].PostTypeId.Should().Be(1);
			context.Set<Post>().ToList()[1].Score.Should().Be(2);
			context.Set<Post>().ToList()[1].Tag.Should().Be("B");
			context.Set<Post>().ToList()[1].Title.Should().Be("B");
			context.Set<Post>().ToList()[1].ViewCount.Should().Be(2);

			result.Record.AcceptedAnswerId.Should().Be(2);
			result.Record.AnswerCount.Should().Be(2);
			result.Record.Body.Should().Be("B");
			result.Record.ClosedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.CommentCount.Should().Be(2);
			result.Record.CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.FavoriteCount.Should().Be(2);
			result.Record.LastActivityDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.LastEditDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			result.Record.LastEditorDisplayName.Should().Be("B");
			result.Record.LastEditorUserId.Should().Be(1);
			result.Record.OwnerUserId.Should().Be(1);
			result.Record.ParentId.Should().Be(1);
			result.Record.PostTypeId.Should().Be(1);
			result.Record.Score.Should().Be(2);
			result.Record.Tag.Should().Be("B");
			result.Record.Title.Should().Be("B");
			result.Record.ViewCount.Should().Be(2);
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
			var mapper = new ApiPostServerModelMapper();
			ApplicationDbContext context = testServer.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
			IPostService service = testServer.Host.Services.GetService(typeof(IPostService)) as IPostService;
			ApiPostServerResponseModel model = await service.Get(1);

			ApiPostClientRequestModel request = mapper.MapServerResponseToClientRequest(model);
			request.SetProperties(2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, 1, 1, 2, "B", "B", 2);

			UpdateResponse<ApiPostClientResponseModel> updateResponse = await client.PostUpdateAsync(model.Id, request);

			context.Entry(context.Set<Post>().ToList()[0]).Reload();
			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
			updateResponse.Record.Id.Should().Be(1);
			context.Set<Post>().ToList()[0].AcceptedAnswerId.Should().Be(2);
			context.Set<Post>().ToList()[0].AnswerCount.Should().Be(2);
			context.Set<Post>().ToList()[0].Body.Should().Be("B");
			context.Set<Post>().ToList()[0].ClosedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[0].CommentCount.Should().Be(2);
			context.Set<Post>().ToList()[0].CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[0].CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[0].FavoriteCount.Should().Be(2);
			context.Set<Post>().ToList()[0].LastActivityDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[0].LastEditDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			context.Set<Post>().ToList()[0].LastEditorDisplayName.Should().Be("B");
			context.Set<Post>().ToList()[0].LastEditorUserId.Should().Be(1);
			context.Set<Post>().ToList()[0].OwnerUserId.Should().Be(1);
			context.Set<Post>().ToList()[0].ParentId.Should().Be(1);
			context.Set<Post>().ToList()[0].PostTypeId.Should().Be(1);
			context.Set<Post>().ToList()[0].Score.Should().Be(2);
			context.Set<Post>().ToList()[0].Tag.Should().Be("B");
			context.Set<Post>().ToList()[0].Title.Should().Be("B");
			context.Set<Post>().ToList()[0].ViewCount.Should().Be(2);

			updateResponse.Record.Id.Should().Be(1);
			updateResponse.Record.AcceptedAnswerId.Should().Be(2);
			updateResponse.Record.AnswerCount.Should().Be(2);
			updateResponse.Record.Body.Should().Be("B");
			updateResponse.Record.ClosedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.CommentCount.Should().Be(2);
			updateResponse.Record.CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.CreationDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.FavoriteCount.Should().Be(2);
			updateResponse.Record.LastActivityDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.LastEditDate.Should().Be(DateTime.Parse("1/1/1988 12:00:00 AM"));
			updateResponse.Record.LastEditorDisplayName.Should().Be("B");
			updateResponse.Record.LastEditorUserId.Should().Be(1);
			updateResponse.Record.OwnerUserId.Should().Be(1);
			updateResponse.Record.ParentId.Should().Be(1);
			updateResponse.Record.PostTypeId.Should().Be(1);
			updateResponse.Record.Score.Should().Be(2);
			updateResponse.Record.Tag.Should().Be("B");
			updateResponse.Record.Title.Should().Be("B");
			updateResponse.Record.ViewCount.Should().Be(2);
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

			IPostService service = testServer.Host.Services.GetService(typeof(IPostService)) as IPostService;
			var model = new ApiPostServerRequestModel();
			model.SetProperties(2, 2, "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, 1, 1, 2, "B", "B", 2);
			CreateResponse<ApiPostServerResponseModel> createdResponse = await service.Create(model);

			createdResponse.Success.Should().BeTrue();

			ActionResponse deleteResult = await client.PostDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();
			ApiPostServerResponseModel verifyResponse = await service.Get(2);

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

			ApiPostClientResponseModel response = await client.PostGetAsync(1);

			response.Should().NotBeNull();
			response.AcceptedAnswerId.Should().Be(1);
			response.AnswerCount.Should().Be(1);
			response.Body.Should().Be("A");
			response.ClosedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CommentCount.Should().Be(1);
			response.CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FavoriteCount.Should().Be(1);
			response.Id.Should().Be(1);
			response.LastActivityDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LastEditDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LastEditorDisplayName.Should().Be("A");
			response.LastEditorUserId.Should().Be(1);
			response.OwnerUserId.Should().Be(1);
			response.ParentId.Should().Be(1);
			response.PostTypeId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Tag.Should().Be("A");
			response.Title.Should().Be("A");
			response.ViewCount.Should().Be(1);
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
			ApiPostClientResponseModel response = await client.PostGetAsync(default(int));

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
			List<ApiPostClientResponseModel> response = await client.PostAllAsync();

			response.Count.Should().BeGreaterThan(0);
			response[0].AcceptedAnswerId.Should().Be(1);
			response[0].AnswerCount.Should().Be(1);
			response[0].Body.Should().Be("A");
			response[0].ClosedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].CommentCount.Should().Be(1);
			response[0].CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FavoriteCount.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].LastActivityDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LastEditDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LastEditorDisplayName.Should().Be("A");
			response[0].LastEditorUserId.Should().Be(1);
			response[0].OwnerUserId.Should().Be(1);
			response[0].ParentId.Should().Be(1);
			response[0].PostTypeId.Should().Be(1);
			response[0].Score.Should().Be(1);
			response[0].Tag.Should().Be("A");
			response[0].Title.Should().Be("A");
			response[0].ViewCount.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByOwnerUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostClientResponseModel> response = await client.ByPostByOwnerUserId(1);

			response.Should().NotBeEmpty();
			response[0].AcceptedAnswerId.Should().Be(1);
			response[0].AnswerCount.Should().Be(1);
			response[0].Body.Should().Be("A");
			response[0].ClosedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].CommentCount.Should().Be(1);
			response[0].CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FavoriteCount.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].LastActivityDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LastEditDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LastEditorDisplayName.Should().Be("A");
			response[0].LastEditorUserId.Should().Be(1);
			response[0].OwnerUserId.Should().Be(1);
			response[0].ParentId.Should().Be(1);
			response[0].PostTypeId.Should().Be(1);
			response[0].Score.Should().Be(1);
			response[0].Tag.Should().Be("A");
			response[0].Title.Should().Be("A");
			response[0].ViewCount.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByOwnerUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostClientResponseModel> response = await client.ByPostByOwnerUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByLastEditorUserIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostClientResponseModel> response = await client.ByPostByLastEditorUserId(1);

			response.Should().NotBeEmpty();
			response[0].AcceptedAnswerId.Should().Be(1);
			response[0].AnswerCount.Should().Be(1);
			response[0].Body.Should().Be("A");
			response[0].ClosedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].CommentCount.Should().Be(1);
			response[0].CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FavoriteCount.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].LastActivityDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LastEditDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LastEditorDisplayName.Should().Be("A");
			response[0].LastEditorUserId.Should().Be(1);
			response[0].OwnerUserId.Should().Be(1);
			response[0].ParentId.Should().Be(1);
			response[0].PostTypeId.Should().Be(1);
			response[0].Score.Should().Be(1);
			response[0].Tag.Should().Be("A");
			response[0].Title.Should().Be("A");
			response[0].ViewCount.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByLastEditorUserIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostClientResponseModel> response = await client.ByPostByLastEditorUserId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByPostTypeIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostClientResponseModel> response = await client.ByPostByPostTypeId(1);

			response.Should().NotBeEmpty();
			response[0].AcceptedAnswerId.Should().Be(1);
			response[0].AnswerCount.Should().Be(1);
			response[0].Body.Should().Be("A");
			response[0].ClosedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].CommentCount.Should().Be(1);
			response[0].CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FavoriteCount.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].LastActivityDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LastEditDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LastEditorDisplayName.Should().Be("A");
			response[0].LastEditorUserId.Should().Be(1);
			response[0].OwnerUserId.Should().Be(1);
			response[0].ParentId.Should().Be(1);
			response[0].PostTypeId.Should().Be(1);
			response[0].Score.Should().Be(1);
			response[0].Tag.Should().Be("A");
			response[0].Title.Should().Be("A");
			response[0].ViewCount.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByPostTypeIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostClientResponseModel> response = await client.ByPostByPostTypeId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestByParentIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostClientResponseModel> response = await client.ByPostByParentId(1);

			response.Should().NotBeEmpty();
			response[0].AcceptedAnswerId.Should().Be(1);
			response[0].AnswerCount.Should().Be(1);
			response[0].Body.Should().Be("A");
			response[0].ClosedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].CommentCount.Should().Be(1);
			response[0].CommunityOwnedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].FavoriteCount.Should().Be(1);
			response[0].Id.Should().Be(1);
			response[0].LastActivityDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LastEditDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response[0].LastEditorDisplayName.Should().Be("A");
			response[0].LastEditorUserId.Should().Be(1);
			response[0].OwnerUserId.Should().Be(1);
			response[0].ParentId.Should().Be(1);
			response[0].PostTypeId.Should().Be(1);
			response[0].Score.Should().Be(1);
			response[0].Tag.Should().Be("A");
			response[0].Title.Should().Be("A");
			response[0].ViewCount.Should().Be(1);
		}

		[Fact]
		public virtual async void TestByParentIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostClientResponseModel> response = await client.ByPostByParentId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyCommentsByPostIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiCommentClientResponseModel> response = await client.CommentsByPostId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyCommentsByPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiCommentClientResponseModel> response = await client.CommentsByPostId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostsByParentIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostClientResponseModel> response = await client.PostsByParentId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostsByParentIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostClientResponseModel> response = await client.PostsByParentId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTagsByExcerptPostIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTagClientResponseModel> response = await client.TagsByExcerptPostId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTagsByExcerptPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTagClientResponseModel> response = await client.TagsByExcerptPostId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTagsByWikiPostIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTagClientResponseModel> response = await client.TagsByWikiPostId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyTagsByWikiPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiTagClientResponseModel> response = await client.TagsByWikiPostId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyVotesByPostIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiVoteClientResponseModel> response = await client.VotesByPostId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyVotesByPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiVoteClientResponseModel> response = await client.VotesByPostId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostHistoriesByPostIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostHistoryClientResponseModel> response = await client.PostHistoriesByPostId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostHistoriesByPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostHistoryClientResponseModel> response = await client.PostHistoriesByPostId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostLinksByPostIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostLinkClientResponseModel> response = await client.PostLinksByPostId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostLinksByPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostLinkClientResponseModel> response = await client.PostLinksByPostId(default(int));

			response.Should().BeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostLinksByRelatedPostIdFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostLinkClientResponseModel> response = await client.PostLinksByRelatedPostId(1);

			response.Should().NotBeEmpty();
		}

		[Fact]
		public virtual async void TestForeignKeyPostLinksByRelatedPostIdNotFound()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			client.SetBearerToken(JWTTestHelper.GenerateBearerToken());
			List<ApiPostLinkClientResponseModel> response = await client.PostLinksByRelatedPostId(default(int));

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
				var result = await client.PostAllAsync(token);
			};

			testCancellation.Should().Throw<OperationCanceledException>();
		}
	}
}

/*<Codenesium>
    <Hash>813783e4c63be83a9f630845f46c1944</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/