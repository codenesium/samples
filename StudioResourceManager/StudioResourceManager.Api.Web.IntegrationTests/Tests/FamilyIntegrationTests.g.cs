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

			var createModel = new ApiFamilyRequestModel();
			createModel.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiFamilyResponseModel> createResult = await client.FamilyCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiFamilyResponseModel getResponse = await client.FamilyGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.FamilyDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiFamilyResponseModel verifyResponse = await client.FamilyGetAsync(2);

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
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiFamilyResponseModel> result = await client.FamilyCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>dd03e914f880275563d48041619cbc76</Hash>
</Codenesium>*/