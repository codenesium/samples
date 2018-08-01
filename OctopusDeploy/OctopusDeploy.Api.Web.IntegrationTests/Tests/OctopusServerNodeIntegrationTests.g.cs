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
	[Trait("Table", "OctopusServerNode")]
	[Trait("Area", "Integration")]
	public class OctopusServerNodeIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public OctopusServerNodeIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiOctopusServerNodeModelMapper mapper = new ApiOctopusServerNodeModelMapper();

			UpdateResponse<ApiOctopusServerNodeResponseModel> updateResponse = await this.Client.OctopusServerNodeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.OctopusServerNodeDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiOctopusServerNodeResponseModel response = await this.Client.OctopusServerNodeGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiOctopusServerNodeResponseModel> response = await this.Client.OctopusServerNodeAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiOctopusServerNodeResponseModel> CreateRecord()
		{
			var model = new ApiOctopusServerNodeRequestModel();
			model.SetProperties(true, "B", DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), 2, "B", "B");
			CreateResponse<ApiOctopusServerNodeResponseModel> result = await this.Client.OctopusServerNodeCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.OctopusServerNodeDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>ae63a879ae583e3a6373fd225cdad0fd</Hash>
</Codenesium>*/