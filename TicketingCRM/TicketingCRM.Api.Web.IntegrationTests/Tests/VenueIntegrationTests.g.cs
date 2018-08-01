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
	[Trait("Table", "Venue")]
	[Trait("Area", "Integration")]
	public class VenueIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VenueIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiVenueModelMapper mapper = new ApiVenueModelMapper();

			UpdateResponse<ApiVenueResponseModel> updateResponse = await this.Client.VenueUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.VenueDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiVenueResponseModel response = await this.Client.VenueGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVenueResponseModel> response = await this.Client.VenueAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVenueResponseModel> CreateRecord()
		{
			var model = new ApiVenueRequestModel();
			model.SetProperties("B", "B", 1, "B", "B", "B", "B", 1, "B");
			CreateResponse<ApiVenueResponseModel> result = await this.Client.VenueCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.VenueDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>743279c7b0f90b78c2a4778b474f2163</Hash>
</Codenesium>*/