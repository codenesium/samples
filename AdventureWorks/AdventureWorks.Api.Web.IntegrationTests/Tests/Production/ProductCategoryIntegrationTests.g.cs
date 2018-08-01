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
	[Trait("Table", "ProductCategory")]
	[Trait("Area", "Integration")]
	public class ProductCategoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProductCategoryIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProductCategoryModelMapper mapper = new ApiProductCategoryModelMapper();

			UpdateResponse<ApiProductCategoryResponseModel> updateResponse = await this.Client.ProductCategoryUpdateAsync(model.ProductCategoryID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProductCategoryDeleteAsync(model.ProductCategoryID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProductCategoryResponseModel response = await this.Client.ProductCategoryGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProductCategoryResponseModel> response = await this.Client.ProductCategoryAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductCategoryResponseModel> CreateRecord()
		{
			var model = new ApiProductCategoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiProductCategoryResponseModel> result = await this.Client.ProductCategoryCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProductCategoryDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>b7a3408d6d14466795b2fd2a634e9028</Hash>
</Codenesium>*/