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
	[Trait("Table", "ProductVendor")]
	[Trait("Area", "Integration")]
	public class ProductVendorIntegrationTests
	{
		public ProductVendorIntegrationTests()
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

			await client.ProductVendorDeleteAsync(1);

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

			ApiProductVendorResponseModel model = await client.ProductVendorGetAsync(1);

			ApiProductVendorModelMapper mapper = new ApiProductVendorModelMapper();

			UpdateResponse<ApiProductVendorResponseModel> updateResponse = await client.ProductVendorUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

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

			ApiProductVendorResponseModel response = await client.ProductVendorGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ProductVendorDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ProductVendorGetAsync(1);

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
			ApiProductVendorResponseModel response = await client.ProductVendorGetAsync(1);

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

			List<ApiProductVendorResponseModel> response = await client.ProductVendorAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductVendorResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiProductVendorRequestModel();
			model.SetProperties(2, 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B");
			CreateResponse<ApiProductVendorResponseModel> result = await client.ProductVendorCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>c19adeb931de1f323e61ff9146b94a60</Hash>
</Codenesium>*/