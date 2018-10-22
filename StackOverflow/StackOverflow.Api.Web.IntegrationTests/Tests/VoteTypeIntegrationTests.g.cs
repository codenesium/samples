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
	[Trait("Table", "VoteType")]
	[Trait("Area", "Integration")]
	public class VoteTypeIntegrationTests
	{
		public VoteTypeIntegrationTests()
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

			await client.VoteTypeDeleteAsync(1);

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

			ApiVoteTypeResponseModel model = await client.VoteTypeGetAsync(1);

			ApiVoteTypeModelMapper mapper = new ApiVoteTypeModelMapper();

			UpdateResponse<ApiVoteTypeResponseModel> updateResponse = await client.VoteTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiVoteTypeRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiVoteTypeResponseModel> createResult = await client.VoteTypeCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiVoteTypeResponseModel getResponse = await client.VoteTypeGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.VoteTypeDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiVoteTypeResponseModel verifyResponse = await client.VoteTypeGetAsync(2);

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
			ApiVoteTypeResponseModel response = await client.VoteTypeGetAsync(1);

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

			List<ApiVoteTypeResponseModel> response = await client.VoteTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVoteTypeResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiVoteTypeRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiVoteTypeResponseModel> result = await client.VoteTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>705f08382c42121c421ac4ff5023755f</Hash>
</Codenesium>*/