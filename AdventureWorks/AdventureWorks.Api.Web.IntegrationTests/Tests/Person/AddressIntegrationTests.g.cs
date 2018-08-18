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
	[Trait("Table", "Address")]
	[Trait("Area", "Integration")]
	public class AddressIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public AddressIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiAddressModelMapper mapper = new ApiAddressModelMapper();

			UpdateResponse<ApiAddressResponseModel> updateResponse = await this.Client.AddressUpdateAsync(model.AddressID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.AddressDeleteAsync(model.AddressID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiAddressResponseModel response = await this.Client.AddressGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiAddressResponseModel> response = await this.Client.AddressAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiAddressResponseModel> CreateRecord()
		{
			var model = new ApiAddressRequestModel();
			model.SetProperties("B", "B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2);
			CreateResponse<ApiAddressResponseModel> result = await this.Client.AddressCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.AddressDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>163e527836aa23ddbd9f69ad05d058e1</Hash>
</Codenesium>*/