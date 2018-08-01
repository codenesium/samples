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
	[Trait("Table", "SalesOrderHeaderSalesReason")]
	[Trait("Area", "Integration")]
	public class SalesOrderHeaderSalesReasonIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SalesOrderHeaderSalesReasonIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSalesOrderHeaderSalesReasonModelMapper mapper = new ApiSalesOrderHeaderSalesReasonModelMapper();

			UpdateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> updateResponse = await this.Client.SalesOrderHeaderSalesReasonUpdateAsync(model.SalesOrderID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SalesOrderHeaderSalesReasonDeleteAsync(model.SalesOrderID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSalesOrderHeaderSalesReasonResponseModel response = await this.Client.SalesOrderHeaderSalesReasonGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSalesOrderHeaderSalesReasonResponseModel> response = await this.Client.SalesOrderHeaderSalesReasonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesOrderHeaderSalesReasonResponseModel> CreateRecord()
		{
			var model = new ApiSalesOrderHeaderSalesReasonRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1);
			CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> result = await this.Client.SalesOrderHeaderSalesReasonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SalesOrderHeaderSalesReasonDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>d457cda8662a9f5bd340d984ce5b7ca4</Hash>
</Codenesium>*/