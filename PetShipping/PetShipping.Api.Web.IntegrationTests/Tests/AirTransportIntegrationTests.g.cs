using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "AirTransport")]
	[Trait("Area", "Integration")]
	public class AirTransportIntegrationTests
	{
		public AirTransportIntegrationTests()
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

			await client.AirTransportDeleteAsync(1);

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

			ApiAirTransportResponseModel model = await client.AirTransportGetAsync(1);

			ApiAirTransportModelMapper mapper = new ApiAirTransportModelMapper();

			UpdateResponse<ApiAirTransportResponseModel> updateResponse = await client.AirTransportUpdateAsync(model.AirlineId, mapper.MapResponseToRequest(model));

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

			ApiAirTransportResponseModel response = await client.AirTransportGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.AirTransportDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.AirTransportGetAsync(1);

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
			ApiAirTransportResponseModel response = await client.AirTransportGetAsync(1);

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

			List<ApiAirTransportResponseModel> response = await client.AirTransportAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiAirTransportResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiAirTransportRequestModel();
			model.SetProperties("B", 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiAirTransportResponseModel> result = await client.AirTransportCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>45549f3fdfd643c3ac22baa4d2c16415</Hash>
</Codenesium>*/