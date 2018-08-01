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
	[Trait("Table", "SpecialOffer")]
	[Trait("Area", "Integration")]
	public class SpecialOfferIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SpecialOfferIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSpecialOfferModelMapper mapper = new ApiSpecialOfferModelMapper();

			UpdateResponse<ApiSpecialOfferResponseModel> updateResponse = await this.Client.SpecialOfferUpdateAsync(model.SpecialOfferID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SpecialOfferDeleteAsync(model.SpecialOfferID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSpecialOfferResponseModel response = await this.Client.SpecialOfferGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSpecialOfferResponseModel> response = await this.Client.SpecialOfferAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSpecialOfferResponseModel> CreateRecord()
		{
			var model = new ApiSpecialOfferRequestModel();
			model.SetProperties("B", "B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiSpecialOfferResponseModel> result = await this.Client.SpecialOfferCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SpecialOfferDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>16d2d94fba2c6a35a9b6a3d9754c2aad</Hash>
</Codenesium>*/