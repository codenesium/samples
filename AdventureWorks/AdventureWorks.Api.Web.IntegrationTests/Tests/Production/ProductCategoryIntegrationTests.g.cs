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
	[Trait("Table", "ProductCategory")]
	[Trait("Area", "Integration")]
	public class ProductCategoryIntegrationTests
	{
		public ProductCategoryIntegrationTests()
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

			await client.ProductCategoryDeleteAsync(1);

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

			ApiProductCategoryResponseModel model = await client.ProductCategoryGetAsync(1);

			ApiProductCategoryModelMapper mapper = new ApiProductCategoryModelMapper();

			UpdateResponse<ApiProductCategoryResponseModel> updateResponse = await client.ProductCategoryUpdateAsync(model.ProductCategoryID, mapper.MapResponseToRequest(model));

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

			ApiProductCategoryResponseModel response = await client.ProductCategoryGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ProductCategoryDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ProductCategoryGetAsync(1);

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
			ApiProductCategoryResponseModel response = await client.ProductCategoryGetAsync(1);

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

			List<ApiProductCategoryResponseModel> response = await client.ProductCategoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductCategoryResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiProductCategoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiProductCategoryResponseModel> result = await client.ProductCategoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>6203b43ea7117f2064a3420b8e0dc675</Hash>
</Codenesium>*/