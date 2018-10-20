using FileServiceNS.Api.Client;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FileServiceNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "File")]
	[Trait("Area", "Integration")]
	public class FileIntegrationTests
	{
		public FileIntegrationTests()
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

			await client.FileDeleteAsync(1);

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

			ApiFileResponseModel model = await client.FileGetAsync(1);

			ApiFileModelMapper mapper = new ApiFileModelMapper();

			UpdateResponse<ApiFileResponseModel> updateResponse = await client.FileUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiFileResponseModel response = await client.FileGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.FileDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.FileGetAsync(1);

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
			ApiFileResponseModel response = await client.FileGetAsync(1);

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

			List<ApiFileResponseModel> response = await client.FileAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiFileResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiFileRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, "B", "B", "B");
			CreateResponse<ApiFileResponseModel> result = await client.FileCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>23f5e5d0f9bd449046774cb58a86ce81</Hash>
</Codenesium>*/