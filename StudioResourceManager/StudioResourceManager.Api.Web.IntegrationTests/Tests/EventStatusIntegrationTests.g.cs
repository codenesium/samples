using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StudioResourceManagerNS.Api.Client;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "EventStatus")]
	[Trait("Area", "Integration")]
	public class EventStatusIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public EventStatusIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiEventStatusModelMapper mapper = new ApiEventStatusModelMapper();

			UpdateResponse<ApiEventStatusResponseModel> updateResponse = await this.Client.EventStatusUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.EventStatusDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiEventStatusResponseModel response = await this.Client.EventStatusGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiEventStatusResponseModel> response = await this.Client.EventStatusAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiEventStatusResponseModel> CreateRecord()
		{
			var model = new ApiEventStatusRequestModel();
			model.SetProperties("B");
			CreateResponse<ApiEventStatusResponseModel> result = await this.Client.EventStatusCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.EventStatusDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>8acc1cf8c15bda62d1431f9462c5f602</Hash>
</Codenesium>*/