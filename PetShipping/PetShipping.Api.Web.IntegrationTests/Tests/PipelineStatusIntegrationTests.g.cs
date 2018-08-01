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
	[Trait("Table", "PipelineStatus")]
	[Trait("Area", "Integration")]
	public class PipelineStatusIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PipelineStatusIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPipelineStatusModelMapper mapper = new ApiPipelineStatusModelMapper();

			UpdateResponse<ApiPipelineStatusResponseModel> updateResponse = await this.Client.PipelineStatusUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PipelineStatusDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPipelineStatusResponseModel response = await this.Client.PipelineStatusGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPipelineStatusResponseModel> response = await this.Client.PipelineStatusAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineStatusResponseModel> CreateRecord()
		{
			var model = new ApiPipelineStatusRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiPipelineStatusResponseModel> result = await this.Client.PipelineStatusCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PipelineStatusDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>884cd2751c6c82bbf41719475697fb46</Hash>
</Codenesium>*/