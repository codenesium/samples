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
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "Integration")]
	public class TicketStatusIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TicketStatusIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTicketStatusModelMapper mapper = new ApiTicketStatusModelMapper();

			UpdateResponse<ApiTicketStatusResponseModel> updateResponse = await this.Client.TicketStatusUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TicketStatusDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTicketStatusResponseModel response = await this.Client.TicketStatusGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTicketStatusResponseModel> response = await this.Client.TicketStatusAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTicketStatusResponseModel> CreateRecord()
		{
			var model = new ApiTicketStatusRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiTicketStatusResponseModel> result = await this.Client.TicketStatusCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TicketStatusDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>3d859312c2422de951b91b900ed0392b</Hash>
</Codenesium>*/