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
	public class PipelineStepIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PipelineStepIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPipelineStepModelMapper mapper = new ApiPipelineStepModelMapper();

			UpdateResponse<ApiPipelineStepResponseModel> updateResponse = await this.Client.PipelineStepUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PipelineStepDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPipelineStepResponseModel response = await this.Client.PipelineStepGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPipelineStepResponseModel> response = await this.Client.PipelineStepAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStepResponseModel> CreateRecord()
		{
			var model = new ApiPipelineStepRequestModel();
			model.SetProperties("B", 1, 1);
			CreateResponse<ApiPipelineStepResponseModel> result = await this.Client.PipelineStepCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PipelineStepDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>cdb33c37dce026e1432c358d175a876e</Hash>
</Codenesium>*/