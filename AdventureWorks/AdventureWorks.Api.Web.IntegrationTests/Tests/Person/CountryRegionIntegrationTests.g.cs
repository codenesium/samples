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
        [Trait("Table", "CountryRegion")]
        [Trait("Area", "Integration")]
        public class CountryRegionIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public CountryRegionIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiCountryRegionModelMapper mapper = new ApiCountryRegionModelMapper();

                        UpdateResponse<ApiCountryRegionResponseModel> updateResponse = await this.Client.CountryRegionUpdateAsync(model.CountryRegionCode, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.CountryRegionDeleteAsync(model.CountryRegionCode);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiCountryRegionResponseModel response = await this.Client.CountryRegionGetAsync("A");

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiCountryRegionResponseModel> response = await this.Client.CountryRegionAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiCountryRegionResponseModel> CreateRecord()
                {
                        var model = new ApiCountryRegionRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
                        CreateResponse<ApiCountryRegionResponseModel> result = await this.Client.CountryRegionCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.CountryRegionDeleteAsync("B");
                }
        }
}

/*<Codenesium>
    <Hash>1b72331a7be89a81cf2b0262a4f5e158</Hash>
</Codenesium>*/