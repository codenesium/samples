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
	[Trait("Table", "UnitMeasure")]
	[Trait("Area", "Integration")]
	public class UnitMeasureIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public UnitMeasureIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiUnitMeasureModelMapper mapper = new ApiUnitMeasureModelMapper();

			UpdateResponse<ApiUnitMeasureResponseModel> updateResponse = await this.Client.UnitMeasureUpdateAsync(model.UnitMeasureCode, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.UnitMeasureDeleteAsync(model.UnitMeasureCode);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiUnitMeasureResponseModel response = await this.Client.UnitMeasureGetAsync("A");

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiUnitMeasureResponseModel> response = await this.Client.UnitMeasureAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiUnitMeasureResponseModel> CreateRecord()
		{
			var model = new ApiUnitMeasureRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiUnitMeasureResponseModel> result = await this.Client.UnitMeasureCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.UnitMeasureDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>a444cd63162af0c00b65635ffe03563c</Hash>
</Codenesium>*/