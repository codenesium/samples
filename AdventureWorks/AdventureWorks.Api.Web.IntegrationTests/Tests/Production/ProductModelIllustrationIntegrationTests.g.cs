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
	[Trait("Table", "ProductModelIllustration")]
	[Trait("Area", "Integration")]
	public class ProductModelIllustrationIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProductModelIllustrationIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProductModelIllustrationModelMapper mapper = new ApiProductModelIllustrationModelMapper();

			UpdateResponse<ApiProductModelIllustrationResponseModel> updateResponse = await this.Client.ProductModelIllustrationUpdateAsync(model.ProductModelID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProductModelIllustrationDeleteAsync(model.ProductModelID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProductModelIllustrationResponseModel response = await this.Client.ProductModelIllustrationGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProductModelIllustrationResponseModel> response = await this.Client.ProductModelIllustrationAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProductModelIllustrationResponseModel> CreateRecord()
		{
			var model = new ApiProductModelIllustrationRequestModel();
			model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiProductModelIllustrationResponseModel> result = await this.Client.ProductModelIllustrationCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProductModelIllustrationDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>3ee37b3af169f1d160a5ce6ae3d0cbb5</Hash>
</Codenesium>*/