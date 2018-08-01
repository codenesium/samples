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
	[Trait("Table", "WorkOrderRouting")]
	[Trait("Area", "Integration")]
	public class WorkOrderRoutingIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public WorkOrderRoutingIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiWorkOrderRoutingModelMapper mapper = new ApiWorkOrderRoutingModelMapper();

			UpdateResponse<ApiWorkOrderRoutingResponseModel> updateResponse = await this.Client.WorkOrderRoutingUpdateAsync(model.WorkOrderID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.WorkOrderRoutingDeleteAsync(model.WorkOrderID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiWorkOrderRoutingResponseModel response = await this.Client.WorkOrderRoutingGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiWorkOrderRoutingResponseModel> response = await this.Client.WorkOrderRoutingAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiWorkOrderRoutingResponseModel> CreateRecord()
		{
			var model = new ApiWorkOrderRoutingRequestModel();
			model.SetProperties(2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
			CreateResponse<ApiWorkOrderRoutingResponseModel> result = await this.Client.WorkOrderRoutingCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.WorkOrderRoutingDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>e713c70ee93d9d38821550cc833e74db</Hash>
</Codenesium>*/