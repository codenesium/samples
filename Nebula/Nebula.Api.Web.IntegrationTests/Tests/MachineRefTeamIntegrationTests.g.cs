using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "MachineRefTeam")]
	[Trait("Area", "Integration")]
	public class MachineRefTeamIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public MachineRefTeamIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiMachineRefTeamModelMapper mapper = new ApiMachineRefTeamModelMapper();

			UpdateResponse<ApiMachineRefTeamResponseModel> updateResponse = await this.Client.MachineRefTeamUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.MachineRefTeamDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiMachineRefTeamResponseModel response = await this.Client.MachineRefTeamGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiMachineRefTeamResponseModel> response = await this.Client.MachineRefTeamAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiMachineRefTeamResponseModel> CreateRecord()
		{
			var model = new ApiMachineRefTeamRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiMachineRefTeamResponseModel> result = await this.Client.MachineRefTeamCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.MachineRefTeamDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>aa5126de5186d6a10438be4986cf4b31</Hash>
</Codenesium>*/