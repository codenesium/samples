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
	[Trait("Table", "Country")]
	[Trait("Area", "Integration")]
	public class CountryIntegrationTests
	{
		public CountryIntegrationTests()
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

			await client.CountryDeleteAsync(1);

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

			ApiCountryResponseModel model = await client.CountryGetAsync(1);

			ApiCountryModelMapper mapper = new ApiCountryModelMapper();

			UpdateResponse<ApiCountryResponseModel> updateResponse = await client.CountryUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiCountryRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiCountryResponseModel> createResult = await client.CountryCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiCountryResponseModel getResponse = await client.CountryGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.CountryDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiCountryResponseModel verifyResponse = await client.CountryGetAsync(2);

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
			ApiCountryResponseModel response = await client.CountryGetAsync(1);

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

			List<ApiCountryResponseModel> response = await client.CountryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCountryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiCountryRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiCountryResponseModel> result = await client.CountryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>5b9322b92f06fc1db5afdb6abac473a9</Hash>
</Codenesium>*/