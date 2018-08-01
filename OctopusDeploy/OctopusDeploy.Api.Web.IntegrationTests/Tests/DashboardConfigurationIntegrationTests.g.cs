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
	[Trait("Table", "DashboardConfiguration")]
	[Trait("Area", "Integration")]
	public class DashboardConfigurationIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public DashboardConfigurationIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiDashboardConfigurationModelMapper mapper = new ApiDashboardConfigurationModelMapper();

			UpdateResponse<ApiDashboardConfigurationResponseModel> updateResponse = await this.Client.DashboardConfigurationUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.DashboardConfigurationDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiDashboardConfigurationResponseModel response = await this.Client.DashboardConfigurationGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiDashboardConfigurationResponseModel> response = await this.Client.DashboardConfigurationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDashboardConfigurationResponseModel> CreateRecord()
		{
			var model = new ApiDashboardConfigurationRequestModel();
			model.SetProperties("B", "B", "B", "B", "B");
			CreateResponse<ApiDashboardConfigurationResponseModel> result = await this.Client.DashboardConfigurationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.DashboardConfigurationDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>559b56977e729e8bf2163d48f6e1d6cc</Hash>
</Codenesium>*/