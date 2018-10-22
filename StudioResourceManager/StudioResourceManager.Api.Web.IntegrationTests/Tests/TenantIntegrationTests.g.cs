using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "Integration")]
	public class TenantIntegrationTests
	{
		public TenantIntegrationTests()
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

			await client.TenantDeleteAsync(1);

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

			ApiTenantResponseModel model = await client.TenantGetAsync(1);

			ApiTenantModelMapper mapper = new ApiTenantModelMapper();

			UpdateResponse<ApiTenantResponseModel> updateResponse = await client.TenantUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiTenantRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiTenantResponseModel> createResult = await client.TenantCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiTenantResponseModel getResponse = await client.TenantGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.TenantDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiTenantResponseModel verifyResponse = await client.TenantGetAsync(2);

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
			ApiTenantResponseModel response = await client.TenantGetAsync(1);

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

			List<ApiTenantResponseModel> response = await client.TenantAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTenantResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiTenantRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiTenantResponseModel> result = await client.TenantCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>90e31593e5d8cf21ade3af77707f295e</Hash>
</Codenesium>*/