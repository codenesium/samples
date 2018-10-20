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
	[Trait("Table", "Sale")]
	[Trait("Area", "Integration")]
	public class SaleIntegrationTests
	{
		public SaleIntegrationTests()
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

			await client.SaleDeleteAsync(1);

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

			ApiSaleResponseModel model = await client.SaleGetAsync(1);

			ApiSaleModelMapper mapper = new ApiSaleModelMapper();

			UpdateResponse<ApiSaleResponseModel> updateResponse = await client.SaleUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiSaleResponseModel response = await client.SaleGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SaleDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SaleGetAsync(1);

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
			ApiSaleResponseModel response = await client.SaleGetAsync(1);

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

			List<ApiSaleResponseModel> response = await client.SaleAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSaleResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSaleRequestModel();
			model.SetProperties(2m, 1, "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			CreateResponse<ApiSaleResponseModel> result = await client.SaleCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>0b378877bf99472491dea70f3bf54c22</Hash>
</Codenesium>*/