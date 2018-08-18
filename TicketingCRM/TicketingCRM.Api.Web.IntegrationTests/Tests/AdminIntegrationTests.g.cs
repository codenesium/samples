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
	[Trait("Table", "Admin")]
	[Trait("Area", "Integration")]
	public class AdminIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public AdminIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiAdminModelMapper mapper = new ApiAdminModelMapper();

			UpdateResponse<ApiAdminResponseModel> updateResponse = await this.Client.AdminUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.AdminDeleteAsync(model.Id);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiAdminResponseModel response = await this.Client.AdminGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiAdminResponseModel> response = await this.Client.AdminAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiAdminResponseModel> CreateRecord()
		{
			var model = new ApiAdminRequestModel();
			model.SetProperties("B", "B", "B", "B", "B", "B");
			CreateResponse<ApiAdminResponseModel> result = await this.Client.AdminCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.AdminDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>5dc7e24f70ac8c750230229a123ae1a7</Hash>
</Codenesium>*/