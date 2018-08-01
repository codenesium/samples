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
	[Trait("Table", "SalesReason")]
	[Trait("Area", "Integration")]
	public class SalesReasonIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public SalesReasonIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiSalesReasonModelMapper mapper = new ApiSalesReasonModelMapper();

			UpdateResponse<ApiSalesReasonResponseModel> updateResponse = await this.Client.SalesReasonUpdateAsync(model.SalesReasonID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.SalesReasonDeleteAsync(model.SalesReasonID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiSalesReasonResponseModel response = await this.Client.SalesReasonGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiSalesReasonResponseModel> response = await this.Client.SalesReasonAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiSalesReasonResponseModel> CreateRecord()
		{
			var model = new ApiSalesReasonRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B");
			CreateResponse<ApiSalesReasonResponseModel> result = await this.Client.SalesReasonCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.SalesReasonDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>886619a0d1173545e4bc7455f1bc2821</Hash>
</Codenesium>*/