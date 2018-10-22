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
	[Trait("Table", "Tag")]
	[Trait("Area", "Integration")]
	public class TagIntegrationTests
	{
		public TagIntegrationTests()
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

			await client.TagDeleteAsync(1);

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

			ApiTagResponseModel model = await client.TagGetAsync(1);

			ApiTagModelMapper mapper = new ApiTagModelMapper();

			UpdateResponse<ApiTagResponseModel> updateResponse = await client.TagUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiTagRequestModel();
			createModel.SetProperties(2, 2, "B", 2);
			CreateResponse<ApiTagResponseModel> createResult = await client.TagCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiTagResponseModel getResponse = await client.TagGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.TagDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiTagResponseModel verifyResponse = await client.TagGetAsync(2);

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
			ApiTagResponseModel response = await client.TagGetAsync(1);

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

			List<ApiTagResponseModel> response = await client.TagAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTagResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTagRequestModel();
			model.SetProperties(2, 2, "B", 2);
			CreateResponse<ApiTagResponseModel> result = await client.TagCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>9af85774b801f17ac1abc6e15b71ec52</Hash>
</Codenesium>*/