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
	[Trait("Table", "SpecialOfferProduct")]
	[Trait("Area", "Integration")]
	public class SpecialOfferProductIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SpecialOfferProductIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSpecialOfferProductModelMapper mapper = new ApiSpecialOfferProductModelMapper();

			UpdateResponse<ApiSpecialOfferProductResponseModel> updateResponse = await this.Client.SpecialOfferProductUpdateAsync(model.SpecialOfferID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SpecialOfferProductDeleteAsync(model.SpecialOfferID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSpecialOfferProductResponseModel response = await this.Client.SpecialOfferProductGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSpecialOfferProductResponseModel> response = await this.Client.SpecialOfferProductAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSpecialOfferProductResponseModel> CreateRecord()
		{
			var model = new ApiSpecialOfferProductRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiSpecialOfferProductResponseModel> result = await this.Client.SpecialOfferProductCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SpecialOfferProductDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>ffe367fcc3d111680a1faaa323000461</Hash>
</Codenesium>*/