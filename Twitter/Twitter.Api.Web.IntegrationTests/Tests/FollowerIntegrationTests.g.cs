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
	[Trait("Table", "Follower")]
	[Trait("Area", "Integration")]
	public class FollowerIntegrationTests
	{
		public FollowerIntegrationTests()
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

			await client.FollowerDeleteAsync(1);

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

			ApiFollowerResponseModel model = await client.FollowerGetAsync(1);

			ApiFollowerModelMapper mapper = new ApiFollowerModelMapper();

			UpdateResponse<ApiFollowerResponseModel> updateResponse = await client.FollowerUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiFollowerRequestModel();
			createModel.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, "B");
			CreateResponse<ApiFollowerResponseModel> createResult = await client.FollowerCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiFollowerResponseModel getResponse = await client.FollowerGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.FollowerDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiFollowerResponseModel verifyResponse = await client.FollowerGetAsync(2);

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
			ApiFollowerResponseModel response = await client.FollowerGetAsync(1);

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

			List<ApiFollowerResponseModel> response = await client.FollowerAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiFollowerResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiFollowerRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 1, 1, "B");
			CreateResponse<ApiFollowerResponseModel> result = await client.FollowerCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>01f99aaf3331ff909972d92910198c3f</Hash>
</Codenesium>*/