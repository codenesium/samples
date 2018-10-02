using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "VStateProvinceCountryRegion")]
	[Trait("Area", "Integration")]
	public class VStateProvinceCountryRegionIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VStateProvinceCountryRegionIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiVStateProvinceCountryRegionModelMapper mapper = new ApiVStateProvinceCountryRegionModelMapper();

			UpdateResponse<ApiVStateProvinceCountryRegionResponseModel> updateResponse = await this.Client.VStateProvinceCountryRegionUpdateAsync(model.StateProvinceID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.VStateProvinceCountryRegionDeleteAsync(model.StateProvinceID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiVStateProvinceCountryRegionResponseModel response = await this.Client.VStateProvinceCountryRegionGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVStateProvinceCountryRegionResponseModel> response = await this.Client.VStateProvinceCountryRegionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVStateProvinceCountryRegionResponseModel> CreateRecord()
		{
			var model = new ApiVStateProvinceCountryRegionRequestModel();
			model.SetProperties("B", "B", true, "B", "B", 2);
			CreateResponse<ApiVStateProvinceCountryRegionResponseModel> result = await this.Client.VStateProvinceCountryRegionCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.VStateProvinceCountryRegionDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>bb50287d816f32807db77dbb2d193d9a</Hash>
</Codenesium>*/