using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "City")]
	[Trait("Area", "Integration")]
	public class CityIntegrationTests
	{
		public CityIntegrationTests()
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

			await client.CityDeleteAsync(1);

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

			ApiCityResponseModel model = await client.CityGetAsync(1);

			ApiCityModelMapper mapper = new ApiCityModelMapper();

			UpdateResponse<ApiCityResponseModel> updateResponse = await client.CityUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiCityRequestModel();
			createModel.SetProperties("B", 1);
			CreateResponse<ApiCityResponseModel> createResult = await client.CityCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiCityResponseModel getResponse = await client.CityGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.CityDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiCityResponseModel verifyResponse = await client.CityGetAsync(2);

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
			ApiCityResponseModel response = await client.CityGetAsync(1);

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

			List<ApiCityResponseModel> response = await client.CityAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCityResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiCityRequestModel();
			model.SetProperties("B", 1);
			CreateResponse<ApiCityResponseModel> result = await client.CityCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>9399dd23795d39cd41f0e609920ab31d</Hash>
</Codenesium>*/