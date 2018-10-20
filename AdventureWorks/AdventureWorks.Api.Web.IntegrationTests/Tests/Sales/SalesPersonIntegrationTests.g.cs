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
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "Integration")]
	public class SalesPersonIntegrationTests
	{
		public SalesPersonIntegrationTests()
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

			await client.SalesPersonDeleteAsync(1);

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

			ApiSalesPersonResponseModel model = await client.SalesPersonGetAsync(1);

			ApiSalesPersonModelMapper mapper = new ApiSalesPersonModelMapper();

			UpdateResponse<ApiSalesPersonResponseModel> updateResponse = await client.SalesPersonUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiSalesPersonResponseModel response = await client.SalesPersonGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SalesPersonDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SalesPersonGetAsync(1);

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
			ApiSalesPersonResponseModel response = await client.SalesPersonGetAsync(1);

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

			List<ApiSalesPersonResponseModel> response = await client.SalesPersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesPersonResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSalesPersonRequestModel();
			model.SetProperties(2m, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m, 2m, 1);
			CreateResponse<ApiSalesPersonResponseModel> result = await client.SalesPersonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>c64356c8e5618500668ea2dd2047047d</Hash>
</Codenesium>*/