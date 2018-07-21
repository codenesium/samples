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
        [Trait("Table", "Location")]
        [Trait("Area", "Integration")]
        public class LocationIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public LocationIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiLocationModelMapper mapper = new ApiLocationModelMapper();

                        UpdateResponse<ApiLocationResponseModel> updateResponse = await this.Client.LocationUpdateAsync(model.LocationID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.LocationDeleteAsync(model.LocationID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiLocationResponseModel response = await this.Client.LocationGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiLocationResponseModel> response = await this.Client.LocationAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiLocationResponseModel> CreateRecord()
                {
                        var model = new ApiLocationRequestModel();
                        model.SetProperties(3810.59m, 3810.59m, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
                        CreateResponse<ApiLocationResponseModel> result = await this.Client.LocationCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.LocationDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>aeb2bc9f90c4258ffd2217887f995c44</Hash>
</Codenesium>*/