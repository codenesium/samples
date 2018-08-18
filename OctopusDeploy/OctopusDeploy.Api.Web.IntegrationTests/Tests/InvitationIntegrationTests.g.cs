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
	[Trait("Table", "Invitation")]
	[Trait("Area", "Integration")]
	public class InvitationIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public InvitationIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiInvitationModelMapper mapper = new ApiInvitationModelMapper();

			UpdateResponse<ApiInvitationResponseModel> updateResponse = await this.Client.InvitationUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.InvitationDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiInvitationResponseModel response = await this.Client.InvitationGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiInvitationResponseModel> response = await this.Client.InvitationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiInvitationResponseModel> CreateRecord()
		{
			var model = new ApiInvitationRequestModel();
			model.SetProperties("B", "B");
			CreateResponse<ApiInvitationResponseModel> result = await this.Client.InvitationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.InvitationDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>fc8229916d5df43ebf862704d5765199</Hash>
</Codenesium>*/