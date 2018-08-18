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
	[Trait("Table", "TenantVariable")]
	[Trait("Area", "Integration")]
	public class TenantVariableIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TenantVariableIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTenantVariableModelMapper mapper = new ApiTenantVariableModelMapper();

			UpdateResponse<ApiTenantVariableResponseModel> updateResponse = await this.Client.TenantVariableUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TenantVariableDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTenantVariableResponseModel response = await this.Client.TenantVariableGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTenantVariableResponseModel> response = await this.Client.TenantVariableAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTenantVariableResponseModel> CreateRecord()
		{
			var model = new ApiTenantVariableRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B");
			CreateResponse<ApiTenantVariableResponseModel> result = await this.Client.TenantVariableCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TenantVariableDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>e4fe51be80b7d568626b0e9922953386</Hash>
</Codenesium>*/