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
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "Integration")]
	public class PipelineStatuIntegrationTests
	{
		public PipelineStatuIntegrationTests()
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

			await client.PipelineStatuDeleteAsync(1);

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

			ApiPipelineStatuResponseModel model = await client.PipelineStatuGetAsync(1);

			ApiPipelineStatuModelMapper mapper = new ApiPipelineStatuModelMapper();

			UpdateResponse<ApiPipelineStatuResponseModel> updateResponse = await client.PipelineStatuUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			var createModel = new ApiPipelineStatuRequestModel();
			createModel.SetProperties("B");
			CreateResponse<ApiPipelineStatuResponseModel> createResult = await client.PipelineStatuCreateAsync(createModel);

			createResult.Success.Should().BeTrue();

			ApiPipelineStatuResponseModel getResponse = await client.PipelineStatuGetAsync(2);

			getResponse.Should().NotBeNull();

			ActionResponse deleteResult = await client.PipelineStatuDeleteAsync(2);

			deleteResult.Success.Should().BeTrue();

			ApiPipelineStatuResponseModel verifyResponse = await client.PipelineStatuGetAsync(2);

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
			ApiPipelineStatuResponseModel response = await client.PipelineStatuGetAsync(1);

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

			List<ApiPipelineStatuResponseModel> response = await client.PipelineStatuAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStatuResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPipelineStatuRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPipelineStatuResponseModel> result = await client.PipelineStatuCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>f3a54f3370ff65e0428481829f7563d4</Hash>
</Codenesium>*/