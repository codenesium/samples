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
	[Trait("Table", "Shift")]
	[Trait("Area", "Integration")]
	public class ShiftIntegrationTests
	{
		public ShiftIntegrationTests()
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

			await client.ShiftDeleteAsync(1);

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

			ApiShiftResponseModel model = await client.ShiftGetAsync(1);

			ApiShiftModelMapper mapper = new ApiShiftModelMapper();

			UpdateResponse<ApiShiftResponseModel> updateResponse = await client.ShiftUpdateAsync(model.ShiftID, mapper.MapResponseToRequest(model));

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

			ApiShiftResponseModel response = await client.ShiftGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ShiftDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ShiftGetAsync(1);

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
			ApiShiftResponseModel response = await client.ShiftGetAsync(1);

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

			List<ApiShiftResponseModel> response = await client.ShiftAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiShiftResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiShiftRequestModel();
			model.SetProperties(TimeSpan.Parse("1"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", TimeSpan.Parse("1"));
			CreateResponse<ApiShiftResponseModel> result = await client.ShiftCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>ab902d095e661928c7889afd5866387c</Hash>
</Codenesium>*/