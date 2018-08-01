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
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "Integration")]
	public class PipelineStepDestinationIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PipelineStepDestinationIntegrationTests(TestWebApplicationFactory fixture)
		{
			this.Client = new ApiClient(fixture.CreateClient());
		}

		public ApiClient Client { get; }

		[Fact]
		public async void TestCreate()
		{
			var response = await this.CreateRecord();

			response.Should().NotBeNull();

			await this.Cleanup();
		}

		[Fact]
		public async void TestUpdate()
		{
			var model = await this.CreateRecord();

			ApiPipelineStepDestinationModelMapper mapper = new ApiPipelineStepDestinationModelMapper();

			UpdateResponse<ApiPipelineStepDestinationResponseModel> updateResponse = await this.Client.PipelineStepDestinationUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PipelineStepDestinationDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPipelineStepDestinationResponseModel response = await this.Client.PipelineStepDestinationGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPipelineStepDestinationResponseModel> response = await this.Client.PipelineStepDestinationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStepDestinationResponseModel> CreateRecord()
		{
			var model = new ApiPipelineStepDestinationRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiPipelineStepDestinationResponseModel> result = await this.Client.PipelineStepDestinationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PipelineStepDestinationDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>ae21b8d335bb52b30c3162d577071ebb</Hash>
</Codenesium>*/