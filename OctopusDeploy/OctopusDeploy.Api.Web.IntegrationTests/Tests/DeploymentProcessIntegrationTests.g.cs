using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using OctopusDeployNS.Api.Client;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "DeploymentProcess")]
	[Trait("Area", "Integration")]
	public class DeploymentProcessIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public DeploymentProcessIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiDeploymentProcessModelMapper mapper = new ApiDeploymentProcessModelMapper();

			UpdateResponse<ApiDeploymentProcessResponseModel> updateResponse = await this.Client.DeploymentProcessUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.DeploymentProcessDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiDeploymentProcessResponseModel response = await this.Client.DeploymentProcessGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiDeploymentProcessResponseModel> response = await this.Client.DeploymentProcessAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDeploymentProcessResponseModel> CreateRecord()
		{
			var model = new ApiDeploymentProcessRequestModel();
			model.SetProperties(true, "B", "B", "B", 2);
			CreateResponse<ApiDeploymentProcessResponseModel> result = await this.Client.DeploymentProcessCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.DeploymentProcessDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>732d5f762917e9e12f6e21199046014b</Hash>
</Codenesium>*/