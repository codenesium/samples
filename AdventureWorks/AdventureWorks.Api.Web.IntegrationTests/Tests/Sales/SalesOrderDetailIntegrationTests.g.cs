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
	[Trait("Table", "SalesOrderDetail")]
	[Trait("Area", "Integration")]
	public class SalesOrderDetailIntegrationTests
	{
		public SalesOrderDetailIntegrationTests()
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

			await client.SalesOrderDetailDeleteAsync(1);

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

			ApiSalesOrderDetailResponseModel model = await client.SalesOrderDetailGetAsync(1);

			ApiSalesOrderDetailModelMapper mapper = new ApiSalesOrderDetailModelMapper();

			UpdateResponse<ApiSalesOrderDetailResponseModel> updateResponse = await client.SalesOrderDetailUpdateAsync(model.SalesOrderID, mapper.MapResponseToRequest(model));

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

			ApiSalesOrderDetailResponseModel response = await client.SalesOrderDetailGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SalesOrderDetailDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SalesOrderDetailGetAsync(1);

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
			ApiSalesOrderDetailResponseModel response = await client.SalesOrderDetailGetAsync(1);

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

			List<ApiSalesOrderDetailResponseModel> response = await client.SalesOrderDetailAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesOrderDetailResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSalesOrderDetailRequestModel();
			model.SetProperties("B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2, 2m, 2m);
			CreateResponse<ApiSalesOrderDetailResponseModel> result = await client.SalesOrderDetailCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>7da5e3ecbcbdb12d60b86bbea1d10610</Hash>
</Codenesium>*/