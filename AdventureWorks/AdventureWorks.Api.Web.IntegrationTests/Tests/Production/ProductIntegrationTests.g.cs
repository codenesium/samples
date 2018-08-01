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
	[Trait("Table", "Product")]
	[Trait("Area", "Integration")]
	public class ProductIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProductIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProductModelMapper mapper = new ApiProductModelMapper();

			UpdateResponse<ApiProductResponseModel> updateResponse = await this.Client.ProductUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProductDeleteAsync(model.ProductID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProductResponseModel response = await this.Client.ProductGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProductResponseModel> response = await this.Client.ProductAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductResponseModel> CreateRecord()
		{
			var model = new ApiProductRequestModel();
			model.SetProperties("B", "B", 2, DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2m, true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 2, "B", 2, 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", 2m, "B", 2, "B");
			CreateResponse<ApiProductResponseModel> result = await this.Client.ProductCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProductDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>7e7bec7a0dd6bbcfad410535ae5326b2</Hash>
</Codenesium>*/