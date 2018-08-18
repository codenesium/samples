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
	[Trait("Table", "ProjectGroup")]
	[Trait("Area", "Integration")]
	public class ProjectGroupIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProjectGroupIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProjectGroupModelMapper mapper = new ApiProjectGroupModelMapper();

			UpdateResponse<ApiProjectGroupResponseModel> updateResponse = await this.Client.ProjectGroupUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProjectGroupDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProjectGroupResponseModel response = await this.Client.ProjectGroupGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProjectGroupResponseModel> response = await this.Client.ProjectGroupAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProjectGroupResponseModel> CreateRecord()
		{
			var model = new ApiProjectGroupRequestModel();
			model.SetProperties(BitConverter.GetBytes(2), "B", "B");
			CreateResponse<ApiProjectGroupResponseModel> result = await this.Client.ProjectGroupCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProjectGroupDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>b159b0a1b3d700b775a29e6ba6a5efce</Hash>
</Codenesium>*/