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
	[Trait("Table", "BusinessEntityAddress")]
	[Trait("Area", "Integration")]
	public class BusinessEntityAddressIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public BusinessEntityAddressIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiBusinessEntityAddressModelMapper mapper = new ApiBusinessEntityAddressModelMapper();

			UpdateResponse<ApiBusinessEntityAddressResponseModel> updateResponse = await this.Client.BusinessEntityAddressUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.BusinessEntityAddressDeleteAsync(model.BusinessEntityID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiBusinessEntityAddressResponseModel response = await this.Client.BusinessEntityAddressGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiBusinessEntityAddressResponseModel> response = await this.Client.BusinessEntityAddressAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiBusinessEntityAddressResponseModel> CreateRecord()
		{
			var model = new ApiBusinessEntityAddressRequestModel();
			model.SetProperties(2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
			CreateResponse<ApiBusinessEntityAddressResponseModel> result = await this.Client.BusinessEntityAddressCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.BusinessEntityAddressDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>46213bb6ffe4aa62d498e2bb92e75fc9</Hash>
</Codenesium>*/