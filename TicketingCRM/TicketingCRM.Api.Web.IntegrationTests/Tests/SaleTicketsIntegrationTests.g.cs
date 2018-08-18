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
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "Integration")]
	public class SaleTicketsIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SaleTicketsIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSaleTicketsModelMapper mapper = new ApiSaleTicketsModelMapper();

			UpdateResponse<ApiSaleTicketsResponseModel> updateResponse = await this.Client.SaleTicketsUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SaleTicketsDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSaleTicketsResponseModel response = await this.Client.SaleTicketsGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSaleTicketsResponseModel> response = await this.Client.SaleTicketsAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSaleTicketsResponseModel> CreateRecord()
		{
			var model = new ApiSaleTicketsRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiSaleTicketsResponseModel> result = await this.Client.SaleTicketsCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SaleTicketsDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>c1c877baea80b089ff873a2736e21c69</Hash>
</Codenesium>*/