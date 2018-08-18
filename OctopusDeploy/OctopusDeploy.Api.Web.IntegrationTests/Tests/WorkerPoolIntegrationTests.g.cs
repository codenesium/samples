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
	[Trait("Table", "WorkerPool")]
	[Trait("Area", "Integration")]
	public class WorkerPoolIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public WorkerPoolIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiWorkerPoolModelMapper mapper = new ApiWorkerPoolModelMapper();

			UpdateResponse<ApiWorkerPoolResponseModel> updateResponse = await this.Client.WorkerPoolUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.WorkerPoolDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiWorkerPoolResponseModel response = await this.Client.WorkerPoolGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiWorkerPoolResponseModel> response = await this.Client.WorkerPoolAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiWorkerPoolResponseModel> CreateRecord()
		{
			var model = new ApiWorkerPoolRequestModel();
			model.SetProperties(true, "B", "B", 2);
			CreateResponse<ApiWorkerPoolResponseModel> result = await this.Client.WorkerPoolCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.WorkerPoolDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>01a7e75845fc0d71975c570219e09f85</Hash>
</Codenesium>*/