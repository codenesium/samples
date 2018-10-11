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
	[Trait("Table", "VStateProvinceCountryRegion")]
	[Trait("Area", "Integration")]
	public class VStateProvinceCountryRegionIntegrationTests : IClassFixture<TestWebApplicationFactory>
	{
		public VStateProvinceCountryRegionIntegrationTests(TestWebApplicationFactory fixture)
		{
			this.Client = new ApiClient(fixture.CreateClient());
		}

		public ApiClient Client { get; }

		[Fact]
		public async void TestGet()
		{
			ApiVStateProvinceCountryRegionResponseModel response = await this.Client.VStateProvinceCountryRegionGetAsync(1);

			response.Should().NotBeNull();
		}

		[Fact]
		public async void TestAll()
		{
			List<ApiVStateProvinceCountryRegionResponseModel> response = await this.Client.VStateProvinceCountryRegionAllAsync();

			response.Count.Should().BeGreaterThan(0);
		}
	}
}

/*<Codenesium>
    <Hash>93f2a9cbaae9cc0e69f8bc74d536a127</Hash>
</Codenesium>*/