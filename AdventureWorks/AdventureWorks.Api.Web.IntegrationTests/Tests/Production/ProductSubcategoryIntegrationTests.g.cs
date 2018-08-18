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
	[Trait("Table", "ProductSubcategory")]
	[Trait("Area", "Integration")]
	public class ProductSubcategoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProductSubcategoryIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProductSubcategoryModelMapper mapper = new ApiProductSubcategoryModelMapper();

			UpdateResponse<ApiProductSubcategoryResponseModel> updateResponse = await this.Client.ProductSubcategoryUpdateAsync(model.ProductSubcategoryID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProductSubcategoryDeleteAsync(model.ProductSubcategoryID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProductSubcategoryResponseModel response = await this.Client.ProductSubcategoryGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProductSubcategoryResponseModel> response = await this.Client.ProductSubcategoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductSubcategoryResponseModel> CreateRecord()
		{
			var model = new ApiProductSubcategoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiProductSubcategoryResponseModel> result = await this.Client.ProductSubcategoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProductSubcategoryDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>11dd9d999f54ec467baf1a30aa91adfe</Hash>
</Codenesium>*/