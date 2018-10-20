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
	[Trait("Table", "Currency")]
	[Trait("Area", "Integration")]
	public class CurrencyIntegrationTests
	{
		public CurrencyIntegrationTests()
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

			await client.CurrencyDeleteAsync("A");

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

			ApiCurrencyResponseModel model = await client.CurrencyGetAsync("A");

			ApiCurrencyModelMapper mapper = new ApiCurrencyModelMapper();

			UpdateResponse<ApiCurrencyResponseModel> updateResponse = await client.CurrencyUpdateAsync(model.CurrencyCode, mapper.MapResponseToRequest(model));

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

			ApiCurrencyResponseModel response = await client.CurrencyGetAsync("A");

			response.Should().NotBeNull();

			ActionResponse result = await client.CurrencyDeleteAsync("A");

			result.Success.Should().BeTrue();

			response = await client.CurrencyGetAsync("A");

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
			ApiCurrencyResponseModel response = await client.CurrencyGetAsync("A");

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

			List<ApiCurrencyResponseModel> response = await client.CurrencyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCurrencyResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiCurrencyRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiCurrencyResponseModel> result = await client.CurrencyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>d67e29aacc3b727a1d8fdb65572c0414</Hash>
</Codenesium>*/