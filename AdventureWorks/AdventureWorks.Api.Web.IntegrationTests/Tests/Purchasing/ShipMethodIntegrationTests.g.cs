using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "ShipMethod")]
	[Trait("Area", "Integration")]
	public class ShipMethodIntegrationTests
	{
		public ShipMethodIntegrationTests()
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

			await client.ShipMethodDeleteAsync(1);

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

			ApiShipMethodResponseModel model = await client.ShipMethodGetAsync(1);

			ApiShipMethodModelMapper mapper = new ApiShipMethodModelMapper();

			UpdateResponse<ApiShipMethodResponseModel> updateResponse = await client.ShipMethodUpdateAsync(model.ShipMethodID, mapper.MapResponseToRequest(model));

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

			ApiShipMethodResponseModel response = await client.ShipMethodGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ShipMethodDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ShipMethodGetAsync(1);

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
			ApiShipMethodResponseModel response = await client.ShipMethodGetAsync(1);

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

			List<ApiShipMethodResponseModel> response = await client.ShipMethodAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiShipMethodResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiShipMethodRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			CreateResponse<ApiShipMethodResponseModel> result = await client.ShipMethodCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>08e89c52ab42cc4b423e283a921dae2c</Hash>
</Codenesium>*/