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
	[Trait("Table", "SpecialOffer")]
	[Trait("Area", "Integration")]
	public class SpecialOfferIntegrationTests
	{
		public SpecialOfferIntegrationTests()
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

			await client.SpecialOfferDeleteAsync(1);

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

			ApiSpecialOfferResponseModel model = await client.SpecialOfferGetAsync(1);

			ApiSpecialOfferModelMapper mapper = new ApiSpecialOfferModelMapper();

			UpdateResponse<ApiSpecialOfferResponseModel> updateResponse = await client.SpecialOfferUpdateAsync(model.SpecialOfferID, mapper.MapResponseToRequest(model));

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

			ApiSpecialOfferResponseModel response = await client.SpecialOfferGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.SpecialOfferDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.SpecialOfferGetAsync(1);

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
			ApiSpecialOfferResponseModel response = await client.SpecialOfferGetAsync(1);

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

			List<ApiSpecialOfferResponseModel> response = await client.SpecialOfferAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSpecialOfferResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiSpecialOfferRequestModel();
			model.SetProperties("B", "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiSpecialOfferResponseModel> result = await client.SpecialOfferCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>dd2a0042a87a73992b63c9df4d1c21e8</Hash>
</Codenesium>*/