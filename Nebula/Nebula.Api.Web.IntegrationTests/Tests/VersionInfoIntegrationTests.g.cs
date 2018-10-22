using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "Integration")]
	public class VersionInfoIntegrationTests
	{
		public VersionInfoIntegrationTests()
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

			await client.VersionInfoDeleteAsync(1);

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

			ApiVersionInfoResponseModel model = await client.VersionInfoGetAsync(1);

			ApiVersionInfoModelMapper mapper = new ApiVersionInfoModelMapper();

			UpdateResponse<ApiVersionInfoResponseModel> updateResponse = await client.VersionInfoUpdateAsync(model.Version, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiVersionInfoRequestModel();
			createModel.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiVersionInfoResponseModel> createResult = await client.VersionInfoCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiVersionInfoResponseModel getResponse = await client.VersionInfoGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.VersionInfoDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiVersionInfoResponseModel verifyResponse = await client.VersionInfoGetAsync(2);

			verifyResponse.Should().BeNull();
		}

		[Fact]
		public async void TestGet()
		{
			var builder = new WebHostBuilder()
			              .UseEnvironment("Production")
			              .UseStartup<TestStartup>();
			TestServer testServer = new TestServer(builder);

			var client = new ApiClient(testServer.CreateClient());
			ApiVersionInfoResponseModel response = await client.VersionInfoGetAsync(1);

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

			List<ApiVersionInfoResponseModel> response = await client.VersionInfoAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVersionInfoResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiVersionInfoRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiVersionInfoResponseModel> result = await client.VersionInfoCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>7e2c819a41d96822154f894ecf82dc85</Hash>
</Codenesium>*/