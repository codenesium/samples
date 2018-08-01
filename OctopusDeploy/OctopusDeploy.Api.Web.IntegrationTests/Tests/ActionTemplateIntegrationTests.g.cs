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
	[Trait("Table", "ActionTemplate")]
	[Trait("Area", "Integration")]
	public class ActionTemplateIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ActionTemplateIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiActionTemplateModelMapper mapper = new ApiActionTemplateModelMapper();

			UpdateResponse<ApiActionTemplateResponseModel> updateResponse = await this.Client.ActionTemplateUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ActionTemplateDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiActionTemplateResponseModel response = await this.Client.ActionTemplateGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiActionTemplateResponseModel> response = await this.Client.ActionTemplateAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiActionTemplateResponseModel> CreateRecord()
		{
			var model = new ApiActionTemplateRequestModel();
			model.SetProperties("B", "B", "B", "B", 2);
			CreateResponse<ApiActionTemplateResponseModel> result = await this.Client.ActionTemplateCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ActionTemplateDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>a09cef539c58786ee95276b54ec84c0a</Hash>
</Codenesium>*/