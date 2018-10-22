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
	[Trait("Table", "Vote")]
	[Trait("Area", "Integration")]
	public class VoteIntegrationTests
	{
		public VoteIntegrationTests()
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

			await client.VoteDeleteAsync(1);

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

			ApiVoteResponseModel model = await client.VoteGetAsync(1);

			ApiVoteModelMapper mapper = new ApiVoteModelMapper();

			UpdateResponse<ApiVoteResponseModel> updateResponse = await client.VoteUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiVoteRequestModel();
			createModel.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiVoteResponseModel> createResult = await client.VoteCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiVoteResponseModel getResponse = await client.VoteGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.VoteDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiVoteResponseModel verifyResponse = await client.VoteGetAsync(2);

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
			ApiVoteResponseModel response = await client.VoteGetAsync(1);

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

			List<ApiVoteResponseModel> response = await client.VoteAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVoteResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiVoteRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2);
			CreateResponse<ApiVoteResponseModel> result = await client.VoteCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>0014d85060364f37776f7a55036aa25a</Hash>
</Codenesium>*/