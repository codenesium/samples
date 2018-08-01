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
	public class PipelineStepStepRequirementIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PipelineStepStepRequirementIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPipelineStepStepRequirementModelMapper mapper = new ApiPipelineStepStepRequirementModelMapper();

			UpdateResponse<ApiPipelineStepStepRequirementResponseModel> updateResponse = await this.Client.PipelineStepStepRequirementUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PipelineStepStepRequirementDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPipelineStepStepRequirementResponseModel response = await this.Client.PipelineStepStepRequirementGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPipelineStepStepRequirementResponseModel> response = await this.Client.PipelineStepStepRequirementAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStepStepRequirementResponseModel> CreateRecord()
		{
			var model = new ApiPipelineStepStepRequirementRequestModel();
			model.SetProperties("B", 1, true);
			CreateResponse<ApiPipelineStepStepRequirementResponseModel> result = await this.Client.PipelineStepStepRequirementCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PipelineStepStepRequirementDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>4e4d8c7dd33dd8c285a7d5258c1f3ada</Hash>
</Codenesium>*/