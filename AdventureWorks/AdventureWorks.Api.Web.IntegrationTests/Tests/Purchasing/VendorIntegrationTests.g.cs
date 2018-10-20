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
	[Trait("Table", "Vendor")]
	[Trait("Area", "Integration")]
	public class VendorIntegrationTests
	{
		public VendorIntegrationTests()
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

			await client.VendorDeleteAsync(1);

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

			ApiVendorResponseModel model = await client.VendorGetAsync(1);

			ApiVendorModelMapper mapper = new ApiVendorModelMapper();

			UpdateResponse<ApiVendorResponseModel> updateResponse = await client.VendorUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

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

			ApiVendorResponseModel response = await client.VendorGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.VendorDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.VendorGetAsync(1);

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
			ApiVendorResponseModel response = await client.VendorGetAsync(1);

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

			List<ApiVendorResponseModel> response = await client.VendorAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVendorResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiVendorRequestModel();
			model.SetProperties("B", true, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, "B");
			CreateResponse<ApiVendorResponseModel> result = await client.VendorCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>cc2e23bc005001db33dcfcf761f91f50</Hash>
</Codenesium>*/