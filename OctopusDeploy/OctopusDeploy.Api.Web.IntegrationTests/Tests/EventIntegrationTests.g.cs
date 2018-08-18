using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using OctopusDeployNS.Api.Client;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.IntegrationTests
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
			ApiEventResponseModel response = await this.Client.EventGetAsync("A");

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
			model.SetProperties(2, "B", "B", "B", "B", DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B");
			CreateResponse<ApiEventResponseModel> result = await this.Client.EventCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.EventDeleteAsync("B");
		}
	}
}

/*<Codenesium>
    <Hash>5307b011077b9c0429fd6877ae44a725</Hash>
</Codenesium>*/