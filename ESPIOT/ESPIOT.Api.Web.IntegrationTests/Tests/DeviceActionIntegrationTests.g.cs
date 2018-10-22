using ESPIOTNS.Api.Client;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ESPIOTNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "DeviceAction")]
	[Trait("Area", "Integration")]
	public class DeviceActionIntegrationTests
	{
		public DeviceActionIntegrationTests()
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

			await client.DeviceActionDeleteAsync(1);

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

			ApiDeviceActionResponseModel model = await client.DeviceActionGetAsync(1);

			ApiDeviceActionModelMapper mapper = new ApiDeviceActionModelMapper();

			UpdateResponse<ApiDeviceActionResponseModel> updateResponse = await client.DeviceActionUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiDeviceActionRequestModel();
			createModel.SetProperties(1, "B", "B");
			CreateResponse<ApiDeviceActionResponseModel> createResult = await client.DeviceActionCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiDeviceActionResponseModel getResponse = await client.DeviceActionGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.DeviceActionDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiDeviceActionResponseModel verifyResponse = await client.DeviceActionGetAsync(2);

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
			ApiDeviceActionResponseModel response = await client.DeviceActionGetAsync(1);

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

			List<ApiDeviceActionResponseModel> response = await client.DeviceActionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDeviceActionResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiDeviceActionRequestModel();
			model.SetProperties(1, "B", "B");
			CreateResponse<ApiDeviceActionResponseModel> result = await client.DeviceActionCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>2fe78c31b98fb625c5ce3883d7a1cf85</Hash>
</Codenesium>*/