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
	[Trait("Table", "SalesOrderHeader")]
	[Trait("Area", "Integration")]
	public class SalesOrderHeaderIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SalesOrderHeaderIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSalesOrderHeaderModelMapper mapper = new ApiSalesOrderHeaderModelMapper();

			UpdateResponse<ApiSalesOrderHeaderResponseModel> updateResponse = await this.Client.SalesOrderHeaderUpdateAsync(model.SalesOrderID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SalesOrderHeaderDeleteAsync(model.SalesOrderID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSalesOrderHeaderResponseModel response = await this.Client.SalesOrderHeaderGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSalesOrderHeaderResponseModel> response = await this.Client.SalesOrderHeaderAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesOrderHeaderResponseModel> CreateRecord()
		{
			var model = new ApiSalesOrderHeaderRequestModel();
			model.SetProperties("B", 2, "B", "B", 1, 1, 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", 2, Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 1, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2m, 2m, 1, 2m);
			CreateResponse<ApiSalesOrderHeaderResponseModel> result = await this.Client.SalesOrderHeaderCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SalesOrderHeaderDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>2b077e9eff3f5eabaa4ca1c97ee073b6</Hash>
</Codenesium>*/