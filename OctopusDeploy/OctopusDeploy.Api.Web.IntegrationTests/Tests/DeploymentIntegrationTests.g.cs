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
	[Trait("Table", "Deployment")]
	[Trait("Area", "Integration")]
	public class DeploymentIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public DeploymentIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiDeploymentModelMapper mapper = new ApiDeploymentModelMapper();

			UpdateResponse<ApiDeploymentResponseModel> updateResponse = await this.Client.DeploymentUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.DeploymentDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiDeploymentResponseModel response = await this.Client.DeploymentGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiDeploymentResponseModel> response = await this.Client.DeploymentAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDeploymentResponseModel> CreateRecord()
		{
			var model = new ApiDeploymentRequestModel();
			model.SetProperties("B", DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", "B", "B", "B", "B", "B");
			CreateResponse<ApiDeploymentResponseModel> result = await this.Client.DeploymentCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.DeploymentDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>95a5d2e2c4e302b042b51f18a282c2b4</Hash>
</Codenesium>*/