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
	[Trait("Table", "Tenant")]
	[Trait("Area", "Integration")]
	public class TenantIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TenantIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTenantModelMapper mapper = new ApiTenantModelMapper();

			UpdateResponse<ApiTenantResponseModel> updateResponse = await this.Client.TenantUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TenantDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTenantResponseModel response = await this.Client.TenantGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTenantResponseModel> response = await this.Client.TenantAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTenantResponseModel> CreateRecord()
		{
			var model = new ApiTenantRequestModel();
			model.SetProperties(BitConverter.GetBytes(2), "B", "B", "B", "B");
			CreateResponse<ApiTenantResponseModel> result = await this.Client.TenantCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TenantDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>715356142cf66b4fb5dace1c0e7cff07</Hash>
</Codenesium>*/