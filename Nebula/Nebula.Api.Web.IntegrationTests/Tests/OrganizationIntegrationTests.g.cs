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
	[Trait("Table", "Organization")]
	[Trait("Area", "Integration")]
	public class OrganizationIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public OrganizationIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiOrganizationModelMapper mapper = new ApiOrganizationModelMapper();

			UpdateResponse<ApiOrganizationResponseModel> updateResponse = await this.Client.OrganizationUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.OrganizationDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiOrganizationResponseModel response = await this.Client.OrganizationGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiOrganizationResponseModel> response = await this.Client.OrganizationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiOrganizationResponseModel> CreateRecord()
		{
			var model = new ApiOrganizationRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiOrganizationResponseModel> result = await this.Client.OrganizationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.OrganizationDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>3b2d45d7833d8c7aa157389f0b06058e</Hash>
</Codenesium>*/