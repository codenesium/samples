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
	[Trait("Table", "SalesTerritoryHistory")]
	[Trait("Area", "Integration")]
	public class SalesTerritoryHistoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SalesTerritoryHistoryIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSalesTerritoryHistoryModelMapper mapper = new ApiSalesTerritoryHistoryModelMapper();

			UpdateResponse<ApiSalesTerritoryHistoryResponseModel> updateResponse = await this.Client.SalesTerritoryHistoryUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SalesTerritoryHistoryDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSalesTerritoryHistoryResponseModel response = await this.Client.SalesTerritoryHistoryGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSalesTerritoryHistoryResponseModel> response = await this.Client.SalesTerritoryHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesTerritoryHistoryResponseModel> CreateRecord()
		{
			var model = new ApiSalesTerritoryHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"), 1);
			CreateResponse<ApiSalesTerritoryHistoryResponseModel> result = await this.Client.SalesTerritoryHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SalesTerritoryHistoryDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>b596eecdd384ab5a04892e24204dcf3b</Hash>
</Codenesium>*/