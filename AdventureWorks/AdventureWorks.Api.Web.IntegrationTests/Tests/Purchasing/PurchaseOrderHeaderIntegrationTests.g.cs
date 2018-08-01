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
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "Integration")]
	public class PurchaseOrderHeaderIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public PurchaseOrderHeaderIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiPurchaseOrderHeaderModelMapper mapper = new ApiPurchaseOrderHeaderModelMapper();

			UpdateResponse<ApiPurchaseOrderHeaderResponseModel> updateResponse = await this.Client.PurchaseOrderHeaderUpdateAsync(model.PurchaseOrderID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.PurchaseOrderHeaderDeleteAsync(model.PurchaseOrderID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiPurchaseOrderHeaderResponseModel response = await this.Client.PurchaseOrderHeaderGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiPurchaseOrderHeaderResponseModel> response = await this.Client.PurchaseOrderHeaderAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiPurchaseOrderHeaderResponseModel> CreateRecord()
		{
			var model = new ApiPurchaseOrderHeaderRequestModel();
			model.SetProperties(2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2m, 2m, 2m, 2);
			CreateResponse<ApiPurchaseOrderHeaderResponseModel> result = await this.Client.PurchaseOrderHeaderCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.PurchaseOrderHeaderDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>e3be62375095e09a854bde74fdd22c56</Hash>
</Codenesium>*/