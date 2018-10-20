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
	[Trait("Table", "Organization")]
	[Trait("Area", "Integration")]
	public class OrganizationIntegrationTests
	{
		public OrganizationIntegrationTests()
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

			await client.OrganizationDeleteAsync(1);

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

			ApiOrganizationResponseModel model = await client.OrganizationGetAsync(1);

			ApiOrganizationModelMapper mapper = new ApiOrganizationModelMapper();

			UpdateResponse<ApiOrganizationResponseModel> updateResponse = await client.OrganizationUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiOrganizationResponseModel response = await client.OrganizationGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.OrganizationDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.OrganizationGetAsync(1);

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
			ApiOrganizationResponseModel response = await client.OrganizationGetAsync(1);

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

			List<ApiOrganizationResponseModel> response = await client.OrganizationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiOrganizationResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiOrganizationRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiOrganizationResponseModel> result = await client.OrganizationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>c712116882395bf28f8dde2d93d4dfba</Hash>
</Codenesium>*/