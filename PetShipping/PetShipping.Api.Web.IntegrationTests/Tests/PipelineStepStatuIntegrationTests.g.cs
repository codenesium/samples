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
	public class PipelineStepStatuIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PipelineStepStatuIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPipelineStepStatuModelMapper mapper = new ApiPipelineStepStatuModelMapper();

			UpdateResponse<ApiPipelineStepStatuResponseModel> updateResponse = await this.Client.PipelineStepStatuUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PipelineStepStatuDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPipelineStepStatuResponseModel response = await this.Client.PipelineStepStatuGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPipelineStepStatuResponseModel> response = await this.Client.PipelineStepStatuAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStepStatuResponseModel> CreateRecord()
		{
			var model = new ApiPipelineStepStatuRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPipelineStepStatuResponseModel> result = await this.Client.PipelineStepStatuCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PipelineStepStatuDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>46817ac326280ce649087bb4256f07fd</Hash>
</Codenesium>*/