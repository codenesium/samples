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
	[Trait("Table", "ProductModelProductDescriptionCulture")]
	[Trait("Area", "Integration")]
	public class ProductModelProductDescriptionCultureIntegrationTests
	{
		public ProductModelProductDescriptionCultureIntegrationTests()
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

			await client.ProductModelProductDescriptionCultureDeleteAsync(1);

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

			ApiProductModelProductDescriptionCultureResponseModel model = await client.ProductModelProductDescriptionCultureGetAsync(1);

			ApiProductModelProductDescriptionCultureModelMapper mapper = new ApiProductModelProductDescriptionCultureModelMapper();

			UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel> updateResponse = await client.ProductModelProductDescriptionCultureUpdateAsync(model.ProductModelID, mapper.MapResponseToRequest(model));

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

			ApiProductModelProductDescriptionCultureResponseModel response = await client.ProductModelProductDescriptionCultureGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ProductModelProductDescriptionCultureDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ProductModelProductDescriptionCultureGetAsync(1);

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
			ApiProductModelProductDescriptionCultureResponseModel response = await client.ProductModelProductDescriptionCultureGetAsync(1);

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

			List<ApiProductModelProductDescriptionCultureResponseModel> response = await client.ProductModelProductDescriptionCultureAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductModelProductDescriptionCultureResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiProductModelProductDescriptionCultureRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			CreateResponse<ApiProductModelProductDescriptionCultureResponseModel> result = await client.ProductModelProductDescriptionCultureCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>450a90d05a23f5416637f1e4d5038c13</Hash>
</Codenesium>*/