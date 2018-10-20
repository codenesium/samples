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
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "Integration")]
	public class PipelineStepStatuIntegrationTests
	{
		public PipelineStepStatuIntegrationTests()
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

			await client.PipelineStepStatuDeleteAsync(1);

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

			ApiPipelineStepStatuResponseModel model = await client.PipelineStepStatuGetAsync(1);

			ApiPipelineStepStatuModelMapper mapper = new ApiPipelineStepStatuModelMapper();

			UpdateResponse<ApiPipelineStepStatuResponseModel> updateResponse = await client.PipelineStepStatuUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiPipelineStepStatuResponseModel response = await client.PipelineStepStatuGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.PipelineStepStatuDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.PipelineStepStatuGetAsync(1);

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
			ApiPipelineStepStatuResponseModel response = await client.PipelineStepStatuGetAsync(1);

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

			List<ApiPipelineStepStatuResponseModel> response = await client.PipelineStepStatuAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStepStatuResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPipelineStepStatuRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPipelineStepStatuResponseModel> result = await client.PipelineStepStatuCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>85653508c2b33783b7920fc70fec32f5</Hash>
</Codenesium>*/