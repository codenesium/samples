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
	public class PipelineStepNoteIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PipelineStepNoteIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPipelineStepNoteModelMapper mapper = new ApiPipelineStepNoteModelMapper();

			UpdateResponse<ApiPipelineStepNoteResponseModel> updateResponse = await this.Client.PipelineStepNoteUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PipelineStepNoteDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPipelineStepNoteResponseModel response = await this.Client.PipelineStepNoteGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPipelineStepNoteResponseModel> response = await this.Client.PipelineStepNoteAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStepNoteResponseModel> CreateRecord()
		{
			var model = new ApiPipelineStepNoteRequestModel();
			model.SetProperties(1, "B", 1);
			CreateResponse<ApiPipelineStepNoteResponseModel> result = await this.Client.PipelineStepNoteCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PipelineStepNoteDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>e95a98b0f2a57ba708c40f953f3904bd</Hash>
</Codenesium>*/