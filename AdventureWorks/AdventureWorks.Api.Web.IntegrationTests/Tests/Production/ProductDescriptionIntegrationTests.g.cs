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
	[Trait("Table", "ProductDescription")]
	[Trait("Area", "Integration")]
	public class ProductDescriptionIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProductDescriptionIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProductDescriptionModelMapper mapper = new ApiProductDescriptionModelMapper();

			UpdateResponse<ApiProductDescriptionResponseModel> updateResponse = await this.Client.ProductDescriptionUpdateAsync(model.ProductDescriptionID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProductDescriptionDeleteAsync(model.ProductDescriptionID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProductDescriptionResponseModel response = await this.Client.ProductDescriptionGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProductDescriptionResponseModel> response = await this.Client.ProductDescriptionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductDescriptionResponseModel> CreateRecord()
		{
			var model = new ApiProductDescriptionRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiProductDescriptionResponseModel> result = await this.Client.ProductDescriptionCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProductDescriptionDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>13fc17d548ddcf03f2d925e388ded5d1</Hash>
</Codenesium>*/