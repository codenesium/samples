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
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "Integration")]
	public class CompositePrimaryKeyIntegrationTests
	{
		public CompositePrimaryKeyIntegrationTests()
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

			await client.CompositePrimaryKeyDeleteAsync(1);

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

			ApiCompositePrimaryKeyResponseModel model = await client.CompositePrimaryKeyGetAsync(1);

			ApiCompositePrimaryKeyModelMapper mapper = new ApiCompositePrimaryKeyModelMapper();

			UpdateResponse<ApiCompositePrimaryKeyResponseModel> updateResponse = await client.CompositePrimaryKeyUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiCompositePrimaryKeyResponseModel response = await client.CompositePrimaryKeyGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.CompositePrimaryKeyDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.CompositePrimaryKeyGetAsync(1);

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
			ApiCompositePrimaryKeyResponseModel response = await client.CompositePrimaryKeyGetAsync(1);

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

			List<ApiCompositePrimaryKeyResponseModel> response = await client.CompositePrimaryKeyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCompositePrimaryKeyResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiCompositePrimaryKeyRequestModel();
			model.SetProperties(2);
			CreateResponse<ApiCompositePrimaryKeyResponseModel> result = await client.CompositePrimaryKeyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>ff6b698dd061d5e60d0e616a83a770f5</Hash>
</Codenesium>*/