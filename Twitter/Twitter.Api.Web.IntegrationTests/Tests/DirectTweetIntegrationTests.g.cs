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
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "Integration")]
	public class DirectTweetIntegrationTests
	{
		public DirectTweetIntegrationTests()
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

			await client.DirectTweetDeleteAsync(1);

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

			ApiDirectTweetResponseModel model = await client.DirectTweetGetAsync(1);

			ApiDirectTweetModelMapper mapper = new ApiDirectTweetModelMapper();

			UpdateResponse<ApiDirectTweetResponseModel> updateResponse = await client.DirectTweetUpdateAsync(model.TweetId, mapper.MapResponseToRequest(model));

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

			ApiDirectTweetResponseModel response = await client.DirectTweetGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.DirectTweetDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.DirectTweetGetAsync(1);

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
			ApiDirectTweetResponseModel response = await client.DirectTweetGetAsync(1);

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

			List<ApiDirectTweetResponseModel> response = await client.DirectTweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDirectTweetResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiDirectTweetRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, TimeSpan.Parse("1"));
			CreateResponse<ApiDirectTweetResponseModel> result = await client.DirectTweetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>a631dc87fda9cf8c008e896d0d047de2</Hash>
</Codenesium>*/