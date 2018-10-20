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
	[Trait("Table", "SpecialOfferProduct")]
	[Trait("Area", "Integration")]
	public class SpecialOfferProductIntegrationTests
	{
		public SpecialOfferProductIntegrationTests()
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

			await client.SpecialOfferProductDeleteAsync(1);

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

			ApiSpecialOfferProductResponseModel model = await client.SpecialOfferProductGetAsync(1);

			ApiSpecialOfferProductModelMapper mapper = new ApiSpecialOfferProductModelMapper();

			UpdateResponse<ApiSpecialOfferProductResponseModel> updateResponse = await client.SpecialOfferProductUpdateAsync(model.SpecialOfferID, mapper.MapResponseToRequest(model));

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

			ApiSpecialOfferProductResponseModel response = await client.SpecialOfferProductGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SpecialOfferProductDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SpecialOfferProductGetAsync(1);

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
			ApiSpecialOfferProductResponseModel response = await client.SpecialOfferProductGetAsync(1);

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

			List<ApiSpecialOfferProductResponseModel> response = await client.SpecialOfferProductAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSpecialOfferProductResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSpecialOfferProductRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiSpecialOfferProductResponseModel> result = await client.SpecialOfferProductCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>44d936573fb9537f41c97bad01d7ddc8</Hash>
</Codenesium>*/