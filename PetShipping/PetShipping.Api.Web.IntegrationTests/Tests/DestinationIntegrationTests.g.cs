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
        [Trait("Table", "Destination")]
        [Trait("Area", "Integration")]
        public class DestinationIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public DestinationIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiDestinationModelMapper mapper = new ApiDestinationModelMapper();

                        UpdateResponse<ApiDestinationResponseModel> updateResponse = await this.Client.DestinationUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.DestinationDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiDestinationResponseModel response = await this.Client.DestinationGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiDestinationResponseModel> response = await this.Client.DestinationAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiDestinationResponseModel> CreateRecord()
                {
                        var model = new ApiDestinationRequestModel();
                        model.SetProperties(1, "B", 2);
                        CreateResponse<ApiDestinationResponseModel> result = await this.Client.DestinationCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.DestinationDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>2470083224a3cd121104e850d8bef7b2</Hash>
</Codenesium>*/