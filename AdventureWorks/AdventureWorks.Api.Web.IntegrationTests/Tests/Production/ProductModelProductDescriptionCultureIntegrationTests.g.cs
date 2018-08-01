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
	[Trait("Table", "ProductModelProductDescriptionCulture")]
	[Trait("Area", "Integration")]
	public class ProductModelProductDescriptionCultureIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProductModelProductDescriptionCultureIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProductModelProductDescriptionCultureModelMapper mapper = new ApiProductModelProductDescriptionCultureModelMapper();

			UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel> updateResponse = await this.Client.ProductModelProductDescriptionCultureUpdateAsync(model.ProductModelID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProductModelProductDescriptionCultureDeleteAsync(model.ProductModelID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProductModelProductDescriptionCultureResponseModel response = await this.Client.ProductModelProductDescriptionCultureGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProductModelProductDescriptionCultureResponseModel> response = await this.Client.ProductModelProductDescriptionCultureAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductModelProductDescriptionCultureResponseModel> CreateRecord()
		{
			var model = new ApiProductModelProductDescriptionCultureRequestModel();
			model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			CreateResponse<ApiProductModelProductDescriptionCultureResponseModel> result = await this.Client.ProductModelProductDescriptionCultureCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProductModelProductDescriptionCultureDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>d9c01bcbfb3da82ff6f358aea3bf8cbd</Hash>
</Codenesium>*/