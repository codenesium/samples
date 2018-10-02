using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "Integration")]
	public class SpaceFeatureIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SpaceFeatureIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSpaceFeatureModelMapper mapper = new ApiSpaceFeatureModelMapper();

			UpdateResponse<ApiSpaceFeatureResponseModel> updateResponse = await this.Client.SpaceFeatureUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SpaceFeatureDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSpaceFeatureResponseModel response = await this.Client.SpaceFeatureGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSpaceFeatureResponseModel> response = await this.Client.SpaceFeatureAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSpaceFeatureResponseModel> CreateRecord()
		{
			var model = new ApiSpaceFeatureRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiSpaceFeatureResponseModel> result = await this.Client.SpaceFeatureCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SpaceFeatureDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>4d84d81f73611d7d6b635ec672df57e0</Hash>
</Codenesium>*/