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
	[Trait("Table", "StateProvince")]
	[Trait("Area", "Integration")]
	public class StateProvinceIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public StateProvinceIntegrationTests(TestWebApplicationFactory fixture)
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

			ApiStateProvinceModelMapper mapper = new ApiStateProvinceModelMapper();

			UpdateResponse<ApiStateProvinceResponseModel> updateResponse = await this.Client.StateProvinceUpdateAsync(model.StateProvinceID, mapper.MapResponseToRequest(model));

			updateResponse.Record.Should().NotBeNull();
			updateResponse.Success.Should().BeTrue();

			await this.Cleanup();
		}

		[Fact]
		public async void TestDelete()
		{
			var model = await this.CreateRecord();

			await this.Client.StateProvinceDeleteAsync(model.StateProvinceID);

			await this.Cleanup();
		}

		[Fact]
		public async void TestGet()
		{
			ApiStateProvinceResponseModel response = await this.Client.StateProvinceGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiStateProvinceResponseModel> response = await this.Client.StateProvinceAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}

		private async Task<ApiStateProvinceResponseModel> CreateRecord()
		{
			var model = new ApiStateProvinceRequestModel();
			model.SetProperties("B", true, DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), "B", 2);
			CreateResponse<ApiStateProvinceResponseModel> result = await this.Client.StateProvinceCreateAsync(model);

			result.Success.Should().BeTrue();
			return result.Record;
		}

		private async Task Cleanup()
		{
			await this.Client.StateProvinceDeleteAsync(2);
		}
	}
}

/*<Codenesium>
    <Hash>10aa072dfcec1725745fda3b3cd8ecb6</Hash>
</Codenesium>*/