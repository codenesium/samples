using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetStoreNS.Api.Client;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Breed")]
	[Trait("Area", "Integration")]
	public class BreedIntegrationTests
	{
		public BreedIntegrationTests()
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

			await client.BreedDeleteAsync(1);

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

			ApiBreedResponseModel model = await client.BreedGetAsync(1);

			ApiBreedModelMapper mapper = new ApiBreedModelMapper();

			UpdateResponse<ApiBreedResponseModel> updateResponse = await client.BreedUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiBreedRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiBreedResponseModel> createResult = await client.BreedCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiBreedResponseModel getResponse = await client.BreedGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.BreedDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiBreedResponseModel verifyResponse = await client.BreedGetAsync(2);

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
			ApiBreedResponseModel response = await client.BreedGetAsync(1);

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

			List<ApiBreedResponseModel> response = await client.BreedAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBreedResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiBreedRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiBreedResponseModel> result = await client.BreedCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>c5e51a712efce60190bb3825e4ef8c0c</Hash>
</Codenesium>*/