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
	[Trait("Table", "Device")]
	[Trait("Area", "Integration")]
	public class DeviceIntegrationTests
	{
		public DeviceIntegrationTests()
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

			await client.DeviceDeleteAsync(1);

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

			ApiDeviceResponseModel model = await client.DeviceGetAsync(1);

			ApiDeviceModelMapper mapper = new ApiDeviceModelMapper();

			UpdateResponse<ApiDeviceResponseModel> updateResponse = await client.DeviceUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiDeviceRequestModel();
			createModel.SetProperties("B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiDeviceResponseModel> createResult = await client.DeviceCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiDeviceResponseModel getResponse = await client.DeviceGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.DeviceDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiDeviceResponseModel verifyResponse = await client.DeviceGetAsync(2);

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
			ApiDeviceResponseModel response = await client.DeviceGetAsync(1);

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

			List<ApiDeviceResponseModel> response = await client.DeviceAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDeviceResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiDeviceRequestModel();
			model.SetProperties("B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiDeviceResponseModel> result = await client.DeviceCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>17ba8f13c2729f29b010fbab447e6380</Hash>
</Codenesium>*/