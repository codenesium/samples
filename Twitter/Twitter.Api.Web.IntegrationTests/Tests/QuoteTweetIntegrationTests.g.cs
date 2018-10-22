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
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "Integration")]
	public class QuoteTweetIntegrationTests
	{
		public QuoteTweetIntegrationTests()
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

			await client.QuoteTweetDeleteAsync(1);

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

			ApiQuoteTweetResponseModel model = await client.QuoteTweetGetAsync(1);

			ApiQuoteTweetModelMapper mapper = new ApiQuoteTweetModelMapper();

			UpdateResponse<ApiQuoteTweetResponseModel> updateResponse = await client.QuoteTweetUpdateAsync(model.QuoteTweetId, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiQuoteTweetRequestModel();
			createModel.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("1"));
			CreateResponse<ApiQuoteTweetResponseModel> createResult = await client.QuoteTweetCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiQuoteTweetResponseModel getResponse = await client.QuoteTweetGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.QuoteTweetDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiQuoteTweetResponseModel verifyResponse = await client.QuoteTweetGetAsync(2);

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
			ApiQuoteTweetResponseModel response = await client.QuoteTweetGetAsync(1);

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

			List<ApiQuoteTweetResponseModel> response = await client.QuoteTweetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiQuoteTweetResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiQuoteTweetRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1, 1, TimeSpan.Parse("1"));
			CreateResponse<ApiQuoteTweetResponseModel> result = await client.QuoteTweetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>87ba89b73f824c41c6b7c9d40ba28d0e</Hash>
</Codenesium>*/