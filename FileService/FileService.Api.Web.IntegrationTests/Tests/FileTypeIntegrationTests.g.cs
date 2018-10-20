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
	[Trait("Table", "FileType")]
	[Trait("Area", "Integration")]
	public class FileTypeIntegrationTests
	{
		public FileTypeIntegrationTests()
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

			await client.FileTypeDeleteAsync(1);

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

			ApiFileTypeResponseModel model = await client.FileTypeGetAsync(1);

			ApiFileTypeModelMapper mapper = new ApiFileTypeModelMapper();

			UpdateResponse<ApiFileTypeResponseModel> updateResponse = await client.FileTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiFileTypeResponseModel response = await client.FileTypeGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.FileTypeDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.FileTypeGetAsync(1);

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
			ApiFileTypeResponseModel response = await client.FileTypeGetAsync(1);

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

			List<ApiFileTypeResponseModel> response = await client.FileTypeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiFileTypeResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiFileTypeRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiFileTypeResponseModel> result = await client.FileTypeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>336a6a9b18079ce56ee52884b1d90056</Hash>
</Codenesium>*/