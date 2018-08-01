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
	[Trait("Table", "CommunityActionTemplate")]
	[Trait("Area", "Integration")]
	public class CommunityActionTemplateIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public CommunityActionTemplateIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiCommunityActionTemplateModelMapper mapper = new ApiCommunityActionTemplateModelMapper();

			UpdateResponse<ApiCommunityActionTemplateResponseModel> updateResponse = await this.Client.CommunityActionTemplateUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.CommunityActionTemplateDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiCommunityActionTemplateResponseModel response = await this.Client.CommunityActionTemplateGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiCommunityActionTemplateResponseModel> response = await this.Client.CommunityActionTemplateAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiCommunityActionTemplateResponseModel> CreateRecord()
		{
			var model = new ApiCommunityActionTemplateRequestModel();
			model.SetProperties(Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", "B");
			CreateResponse<ApiCommunityActionTemplateResponseModel> result = await this.Client.CommunityActionTemplateCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.CommunityActionTemplateDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>886de3ce312c3c2b1f66dd8d26974da1</Hash>
</Codenesium>*/