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
	[Trait("Table", "SalesPersonQuotaHistory")]
	[Trait("Area", "Integration")]
	public class SalesPersonQuotaHistoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SalesPersonQuotaHistoryIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSalesPersonQuotaHistoryModelMapper mapper = new ApiSalesPersonQuotaHistoryModelMapper();

			UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel> updateResponse = await this.Client.SalesPersonQuotaHistoryUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SalesPersonQuotaHistoryDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSalesPersonQuotaHistoryResponseModel response = await this.Client.SalesPersonQuotaHistoryGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSalesPersonQuotaHistoryResponseModel> response = await this.Client.SalesPersonQuotaHistoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesPersonQuotaHistoryResponseModel> CreateRecord()
		{
			var model = new ApiSalesPersonQuotaHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m);
			CreateResponse<ApiSalesPersonQuotaHistoryResponseModel> result = await this.Client.SalesPersonQuotaHistoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SalesPersonQuotaHistoryDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>487752c26b0276178373122bae2f2259</Hash>
</Codenesium>*/