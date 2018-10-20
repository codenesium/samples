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
	[Trait("Table", "ProductSubcategory")]
	[Trait("Area", "Integration")]
	public class ProductSubcategoryIntegrationTests
	{
		public ProductSubcategoryIntegrationTests()
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

			await client.ProductSubcategoryDeleteAsync(1);

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

			ApiProductSubcategoryResponseModel model = await client.ProductSubcategoryGetAsync(1);

			ApiProductSubcategoryModelMapper mapper = new ApiProductSubcategoryModelMapper();

			UpdateResponse<ApiProductSubcategoryResponseModel> updateResponse = await client.ProductSubcategoryUpdateAsync(model.ProductSubcategoryID, mapper.MapResponseToRequest(model));

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

			ApiProductSubcategoryResponseModel response = await client.ProductSubcategoryGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ProductSubcategoryDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ProductSubcategoryGetAsync(1);

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
			ApiProductSubcategoryResponseModel response = await client.ProductSubcategoryGetAsync(1);

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

			List<ApiProductSubcategoryResponseModel> response = await client.ProductSubcategoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductSubcategoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiProductSubcategoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiProductSubcategoryResponseModel> result = await client.ProductSubcategoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>2b5b66daafcde29c70a49e1f74743718</Hash>
</Codenesium>*/