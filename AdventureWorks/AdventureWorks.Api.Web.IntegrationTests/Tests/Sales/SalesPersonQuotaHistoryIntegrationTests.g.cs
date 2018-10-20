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
	[Trait("Table", "SalesPersonQuotaHistory")]
	[Trait("Area", "Integration")]
	public class SalesPersonQuotaHistoryIntegrationTests
	{
		public SalesPersonQuotaHistoryIntegrationTests()
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

			await client.SalesPersonQuotaHistoryDeleteAsync(1);

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

			ApiSalesPersonQuotaHistoryResponseModel model = await client.SalesPersonQuotaHistoryGetAsync(1);

			ApiSalesPersonQuotaHistoryModelMapper mapper = new ApiSalesPersonQuotaHistoryModelMapper();

			UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel> updateResponse = await client.SalesPersonQuotaHistoryUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiSalesPersonQuotaHistoryResponseModel response = await client.SalesPersonQuotaHistoryGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SalesPersonQuotaHistoryDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SalesPersonQuotaHistoryGetAsync(1);

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
			ApiSalesPersonQuotaHistoryResponseModel response = await client.SalesPersonQuotaHistoryGetAsync(1);

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

			List<ApiSalesPersonQuotaHistoryResponseModel> response = await client.SalesPersonQuotaHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesPersonQuotaHistoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSalesPersonQuotaHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m);
			CreateResponse<ApiSalesPersonQuotaHistoryResponseModel> result = await client.SalesPersonQuotaHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>9ecb89a2779bb686d99e20d6c1fbed10</Hash>
</Codenesium>*/