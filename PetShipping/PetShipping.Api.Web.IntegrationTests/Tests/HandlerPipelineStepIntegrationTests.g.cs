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
	[Trait("Table", "HandlerPipelineStep")]
	[Trait("Area", "Integration")]
	public class HandlerPipelineStepIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public HandlerPipelineStepIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiHandlerPipelineStepModelMapper mapper = new ApiHandlerPipelineStepModelMapper();

			UpdateResponse<ApiHandlerPipelineStepResponseModel> updateResponse = await this.Client.HandlerPipelineStepUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.HandlerPipelineStepDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiHandlerPipelineStepResponseModel response = await this.Client.HandlerPipelineStepGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiHandlerPipelineStepResponseModel> response = await this.Client.HandlerPipelineStepAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiHandlerPipelineStepResponseModel> CreateRecord()
		{
			var model = new ApiHandlerPipelineStepRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiHandlerPipelineStepResponseModel> result = await this.Client.HandlerPipelineStepCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.HandlerPipelineStepDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>35bd76ab46f67efbbbfd5b314540547c</Hash>
</Codenesium>*/