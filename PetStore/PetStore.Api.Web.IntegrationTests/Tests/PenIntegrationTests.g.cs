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
	[Trait("Table", "Pen")]
	[Trait("Area", "Integration")]
	public class PenIntegrationTests
	{
		public PenIntegrationTests()
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

			await client.PenDeleteAsync(1);

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

			ApiPenResponseModel model = await client.PenGetAsync(1);

			ApiPenModelMapper mapper = new ApiPenModelMapper();

			UpdateResponse<ApiPenResponseModel> updateResponse = await client.PenUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiPenRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiPenResponseModel> createResult = await client.PenCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPenResponseModel getResponse = await client.PenGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PenDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPenResponseModel verifyResponse = await client.PenGetAsync(2);

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
			ApiPenResponseModel response = await client.PenGetAsync(1);

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

			List<ApiPenResponseModel> response = await client.PenAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPenResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPenRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPenResponseModel> result = await client.PenCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>845dbb823e886be4db39a763dba577a9</Hash>
</Codenesium>*/