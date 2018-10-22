using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StackOverflowNS.Api.Client;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Comment")]
	[Trait("Area", "Integration")]
	public class CommentIntegrationTests
	{
		public CommentIntegrationTests()
		{
		}

		[Fact]
		public async void TestCreate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			await client.CommentDeleteAsync(1);

			var response = await this.CreateRecord(client);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestUpdate()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			ApiCommentResponseModel model = await client.CommentGetAsync(1);

			ApiCommentModelMapper mapper = new ApiCommentModelMapper();

			UpdateResponse<ApiCommentResponseModel> updateResponse = await client.CommentUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();
		}

		[Fact]
		public async void TestDelete()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			var createModel = new ApiCommentRequestModel();
			createModel.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B", 2);
			CreateResponse<ApiCommentResponseModel> createResult = await client.CommentCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiCommentResponseModel getResponse = await client.CommentGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.CommentDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiCommentResponseModel verifyResponse = await client.CommentGetAsync(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiCommentResponseModel response = await client.CommentGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());

			List<ApiCommentResponseModel> response = await client.CommentAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCommentResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiCommentRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B", 2);
			CreateResponse<ApiCommentResponseModel> result = await client.CommentCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>4a9b11824605796d014a2affcfff3caa</Hash>
</Codenesium>*/