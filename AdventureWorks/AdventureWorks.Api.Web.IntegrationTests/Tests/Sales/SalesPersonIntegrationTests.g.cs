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
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "Integration")]
	public class SalesPersonIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SalesPersonIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSalesPersonModelMapper mapper = new ApiSalesPersonModelMapper();

			UpdateResponse<ApiSalesPersonResponseModel> updateResponse = await this.Client.SalesPersonUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SalesPersonDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSalesPersonResponseModel response = await this.Client.SalesPersonGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSalesPersonResponseModel> response = await this.Client.SalesPersonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesPersonResponseModel> CreateRecord()
		{
			var model = new ApiSalesPersonRequestModel();
			model.SetProperties(2m, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2m, 2m, 2m, 1);
			CreateResponse<ApiSalesPersonResponseModel> result = await this.Client.SalesPersonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SalesPersonDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>be136a380397b239a054529647de1768</Hash>
</Codenesium>*/