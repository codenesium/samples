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
	[Trait("Table", "PipelineStepNote")]
	[Trait("Area", "Integration")]
	public class PipelineStepNoteIntegrationTests
	{
		public PipelineStepNoteIntegrationTests()
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

			await client.PipelineStepNoteDeleteAsync(1);

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

			ApiPipelineStepNoteResponseModel model = await client.PipelineStepNoteGetAsync(1);

			ApiPipelineStepNoteModelMapper mapper = new ApiPipelineStepNoteModelMapper();

			UpdateResponse<ApiPipelineStepNoteResponseModel> updateResponse = await client.PipelineStepNoteUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiPipelineStepNoteResponseModel response = await client.PipelineStepNoteGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.PipelineStepNoteDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.PipelineStepNoteGetAsync(1);

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
			ApiPipelineStepNoteResponseModel response = await client.PipelineStepNoteGetAsync(1);

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

			List<ApiPipelineStepNoteResponseModel> response = await client.PipelineStepNoteAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStepNoteResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPipelineStepNoteRequestModel();
			model.SetProperties(1, "B", 1);
			CreateResponse<ApiPipelineStepNoteResponseModel> result = await client.PipelineStepNoteCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>a75d7d01350be10633d1e985156fbc00</Hash>
</Codenesium>*/