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
	[Trait("Table", "PostLink")]
	[Trait("Area", "Integration")]
	public class PostLinkIntegrationTests
	{
		public PostLinkIntegrationTests()
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

			await client.PostLinkDeleteAsync(1);

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

			ApiPostLinkResponseModel model = await client.PostLinkGetAsync(1);

			ApiPostLinkModelMapper mapper = new ApiPostLinkModelMapper();

			UpdateResponse<ApiPostLinkResponseModel> updateResponse = await client.PostLinkUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiPostLinkRequestModel();
			createModel.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiPostLinkResponseModel> createResult = await client.PostLinkCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPostLinkResponseModel getResponse = await client.PostLinkGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PostLinkDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPostLinkResponseModel verifyResponse = await client.PostLinkGetAsync(2);

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
			ApiPostLinkResponseModel response = await client.PostLinkGetAsync(1);

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

			List<ApiPostLinkResponseModel> response = await client.PostLinkAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPostLinkResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPostLinkRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiPostLinkResponseModel> result = await client.PostLinkCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>2e93801b83f67c0b84370442465b50f0</Hash>
</Codenesium>*/