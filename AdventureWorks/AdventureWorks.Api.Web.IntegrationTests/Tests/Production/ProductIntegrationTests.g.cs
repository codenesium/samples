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
	[Trait("Table", "Product")]
	[Trait("Area", "Integration")]
	public class ProductIntegrationTests
	{
		public ProductIntegrationTests()
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

			await client.ProductDeleteAsync(1);

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

			ApiProductResponseModel model = await client.ProductGetAsync(1);

			ApiProductModelMapper mapper = new ApiProductModelMapper();

			UpdateResponse<ApiProductResponseModel> updateResponse = await client.ProductUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

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

			ApiProductResponseModel response = await client.ProductGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ProductDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ProductGetAsync(1);

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
			ApiProductResponseModel response = await client.ProductGetAsync(1);

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

			List<ApiProductResponseModel> response = await client.ProductAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiProductRequestModel();
			model.SetProperties("B", "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2m, true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 2, "B", 2, 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 2m, "B", 2, "B");
			CreateResponse<ApiProductResponseModel> result = await client.ProductCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>7291a71899b033139a7b7924e0134f27</Hash>
</Codenesium>*/