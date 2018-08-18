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
	[Trait("Table", "Pipeline")]
	[Trait("Area", "Integration")]
	public class PipelineIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PipelineIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPipelineModelMapper mapper = new ApiPipelineModelMapper();

			UpdateResponse<ApiPipelineResponseModel> updateResponse = await this.Client.PipelineUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PipelineDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPipelineResponseModel response = await this.Client.PipelineGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPipelineResponseModel> response = await this.Client.PipelineAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPipelineResponseModel> CreateRecord()
		{
			var model = new ApiPipelineRequestModel();
			model.SetProperties(1, 2);
			CreateResponse<ApiPipelineResponseModel> result = await this.Client.PipelineCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PipelineDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>1ec2e3081ac4ee137b238af7f4388348</Hash>
</Codenesium>*/