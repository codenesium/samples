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
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "Integration")]
	public class ProductPhotoIntegrationTests
	{
		public ProductPhotoIntegrationTests()
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

			await client.ProductPhotoDeleteAsync(1);

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

			ApiProductPhotoResponseModel model = await client.ProductPhotoGetAsync(1);

			ApiProductPhotoModelMapper mapper = new ApiProductPhotoModelMapper();

			UpdateResponse<ApiProductPhotoResponseModel> updateResponse = await client.ProductPhotoUpdateAsync(model.ProductPhotoID, mapper.MapResponseToRequest(model));

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

			ApiProductPhotoResponseModel response = await client.ProductPhotoGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ProductPhotoDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ProductPhotoGetAsync(1);

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
			ApiProductPhotoResponseModel response = await client.ProductPhotoGetAsync(1);

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

			List<ApiProductPhotoResponseModel> response = await client.ProductPhotoAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductPhotoResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiProductPhotoRequestModel();
			model.SetProperties(BitConverter.GetBytes(2), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), BitConverter.GetBytes(2), "B");
			CreateResponse<ApiProductPhotoResponseModel> result = await client.ProductPhotoCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>f95dfeb73389fe6b6868d0513b89d4db</Hash>
</Codenesium>*/