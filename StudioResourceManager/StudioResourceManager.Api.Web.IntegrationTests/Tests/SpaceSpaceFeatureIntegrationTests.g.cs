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
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "Integration")]
	public class SpaceSpaceFeatureIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SpaceSpaceFeatureIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSpaceSpaceFeatureModelMapper mapper = new ApiSpaceSpaceFeatureModelMapper();

			UpdateResponse<ApiSpaceSpaceFeatureResponseModel> updateResponse = await this.Client.SpaceSpaceFeatureUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SpaceSpaceFeatureDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSpaceSpaceFeatureResponseModel response = await this.Client.SpaceSpaceFeatureGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSpaceSpaceFeatureResponseModel> response = await this.Client.SpaceSpaceFeatureAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSpaceSpaceFeatureResponseModel> CreateRecord()
		{
			var model = new ApiSpaceSpaceFeatureRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiSpaceSpaceFeatureResponseModel> result = await this.Client.SpaceSpaceFeatureCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SpaceSpaceFeatureDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>f675d919f6e58087a33c00a1b06c42f0</Hash>
</Codenesium>*/