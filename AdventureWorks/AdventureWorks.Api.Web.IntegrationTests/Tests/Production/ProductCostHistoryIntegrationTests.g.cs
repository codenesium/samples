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
	[Trait("Table", "ProductCostHistory")]
	[Trait("Area", "Integration")]
	public class ProductCostHistoryIntegrationTests
	{
		public ProductCostHistoryIntegrationTests()
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

			await client.ProductCostHistoryDeleteAsync(1);

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

			ApiProductCostHistoryResponseModel model = await client.ProductCostHistoryGetAsync(1);

			ApiProductCostHistoryModelMapper mapper = new ApiProductCostHistoryModelMapper();

			UpdateResponse<ApiProductCostHistoryResponseModel> updateResponse = await client.ProductCostHistoryUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

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

			ApiProductCostHistoryResponseModel response = await client.ProductCostHistoryGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ProductCostHistoryDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ProductCostHistoryGetAsync(1);

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
			ApiProductCostHistoryResponseModel response = await client.ProductCostHistoryGetAsync(1);

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

			List<ApiProductCostHistoryResponseModel> response = await client.ProductCostHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductCostHistoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiProductCostHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiProductCostHistoryResponseModel> result = await client.ProductCostHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>700ab4017699f071fa29dcaa7ccb2395</Hash>
</Codenesium>*/