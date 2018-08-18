using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
	[Trait("Type", "Integration")]
	[Trait("Table", "Shift")]
	[Trait("Area", "Integration")]
	public class ShiftIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public ShiftIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiShiftModelMapper mapper = new ApiShiftModelMapper();

			UpdateResponse<ApiShiftResponseModel> updateResponse = await this.Client.ShiftUpdateAsync(model.ShiftID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.ShiftDeleteAsync(model.ShiftID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiShiftResponseModel response = await this.Client.ShiftGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiShiftResponseModel> response = await this.Client.ShiftAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiShiftResponseModel> CreateRecord()
		{
			var model = new ApiShiftRequestModel();
			model.SetProperties(TimeSpan.Parse("1"), DateTime.Parse("1/1/1988 12:00:00 AM"), "B", TimeSpan.Parse("1"));
			CreateResponse<ApiShiftResponseModel> result = await this.Client.ShiftCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.ShiftDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>2f36db89449a15e37ce11ac1fc14ca95</Hash>
</Codenesium>*/