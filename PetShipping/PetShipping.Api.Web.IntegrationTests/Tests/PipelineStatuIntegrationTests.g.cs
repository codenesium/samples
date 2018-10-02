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
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "Integration")]
	public class PipelineStatuIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PipelineStatuIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPipelineStatuModelMapper mapper = new ApiPipelineStatuModelMapper();

			UpdateResponse<ApiPipelineStatuResponseModel> updateResponse = await this.Client.PipelineStatuUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PipelineStatuDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPipelineStatuResponseModel response = await this.Client.PipelineStatuGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPipelineStatuResponseModel> response = await this.Client.PipelineStatuAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStatuResponseModel> CreateRecord()
		{
			var model = new ApiPipelineStatuRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPipelineStatuResponseModel> result = await this.Client.PipelineStatuCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PipelineStatuDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>1b0d369492dc78d802dbc0061c216269</Hash>
</Codenesium>*/