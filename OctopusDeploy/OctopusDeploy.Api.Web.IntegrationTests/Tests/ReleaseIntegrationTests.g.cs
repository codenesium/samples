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
	[Trait("Table", "Release")]
	[Trait("Area", "Integration")]
	public class ReleaseIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ReleaseIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiReleaseModelMapper mapper = new ApiReleaseModelMapper();

			UpdateResponse<ApiReleaseResponseModel> updateResponse = await this.Client.ReleaseUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ReleaseDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiReleaseResponseModel response = await this.Client.ReleaseGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiReleaseResponseModel> response = await this.Client.ReleaseAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiReleaseResponseModel> CreateRecord()
		{
			var model = new ApiReleaseRequestModel();
			model.SetProperties(DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", "B");
			CreateResponse<ApiReleaseResponseModel> result = await this.Client.ReleaseCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ReleaseDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>28d8eec4e0b1be7c9988bb4c9c5cdb1c</Hash>
</Codenesium>*/