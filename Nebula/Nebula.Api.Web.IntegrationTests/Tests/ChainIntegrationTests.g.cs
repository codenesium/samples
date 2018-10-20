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
	[Trait("Table", "Chain")]
	[Trait("Area", "Integration")]
	public class ChainIntegrationTests
	{
		public ChainIntegrationTests()
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

			await client.ChainDeleteAsync(1);

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

			ApiChainResponseModel model = await client.ChainGetAsync(1);

			ApiChainModelMapper mapper = new ApiChainModelMapper();

			UpdateResponse<ApiChainResponseModel> updateResponse = await client.ChainUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiChainResponseModel response = await client.ChainGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ChainDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ChainGetAsync(1);

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
			ApiChainResponseModel response = await client.ChainGetAsync(1);

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

			List<ApiChainResponseModel> response = await client.ChainAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiChainResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiChainRequestModel();
			model.SetProperties(1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1);
			CreateResponse<ApiChainResponseModel> result = await client.ChainCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>13595e679ee6210df3376cba6a6e7314</Hash>
</Codenesium>*/