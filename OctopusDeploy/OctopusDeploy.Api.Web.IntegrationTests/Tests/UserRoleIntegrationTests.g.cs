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
	[Trait("Table", "UserRole")]
	[Trait("Area", "Integration")]
	public class UserRoleIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public UserRoleIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiUserRoleModelMapper mapper = new ApiUserRoleModelMapper();

			UpdateResponse<ApiUserRoleResponseModel> updateResponse = await this.Client.UserRoleUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.UserRoleDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiUserRoleResponseModel response = await this.Client.UserRoleGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiUserRoleResponseModel> response = await this.Client.UserRoleAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiUserRoleResponseModel> CreateRecord()
		{
			var model = new ApiUserRoleRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiUserRoleResponseModel> result = await this.Client.UserRoleCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.UserRoleDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>2b179bf10dcf7759626872c12e58aee9</Hash>
</Codenesium>*/