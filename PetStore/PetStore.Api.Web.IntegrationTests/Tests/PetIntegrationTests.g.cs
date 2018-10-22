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
	[Trait("Table", "Pet")]
	[Trait("Area", "Integration")]
	public class PetIntegrationTests
	{
		public PetIntegrationTests()
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

			await client.PetDeleteAsync(1);

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

			ApiPetResponseModel model = await client.PetGetAsync(1);

			ApiPetModelMapper mapper = new ApiPetModelMapper();

			UpdateResponse<ApiPetResponseModel> updateResponse = await client.PetUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiPetRequestModel();
			createModel.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B", 1, 2m, 1);
			CreateResponse<ApiPetResponseModel> createResult = await client.PetCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPetResponseModel getResponse = await client.PetGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PetDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPetResponseModel verifyResponse = await client.PetGetAsync(2);

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
			ApiPetResponseModel response = await client.PetGetAsync(1);

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

			List<ApiPetResponseModel> response = await client.PetAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPetResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPetRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B", 1, 2m, 1);
			CreateResponse<ApiPetResponseModel> result = await client.PetCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>fb95ade28c117462b7274d7b723fbc33</Hash>
</Codenesium>*/