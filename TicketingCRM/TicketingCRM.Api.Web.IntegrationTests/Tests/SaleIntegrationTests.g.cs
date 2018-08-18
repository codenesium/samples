using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Sale")]
	[Trait("Area", "Integration")]
	public class SaleIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SaleIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSaleModelMapper mapper = new ApiSaleModelMapper();

			UpdateResponse<ApiSaleResponseModel> updateResponse = await this.Client.SaleUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SaleDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSaleResponseModel response = await this.Client.SaleGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSaleResponseModel> response = await this.Client.SaleAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSaleResponseModel> CreateRecord()
		{
			var model = new ApiSaleRequestModel();
			model.SetProperties("B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 1);
			CreateResponse<ApiSaleResponseModel> result = await this.Client.SaleCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SaleDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>195e46dd3cb9f4a353af94c744c35c12</Hash>
</Codenesium>*/