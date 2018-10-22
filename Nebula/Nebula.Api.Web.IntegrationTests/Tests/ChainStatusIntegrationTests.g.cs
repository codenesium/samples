using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "Integration")]
	public class ChainStatusIntegrationTests
	{
		public ChainStatusIntegrationTests()
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

			await client.ChainStatusDeleteAsync(1);

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

			ApiChainStatusResponseModel model = await client.ChainStatusGetAsync(1);

			ApiChainStatusModelMapper mapper = new ApiChainStatusModelMapper();

			UpdateResponse<ApiChainStatusResponseModel> updateResponse = await client.ChainStatusUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiChainStatusRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiChainStatusResponseModel> createResult = await client.ChainStatusCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiChainStatusResponseModel getResponse = await client.ChainStatusGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.ChainStatusDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiChainStatusResponseModel verifyResponse = await client.ChainStatusGetAsync(2);

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
			ApiChainStatusResponseModel response = await client.ChainStatusGetAsync(1);

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

			List<ApiChainStatusResponseModel> response = await client.ChainStatusAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiChainStatusResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiChainStatusRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiChainStatusResponseModel> result = await client.ChainStatusCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>e5aefc500cb7d63da47617b8e78688c6</Hash>
</Codenesium>*/