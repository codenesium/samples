using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "RowVersionCheck")]
	[Trait("Area", "Integration")]
	public class RowVersionCheckIntegrationTests
	{
		public RowVersionCheckIntegrationTests()
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

			await client.RowVersionCheckDeleteAsync(1);

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

			ApiRowVersionCheckResponseModel model = await client.RowVersionCheckGetAsync(1);

			ApiRowVersionCheckModelMapper mapper = new ApiRowVersionCheckModelMapper();

			UpdateResponse<ApiRowVersionCheckResponseModel> updateResponse = await client.RowVersionCheckUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiRowVersionCheckResponseModel response = await client.RowVersionCheckGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.RowVersionCheckDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.RowVersionCheckGetAsync(1);

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
			ApiRowVersionCheckResponseModel response = await client.RowVersionCheckGetAsync(1);

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

			List<ApiRowVersionCheckResponseModel> response = await client.RowVersionCheckAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiRowVersionCheckResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiRowVersionCheckRequestModel();
			model.SetProperties("B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiRowVersionCheckResponseModel> result = await client.RowVersionCheckCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>dc521a4c217d63a519acf6aa691b5d3d</Hash>
</Codenesium>*/