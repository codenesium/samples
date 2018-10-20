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

			ApiPostTypeResponseModel response = await client.PostTypeGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.PostTypeDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.PostTypeGetAsync(1);

			response.Should().BeNull();
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
    <Hash>9e4b61ccaa6016f4c977d0aba3fc52c7</Hash>
</Codenesium>*/