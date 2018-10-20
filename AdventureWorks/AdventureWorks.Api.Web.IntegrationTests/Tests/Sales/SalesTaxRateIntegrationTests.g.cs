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
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "Integration")]
	public class SalesTaxRateIntegrationTests
	{
		public SalesTaxRateIntegrationTests()
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

			await client.SalesTaxRateDeleteAsync(1);

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

			ApiSalesTaxRateResponseModel model = await client.SalesTaxRateGetAsync(1);

			ApiSalesTaxRateModelMapper mapper = new ApiSalesTaxRateModelMapper();

			UpdateResponse<ApiSalesTaxRateResponseModel> updateResponse = await client.SalesTaxRateUpdateAsync(model.SalesTaxRateID, mapper.MapResponseToRequest(model));

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

			ApiSalesTaxRateResponseModel response = await client.SalesTaxRateGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SalesTaxRateDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SalesTaxRateGetAsync(1);

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
			ApiSalesTaxRateResponseModel response = await client.SalesTaxRateGetAsync(1);

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

			List<ApiSalesTaxRateResponseModel> response = await client.SalesTaxRateAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesTaxRateResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSalesTaxRateRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2m, 2);
			CreateResponse<ApiSalesTaxRateResponseModel> result = await client.SalesTaxRateCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>a8541b02e56fcfaa94b3abd7f8058ec4</Hash>
</Codenesium>*/