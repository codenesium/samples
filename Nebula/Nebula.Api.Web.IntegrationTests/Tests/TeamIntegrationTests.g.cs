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
	[Trait("Table", "Team")]
	[Trait("Area", "Integration")]
	public class TeamIntegrationTests
	{
		public TeamIntegrationTests()
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

			await client.TeamDeleteAsync(1);

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

			ApiTeamResponseModel model = await client.TeamGetAsync(1);

			ApiTeamModelMapper mapper = new ApiTeamModelMapper();

			UpdateResponse<ApiTeamResponseModel> updateResponse = await client.TeamUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiTeamRequestModel();
			createModel.SetProperties("B", 1);
			CreateResponse<ApiTeamResponseModel> createResult = await client.TeamCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiTeamResponseModel getResponse = await client.TeamGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.TeamDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiTeamResponseModel verifyResponse = await client.TeamGetAsync(2);

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
			ApiTeamResponseModel response = await client.TeamGetAsync(1);

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

			List<ApiTeamResponseModel> response = await client.TeamAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTeamResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTeamRequestModel();
			model.SetProperties("B", 1);
			CreateResponse<ApiTeamResponseModel> result = await client.TeamCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>dcaa393893e73941b096726f97927ee8</Hash>
</Codenesium>*/