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
	[Trait("Table", "PipelineStepStatus")]
	[Trait("Area", "Integration")]
	public class PipelineStepStatusIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PipelineStepStatusIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPipelineStepStatusModelMapper mapper = new ApiPipelineStepStatusModelMapper();

			UpdateResponse<ApiPipelineStepStatusResponseModel> updateResponse = await this.Client.PipelineStepStatusUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PipelineStepStatusDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPipelineStepStatusResponseModel response = await this.Client.PipelineStepStatusGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPipelineStepStatusResponseModel> response = await this.Client.PipelineStepStatusAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStepStatusResponseModel> CreateRecord()
		{
			var model = new ApiPipelineStepStatusRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPipelineStepStatusResponseModel> result = await this.Client.PipelineStepStatusCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PipelineStepStatusDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>c2c577e50769eca2e34091de395ef385</Hash>
</Codenesium>*/