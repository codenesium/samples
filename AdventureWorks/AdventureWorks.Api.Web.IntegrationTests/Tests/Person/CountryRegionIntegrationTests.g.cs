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
	[Trait("Table", "CountryRegion")]
	[Trait("Area", "Integration")]
	public class CountryRegionIntegrationTests
	{
		public CountryRegionIntegrationTests()
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

			await client.CountryRegionDeleteAsync("A");

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

			ApiCountryRegionResponseModel model = await client.CountryRegionGetAsync("A");

			ApiCountryRegionModelMapper mapper = new ApiCountryRegionModelMapper();

			UpdateResponse<ApiCountryRegionResponseModel> updateResponse = await client.CountryRegionUpdateAsync(model.CountryRegionCode, mapper.MapResponseToRequest(model));

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

			ApiCountryRegionResponseModel response = await client.CountryRegionGetAsync("A");

			response.Should().NotBeNull();

			ActionResponse result = await client.CountryRegionDeleteAsync("A");

			result.Success.Should().BeTrue();

			response = await client.CountryRegionGetAsync("A");

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
			ApiCountryRegionResponseModel response = await client.CountryRegionGetAsync("A");

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

			List<ApiCountryRegionResponseModel> response = await client.CountryRegionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCountryRegionResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiCountryRegionRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiCountryRegionResponseModel> result = await client.CountryRegionCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>e75e8a18c8d8cc01d54c408312e2f4c5</Hash>
</Codenesium>*/