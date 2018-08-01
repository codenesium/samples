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
	[Trait("Table", "Province")]
	[Trait("Area", "Integration")]
	public class ProvinceIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ProvinceIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiProvinceModelMapper mapper = new ApiProvinceModelMapper();

			UpdateResponse<ApiProvinceResponseModel> updateResponse = await this.Client.ProvinceUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ProvinceDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiProvinceResponseModel response = await this.Client.ProvinceGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiProvinceResponseModel> response = await this.Client.ProvinceAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiProvinceResponseModel> CreateRecord()
		{
			var model = new ApiProvinceRequestModel();
			model.SetProperties(1, "B");
			CreateResponse<ApiProvinceResponseModel> result = await this.Client.ProvinceCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ProvinceDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>14aeec684b20ef50bfc51dd800c203fe</Hash>
</Codenesium>*/