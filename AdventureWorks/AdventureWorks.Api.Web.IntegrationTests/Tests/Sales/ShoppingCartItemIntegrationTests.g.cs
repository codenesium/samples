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
	[Trait("Table", "ShoppingCartItem")]
	[Trait("Area", "Integration")]
	public class ShoppingCartItemIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ShoppingCartItemIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiShoppingCartItemModelMapper mapper = new ApiShoppingCartItemModelMapper();

			UpdateResponse<ApiShoppingCartItemResponseModel> updateResponse = await this.Client.ShoppingCartItemUpdateAsync(model.ShoppingCartItemID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ShoppingCartItemDeleteAsync(model.ShoppingCartItemID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiShoppingCartItemResponseModel response = await this.Client.ShoppingCartItemGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiShoppingCartItemResponseModel> response = await this.Client.ShoppingCartItemAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiShoppingCartItemResponseModel> CreateRecord()
		{
			var model = new ApiShoppingCartItemRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B");
			CreateResponse<ApiShoppingCartItemResponseModel> result = await this.Client.ShoppingCartItemCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ShoppingCartItemDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>b6ee22398c1ef90d4f1015efd22f14f6</Hash>
</Codenesium>*/