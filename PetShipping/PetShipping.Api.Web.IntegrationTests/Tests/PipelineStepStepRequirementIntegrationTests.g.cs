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
	[Trait("Table", "PipelineStepStepRequirement")]
	[Trait("Area", "Integration")]
	public class PipelineStepStepRequirementIntegrationTests
	{
		public PipelineStepStepRequirementIntegrationTests()
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

			await client.PipelineStepStepRequirementDeleteAsync(1);

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

			ApiPipelineStepStepRequirementResponseModel model = await client.PipelineStepStepRequirementGetAsync(1);

			ApiPipelineStepStepRequirementModelMapper mapper = new ApiPipelineStepStepRequirementModelMapper();

			UpdateResponse<ApiPipelineStepStepRequirementResponseModel> updateResponse = await client.PipelineStepStepRequirementUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

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

			ApiPipelineStepStepRequirementResponseModel response = await client.PipelineStepStepRequirementGetAsync(1);

			response.Should().NotBeNull();

			ActionResponse result = await client.PipelineStepStepRequirementDeleteAsync(1);

			result.Success.Should().BeTrue();

			response = await client.PipelineStepStepRequirementGetAsync(1);

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
			ApiPipelineStepStepRequirementResponseModel response = await client.PipelineStepStepRequirementGetAsync(1);

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

			List<ApiPipelineStepStepRequirementResponseModel> response = await client.PipelineStepStepRequirementAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStepStepRequirementResponseModel> CreateRecord(ApiClient client)
		{
			var model = new ApiPipelineStepStepRequirementRequestModel();
			model.SetProperties("B", 1, true);
			CreateResponse<ApiPipelineStepStepRequirementResponseModel> result = await client.PipelineStepStepRequirementCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}
	}
}

/*<Codenesium>
    <Hash>9bc087d8a79f07d36a08ac5530b6fdf4</Hash>
</Codenesium>*/