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
	[Trait("Table", "NuGetPackage")]
	[Trait("Area", "Integration")]
	public class NuGetPackageIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public NuGetPackageIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiNuGetPackageModelMapper mapper = new ApiNuGetPackageModelMapper();

			UpdateResponse<ApiNuGetPackageResponseModel> updateResponse = await this.Client.NuGetPackageUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.NuGetPackageDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiNuGetPackageResponseModel response = await this.Client.NuGetPackageGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiNuGetPackageResponseModel> response = await this.Client.NuGetPackageAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiNuGetPackageResponseModel> CreateRecord()
		{
			var model = new ApiNuGetPackageRequestModel();
			model.SetProperties("B", "B", "B", 2, 2, 2, 2, "B");
			CreateResponse<ApiNuGetPackageResponseModel> result = await this.Client.NuGetPackageCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.NuGetPackageDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>5e79833e88a172d24816f16a5af7bfd6</Hash>
</Codenesium>*/