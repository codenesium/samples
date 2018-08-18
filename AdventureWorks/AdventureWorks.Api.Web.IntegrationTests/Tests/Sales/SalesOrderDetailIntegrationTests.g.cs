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
	[Trait("Table", "SalesOrderDetail")]
	[Trait("Area", "Integration")]
	public class SalesOrderDetailIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SalesOrderDetailIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSalesOrderDetailModelMapper mapper = new ApiSalesOrderDetailModelMapper();

			UpdateResponse<ApiSalesOrderDetailResponseModel> updateResponse = await this.Client.SalesOrderDetailUpdateAsync(model.SalesOrderID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SalesOrderDetailDeleteAsync(model.SalesOrderID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSalesOrderDetailResponseModel response = await this.Client.SalesOrderDetailGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSalesOrderDetailResponseModel> response = await this.Client.SalesOrderDetailAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesOrderDetailResponseModel> CreateRecord()
		{
			var model = new ApiSalesOrderDetailRequestModel();
			model.SetProperties("B", 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 1, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 1, 2m, 2m);
			CreateResponse<ApiSalesOrderDetailResponseModel> result = await this.Client.SalesOrderDetailCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SalesOrderDetailDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>3c0f09e4bbb8215f8f0719b379561810</Hash>
</Codenesium>*/