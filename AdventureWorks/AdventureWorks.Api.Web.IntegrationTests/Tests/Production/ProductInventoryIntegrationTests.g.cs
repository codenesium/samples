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
	[Trait("Table", "ProductInventory")]
	[Trait("Area", "Integration")]
	public class ProductInventoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProductInventoryIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProductInventoryModelMapper mapper = new ApiProductInventoryModelMapper();

			UpdateResponse<ApiProductInventoryResponseModel> updateResponse = await this.Client.ProductInventoryUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProductInventoryDeleteAsync(model.ProductID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProductInventoryResponseModel response = await this.Client.ProductInventoryGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProductInventoryResponseModel> response = await this.Client.ProductInventoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductInventoryResponseModel> CreateRecord()
		{
			var model = new ApiProductInventoryRequestModel();
			model.SetProperties(2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B");
			CreateResponse<ApiProductInventoryResponseModel> result = await this.Client.ProductInventoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProductInventoryDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>f56e222cb0cfb1ccc01b6f40fab408f6</Hash>
</Codenesium>*/