using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "User")]
	[Trait("Area", "Integration")]
	public class UserIntegrationTests
	{
		public UserIntegrationTests()
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

			await client.UserDeleteAsync(1);

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

			ApiUserResponseModel model = await client.UserGetAsync(1);

			ApiUserModelMapper mapper = new ApiUserModelMapper();

			UpdateResponse<ApiUserResponseModel> updateResponse = await client.UserUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiUserRequestModel();
			createModel.SetProperties("B", "B");
			CreateResponse<ApiUserResponseModel> createResult = await client.UserCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiUserResponseModel getResponse = await client.UserGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.UserDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiUserResponseModel verifyResponse = await client.UserGetAsync(2);

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
			ApiUserResponseModel response = await client.UserGetAsync(1);

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

			List<ApiUserResponseModel> response = await client.UserAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiUserResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiUserRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiUserResponseModel> result = await client.UserCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>3876c31e949f5efd12072cf59110fc9e</Hash>
</Codenesium>*/