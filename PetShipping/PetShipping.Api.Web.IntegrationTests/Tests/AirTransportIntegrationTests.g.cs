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
        [Trait("Table", "AirTransport")]
        [Trait("Area", "Integration")]
        public class AirTransportIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public AirTransportIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiAirTransportModelMapper mapper = new ApiAirTransportModelMapper();

                        UpdateResponse<ApiAirTransportResponseModel> updateResponse = await this.Client.AirTransportUpdateAsync(model.AirlineId, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.AirTransportDeleteAsync(model.AirlineId);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiAirTransportResponseModel response = await this.Client.AirTransportGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiAirTransportResponseModel> response = await this.Client.AirTransportAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiAirTransportResponseModel> CreateRecord()
                {
                        var model = new ApiAirTransportRequestModel();
                        model.SetProperties("B", 1, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
                        CreateResponse<ApiAirTransportResponseModel> result = await this.Client.AirTransportCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.AirTransportDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>24da2705b0b7bc87571e74c19aa3cddf</Hash>
</Codenesium>*/