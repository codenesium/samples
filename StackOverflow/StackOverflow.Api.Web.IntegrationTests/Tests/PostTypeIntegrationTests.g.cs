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
	[Trait("Table", "PostType")]
	[Trait("Area", "Integration")]
	public class PostTypeIntegrationTests
	{
		public PostTypeIntegrationTests()
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

			await client.PostTypeDeleteAsync(1);

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

			ApiPostTypeResponseModel model = await client.PostTypeGetAsync(1);

			ApiPostTypeModelMapper mapper = new ApiPostTypeModelMapper();

			UpdateResponse<ApiPostTypeResponseModel> updateResponse = await client.PostTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiPostTypeRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiPostTypeResponseModel> createResult = await client.PostTypeCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPostTypeResponseModel getResponse = await client.PostTypeGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PostTypeDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPostTypeResponseModel verifyResponse = await client.PostTypeGetAsync(2);

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
			ApiPostTypeResponseModel response = await client.PostTypeGetAsync(1);

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

			List<ApiPostTypeResponseModel> response = await client.PostTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPostTypeResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPostTypeRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPostTypeResponseModel> result = await client.PostTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>c6590f459a242a5943e8a0e7a4d06b23</Hash>
</Codenesium>*/