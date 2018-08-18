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
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "Integration")]
	public class WorkOrderIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public WorkOrderIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiWorkOrderModelMapper mapper = new ApiWorkOrderModelMapper();

			UpdateResponse<ApiWorkOrderResponseModel> updateResponse = await this.Client.WorkOrderUpdateAsync(model.WorkOrderID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.WorkOrderDeleteAsync(model.WorkOrderID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiWorkOrderResponseModel response = await this.Client.WorkOrderGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiWorkOrderResponseModel> response = await this.Client.WorkOrderAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiWorkOrderResponseModel> CreateRecord()
		{
			var model = new ApiWorkOrderRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2);
			CreateResponse<ApiWorkOrderResponseModel> result = await this.Client.WorkOrderCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.WorkOrderDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>b5b090ed905a3e8fd129ab3b692f2548</Hash>
</Codenesium>*/