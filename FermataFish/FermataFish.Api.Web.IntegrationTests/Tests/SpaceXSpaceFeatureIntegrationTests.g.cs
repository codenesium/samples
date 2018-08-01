using FermataFishNS.Api.Client;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "SpaceXSpaceFeature")]
	[Trait("Area", "Integration")]
	public class SpaceXSpaceFeatureIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SpaceXSpaceFeatureIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSpaceXSpaceFeatureModelMapper mapper = new ApiSpaceXSpaceFeatureModelMapper();

			UpdateResponse<ApiSpaceXSpaceFeatureResponseModel> updateResponse = await this.Client.SpaceXSpaceFeatureUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SpaceXSpaceFeatureDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSpaceXSpaceFeatureResponseModel response = await this.Client.SpaceXSpaceFeatureGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSpaceXSpaceFeatureResponseModel> response = await this.Client.SpaceXSpaceFeatureAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSpaceXSpaceFeatureResponseModel> CreateRecord()
		{
			var model = new ApiSpaceXSpaceFeatureRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiSpaceXSpaceFeatureResponseModel> result = await this.Client.SpaceXSpaceFeatureCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SpaceXSpaceFeatureDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>12a8e56b603a9f08b4a563184b61c0d8</Hash>
</Codenesium>*/