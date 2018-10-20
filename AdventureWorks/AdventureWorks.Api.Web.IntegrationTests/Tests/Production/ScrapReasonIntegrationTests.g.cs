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
	[Trait("Table", "ScrapReason")]
	[Trait("Area", "Integration")]
	public class ScrapReasonIntegrationTests
	{
		public ScrapReasonIntegrationTests()
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

			await client.ScrapReasonDeleteAsync(1);

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

			ApiScrapReasonResponseModel model = await client.ScrapReasonGetAsync(1);

			ApiScrapReasonModelMapper mapper = new ApiScrapReasonModelMapper();

			UpdateResponse<ApiScrapReasonResponseModel> updateResponse = await client.ScrapReasonUpdateAsync(model.ScrapReasonID, mapper.MapResponseToRequest(model));

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

			ApiScrapReasonResponseModel response = await client.ScrapReasonGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.ScrapReasonDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.ScrapReasonGetAsync(1);

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
			ApiScrapReasonResponseModel response = await client.ScrapReasonGetAsync(1);

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

			List<ApiScrapReasonResponseModel> response = await client.ScrapReasonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiScrapReasonResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiScrapReasonRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiScrapReasonResponseModel> result = await client.ScrapReasonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>a955ef6c83761a16328ab47eb8a46cd4</Hash>
</Codenesium>*/