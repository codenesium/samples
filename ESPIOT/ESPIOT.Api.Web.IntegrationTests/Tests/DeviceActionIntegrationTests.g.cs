using ESPIOTNS.Api.Client;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ESPIOTNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "DeviceAction")]
	[Trait("Area", "Integration")]
	public class DeviceActionIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public DeviceActionIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiDeviceActionModelMapper mapper = new ApiDeviceActionModelMapper();

			UpdateResponse<ApiDeviceActionResponseModel> updateResponse = await this.Client.DeviceActionUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.DeviceActionDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiDeviceActionResponseModel response = await this.Client.DeviceActionGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiDeviceActionResponseModel> response = await this.Client.DeviceActionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiDeviceActionResponseModel> CreateRecord()
		{
			var model = new ApiDeviceActionRequestModel();
			model.SetProperties(1, "B", "B");
			CreateResponse<ApiDeviceActionResponseModel> result = await this.Client.DeviceActionCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.DeviceActionDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>9f6eb592102bfa57ce94fcbfa19e7aa6</Hash>
</Codenesium>*/