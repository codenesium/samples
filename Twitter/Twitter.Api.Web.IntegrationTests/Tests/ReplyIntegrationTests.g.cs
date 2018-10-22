using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Reply")]
	[Trait("Area", "Integration")]
	public class ReplyIntegrationTests
	{
		public ReplyIntegrationTests()
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

			await client.ReplyDeleteAsync(1);

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

			ApiReplyResponseModel model = await client.ReplyGetAsync(1);

			ApiReplyModelMapper mapper = new ApiReplyModelMapper();

			UpdateResponse<ApiReplyResponseModel> updateResponse = await client.ReplyUpdateAsync(model.ReplyId, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiReplyRequestModel();
			createModel.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("1"));
			CreateResponse<ApiReplyResponseModel> createResult = await client.ReplyCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiReplyResponseModel getResponse = await client.ReplyGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.ReplyDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiReplyResponseModel verifyResponse = await client.ReplyGetAsync(2);

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
			ApiReplyResponseModel response = await client.ReplyGetAsync(1);

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

			List<ApiReplyResponseModel> response = await client.ReplyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiReplyResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiReplyRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("1"));
			CreateResponse<ApiReplyResponseModel> result = await client.ReplyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>d5a9257f4f2350921e1e8d9549fa592b</Hash>
</Codenesium>*/