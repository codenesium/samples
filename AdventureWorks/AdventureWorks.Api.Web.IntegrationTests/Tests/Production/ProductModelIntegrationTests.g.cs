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
	[Trait("Table", "ProductModel")]
	[Trait("Area", "Integration")]
	public class ProductModelIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProductModelIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProductModelModelMapper mapper = new ApiProductModelModelMapper();

			UpdateResponse<ApiProductModelResponseModel> updateResponse = await this.Client.ProductModelUpdateAsync(model.ProductModelID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProductModelDeleteAsync(model.ProductModelID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProductModelResponseModel response = await this.Client.ProductModelGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProductModelResponseModel> response = await this.Client.ProductModelAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductModelResponseModel> CreateRecord()
		{
			var model = new ApiProductModelRequestModel();
			model.SetProperties("B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiProductModelResponseModel> result = await this.Client.ProductModelCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProductModelDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>5eb81d6734c252b6f4bc338cee5eb501</Hash>
</Codenesium>*/