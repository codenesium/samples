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
	[Trait("Table", "Family")]
	[Trait("Area", "Integration")]
	public class FamilyIntegrationTests
	{
		public FamilyIntegrationTests()
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

			await client.FamilyDeleteAsync(1);

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

			ApiFamilyResponseModel model = await client.FamilyGetAsync(1);

			ApiFamilyModelMapper mapper = new ApiFamilyModelMapper();

			UpdateResponse<ApiFamilyResponseModel> updateResponse = await client.FamilyUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiFamilyResponseModel response = await client.FamilyGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.FamilyDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.FamilyGetAsync(1);

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
			ApiFamilyResponseModel response = await client.FamilyGetAsync(1);

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

			List<ApiFamilyResponseModel> response = await client.FamilyAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiFamilyResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiFamilyRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", true);
			CreateResponse<ApiFamilyResponseModel> result = await client.FamilyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>bfb5446f237cfc0aa0d820ce353ec093</Hash>
</Codenesium>*/