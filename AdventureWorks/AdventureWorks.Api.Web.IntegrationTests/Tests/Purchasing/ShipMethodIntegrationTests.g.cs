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
	[Trait("Table", "ShipMethod")]
	[Trait("Area", "Integration")]
	public class ShipMethodIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ShipMethodIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiShipMethodModelMapper mapper = new ApiShipMethodModelMapper();

			UpdateResponse<ApiShipMethodResponseModel> updateResponse = await this.Client.ShipMethodUpdateAsync(model.ShipMethodID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ShipMethodDeleteAsync(model.ShipMethodID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiShipMethodResponseModel response = await this.Client.ShipMethodGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiShipMethodResponseModel> response = await this.Client.ShipMethodAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiShipMethodResponseModel> CreateRecord()
		{
			var model = new ApiShipMethodRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			CreateResponse<ApiShipMethodResponseModel> result = await this.Client.ShipMethodCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ShipMethodDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>f903d2065645ef0094b189b2009886fb</Hash>
</Codenesium>*/