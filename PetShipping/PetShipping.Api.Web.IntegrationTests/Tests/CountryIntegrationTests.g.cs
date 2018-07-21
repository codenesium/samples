using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Country")]
        [Trait("Area", "Integration")]
        public class CountryIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public CountryIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiCountryModelMapper mapper = new ApiCountryModelMapper();

                        UpdateResponse<ApiCountryResponseModel> updateResponse = await this.Client.CountryUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.CountryDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiCountryResponseModel response = await this.Client.CountryGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiCountryResponseModel> response = await this.Client.CountryAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiCountryResponseModel> CreateRecord()
                {
                        var model = new ApiCountryRequestModel();
                        model.SetProperties("B");
                        CreateResponse<ApiCountryResponseModel> result = await this.Client.CountryCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.CountryDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>0c73c441f4ace708c0eae403fb4d6425</Hash>
</Codenesium>*/