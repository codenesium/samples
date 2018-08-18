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
	[Trait("Table", "SalesTerritory")]
	[Trait("Area", "Integration")]
	public class SalesTerritoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SalesTerritoryIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSalesTerritoryModelMapper mapper = new ApiSalesTerritoryModelMapper();

			UpdateResponse<ApiSalesTerritoryResponseModel> updateResponse = await this.Client.SalesTerritoryUpdateAsync(model.TerritoryID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SalesTerritoryDeleteAsync(model.TerritoryID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSalesTerritoryResponseModel response = await this.Client.SalesTerritoryGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSalesTerritoryResponseModel> response = await this.Client.SalesTerritoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesTerritoryResponseModel> CreateRecord()
		{
			var model = new ApiSalesTerritoryRequestModel();
			model.SetProperties(2m, 2m, "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m);
			CreateResponse<ApiSalesTerritoryResponseModel> result = await this.Client.SalesTerritoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SalesTerritoryDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>dbd812cb0578bd7289dde39bd2c73c18</Hash>
</Codenesium>*/