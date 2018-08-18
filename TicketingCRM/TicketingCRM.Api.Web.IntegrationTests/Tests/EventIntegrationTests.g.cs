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
	[Trait("Table", "Event")]
	[Trait("Area", "Integration")]
	public class EventIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public EventIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiEventModelMapper mapper = new ApiEventModelMapper();

			UpdateResponse<ApiEventResponseModel> updateResponse = await this.Client.EventUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.EventDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiEventResponseModel response = await this.Client.EventGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiEventResponseModel> response = await this.Client.EventAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEventResponseModel> CreateRecord()
		{
			var model = new ApiEventRequestModel();
			model.SetProperties("B", "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
			CreateResponse<ApiEventResponseModel> result = await this.Client.EventCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.EventDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>84378309a2dcd8ddfa5a140b4adddb01</Hash>
</Codenesium>*/