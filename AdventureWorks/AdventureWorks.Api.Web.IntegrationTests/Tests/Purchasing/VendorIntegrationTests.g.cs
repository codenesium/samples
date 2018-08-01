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
	[Trait("Table", "Vendor")]
	[Trait("Area", "Integration")]
	public class VendorIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VendorIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiVendorModelMapper mapper = new ApiVendorModelMapper();

			UpdateResponse<ApiVendorResponseModel> updateResponse = await this.Client.VendorUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.VendorDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiVendorResponseModel response = await this.Client.VendorGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVendorResponseModel> response = await this.Client.VendorAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiVendorResponseModel> CreateRecord()
		{
			var model = new ApiVendorRequestModel();
			model.SetProperties("B", true, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", true, "B");
			CreateResponse<ApiVendorResponseModel> result = await this.Client.VendorCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.VendorDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>07abb88d4a46c5bab7e5ce9f0fa1aba3</Hash>
</Codenesium>*/