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
	[Trait("Table", "Team")]
	[Trait("Area", "Integration")]
	public class TeamIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TeamIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTeamModelMapper mapper = new ApiTeamModelMapper();

			UpdateResponse<ApiTeamResponseModel> updateResponse = await this.Client.TeamUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TeamDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTeamResponseModel response = await this.Client.TeamGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTeamResponseModel> response = await this.Client.TeamAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTeamResponseModel> CreateRecord()
		{
			var model = new ApiTeamRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B", "B", "B");
			CreateResponse<ApiTeamResponseModel> result = await this.Client.TeamCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TeamDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>8b5f270f2399c60789702cfc33051870</Hash>
</Codenesium>*/