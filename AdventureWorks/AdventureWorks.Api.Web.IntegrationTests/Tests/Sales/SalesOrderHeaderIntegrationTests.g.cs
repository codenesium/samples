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
	[Trait("Table", "SalesOrderHeader")]
	[Trait("Area", "Integration")]
	public class SalesOrderHeaderIntegrationTests
	{
		public SalesOrderHeaderIntegrationTests()
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

			await client.SalesOrderHeaderDeleteAsync(1);

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

			ApiSalesOrderHeaderResponseModel model = await client.SalesOrderHeaderGetAsync(1);

			ApiSalesOrderHeaderModelMapper mapper = new ApiSalesOrderHeaderModelMapper();

			UpdateResponse<ApiSalesOrderHeaderResponseModel> updateResponse = await client.SalesOrderHeaderUpdateAsync(model.SalesOrderID, mapper.MapResponseToRequest(model));

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

			ApiSalesOrderHeaderResponseModel response = await client.SalesOrderHeaderGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SalesOrderHeaderDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SalesOrderHeaderGetAsync(1);

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
			ApiSalesOrderHeaderResponseModel response = await client.SalesOrderHeaderGetAsync(1);

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

			List<ApiSalesOrderHeaderResponseModel> response = await client.SalesOrderHeaderAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesOrderHeaderResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSalesOrderHeaderRequestModel();
			model.SetProperties("B", 2, "B", "B", 1, 1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2m, 2m, 1, 2m);
			CreateResponse<ApiSalesOrderHeaderResponseModel> result = await client.SalesOrderHeaderCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>6d949677f9260333bcfc959f6647ac83</Hash>
</Codenesium>*/