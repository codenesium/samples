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
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "Integration")]
	public class TicketStatuIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public TicketStatuIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiTicketStatuModelMapper mapper = new ApiTicketStatuModelMapper();

			UpdateResponse<ApiTicketStatuResponseModel> updateResponse = await this.Client.TicketStatuUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.TicketStatuDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiTicketStatuResponseModel response = await this.Client.TicketStatuGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiTicketStatuResponseModel> response = await this.Client.TicketStatuAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiTicketStatuResponseModel> CreateRecord()
		{
			var model = new ApiTicketStatuRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiTicketStatuResponseModel> result = await this.Client.TicketStatuCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.TicketStatuDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>f39c7bd50ac1da457ecca1ca672a1ef4</Hash>
</Codenesium>*/