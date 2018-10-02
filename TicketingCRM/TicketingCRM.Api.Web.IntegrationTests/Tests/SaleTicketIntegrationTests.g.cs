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
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "Integration")]
	public class SaleTicketIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SaleTicketIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSaleTicketModelMapper mapper = new ApiSaleTicketModelMapper();

			UpdateResponse<ApiSaleTicketResponseModel> updateResponse = await this.Client.SaleTicketUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SaleTicketDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSaleTicketResponseModel response = await this.Client.SaleTicketGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSaleTicketResponseModel> response = await this.Client.SaleTicketAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSaleTicketResponseModel> CreateRecord()
		{
			var model = new ApiSaleTicketRequestModel();
			model.SetProperties(1, 1);
			CreateResponse<ApiSaleTicketResponseModel> result = await this.Client.SaleTicketCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SaleTicketDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>dd27259aa4284fe19c94a9796c27dedb</Hash>
</Codenesium>*/