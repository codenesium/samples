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
	[Trait("Table", "Worker")]
	[Trait("Area", "Integration")]
	public class WorkerIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public WorkerIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiWorkerModelMapper mapper = new ApiWorkerModelMapper();

			UpdateResponse<ApiWorkerResponseModel> updateResponse = await this.Client.WorkerUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.WorkerDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiWorkerResponseModel response = await this.Client.WorkerGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiWorkerResponseModel> response = await this.Client.WorkerAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiWorkerResponseModel> CreateRecord()
		{
			var model = new ApiWorkerRequestModel();
			model.SetProperties("B", "B", true, "B", "B", "B", "B", "B", "B");
			CreateResponse<ApiWorkerResponseModel> result = await this.Client.WorkerCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.WorkerDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>7099c14b4abae833e532187b81e4f118</Hash>
</Codenesium>*/