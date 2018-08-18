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
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "Integration")]
	public class ProductPhotoIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProductPhotoIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProductPhotoModelMapper mapper = new ApiProductPhotoModelMapper();

			UpdateResponse<ApiProductPhotoResponseModel> updateResponse = await this.Client.ProductPhotoUpdateAsync(model.ProductPhotoID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProductPhotoDeleteAsync(model.ProductPhotoID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProductPhotoResponseModel response = await this.Client.ProductPhotoGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProductPhotoResponseModel> response = await this.Client.ProductPhotoAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductPhotoResponseModel> CreateRecord()
		{
			var model = new ApiProductPhotoRequestModel();
			model.SetProperties(BitConverter.GetBytes(2), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), BitConverter.GetBytes(2), "B");
			CreateResponse<ApiProductPhotoResponseModel> result = await this.Client.ProductPhotoCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProductPhotoDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>42f888014552c09f2a77948873f96176</Hash>
</Codenesium>*/