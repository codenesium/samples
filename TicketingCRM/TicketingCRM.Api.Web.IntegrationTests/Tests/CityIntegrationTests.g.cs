using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "City")]
        [Trait("Area", "Integration")]
        public class CityIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public CityIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiCityModelMapper mapper = new ApiCityModelMapper();

                        UpdateResponse<ApiCityResponseModel> updateResponse = await this.Client.CityUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.CityDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiCityResponseModel response = await this.Client.CityGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiCityResponseModel> response = await this.Client.CityAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiCityResponseModel> CreateRecord()
                {
                        var model = new ApiCityRequestModel();
                        model.SetProperties("B", 1);
                        CreateResponse<ApiCityResponseModel> result = await this.Client.CityCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.CityDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>14c4c7655c845bed1aafb81ec92c7d75</Hash>
</Codenesium>*/