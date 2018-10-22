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
	[Trait("Table", "Following")]
	[Trait("Area", "Integration")]
	public class FollowingIntegrationTests
	{
		public FollowingIntegrationTests()
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

			await client.FollowingDeleteAsync("A");

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

			ApiFollowingResponseModel model = await client.FollowingGetAsync("A");

			ApiFollowingModelMapper mapper = new ApiFollowingModelMapper();

			UpdateResponse<ApiFollowingResponseModel> updateResponse = await client.FollowingUpdateAsync(model.UserId, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiFollowingRequestModel();
			createModel.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiFollowingResponseModel> createResult = await client.FollowingCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiFollowingResponseModel getResponse = await client.FollowingGetAsync("B");

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.FollowingDeleteAsync("B");

			deleteResult.Success.Should().BeTrue();

			ApiFollowingResponseModel verifyResponse = await client.FollowingGetAsync("B");

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
			ApiFollowingResponseModel response = await client.FollowingGetAsync("A");

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

			List<ApiFollowingResponseModel> response = await client.FollowingAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiFollowingResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiFollowingRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiFollowingResponseModel> result = await client.FollowingCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>5aa9b5b030326ad01d0790b02daf5992</Hash>
</Codenesium>*/