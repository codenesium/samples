using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "Integration")]
	public class PipelineStepIntegrationTests
	{
		public PipelineStepIntegrationTests()
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

			await client.PipelineStepDeleteAsync(1);

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

			ApiPipelineStepResponseModel model = await client.PipelineStepGetAsync(1);

			ApiPipelineStepModelMapper mapper = new ApiPipelineStepModelMapper();

			UpdateResponse<ApiPipelineStepResponseModel> updateResponse = await client.PipelineStepUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiPipelineStepRequestModel();
			createModel.SetProperties("B", 1, 1);
			CreateResponse<ApiPipelineStepResponseModel> createResult = await client.PipelineStepCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPipelineStepResponseModel getResponse = await client.PipelineStepGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PipelineStepDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPipelineStepResponseModel verifyResponse = await client.PipelineStepGetAsync(2);

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
			ApiPipelineStepResponseModel response = await client.PipelineStepGetAsync(1);

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

			List<ApiPipelineStepResponseModel> response = await client.PipelineStepAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStepResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPipelineStepRequestModel();
			model.SetProperties("B", 1, 1);
			CreateResponse<ApiPipelineStepResponseModel> result = await client.PipelineStepCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>d480f9c67b95e76c4d50804242f98457</Hash>
</Codenesium>*/