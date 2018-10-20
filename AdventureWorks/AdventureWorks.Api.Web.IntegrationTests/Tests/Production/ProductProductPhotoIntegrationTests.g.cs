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
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "Integration")]
	public class ProductProductPhotoIntegrationTests
	{
		public ProductProductPhotoIntegrationTests()
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

			await client.ProductProductPhotoDeleteAsync(1);

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

			ApiProductProductPhotoResponseModel model = await client.ProductProductPhotoGetAsync(1);

			ApiProductProductPhotoModelMapper mapper = new ApiProductProductPhotoModelMapper();

			UpdateResponse<ApiProductProductPhotoResponseModel> updateResponse = await client.ProductProductPhotoUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

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

			ApiProductProductPhotoResponseModel response = await client.ProductProductPhotoGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ProductProductPhotoDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ProductProductPhotoGetAsync(1);

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
			ApiProductProductPhotoResponseModel response = await client.ProductProductPhotoGetAsync(1);

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

			List<ApiProductProductPhotoResponseModel> response = await client.ProductProductPhotoAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductProductPhotoResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiProductProductPhotoRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2);
			CreateResponse<ApiProductProductPhotoResponseModel> result = await client.ProductProductPhotoCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>1429d434f09f0fdf8461d2534f219ccb</Hash>
</Codenesium>*/