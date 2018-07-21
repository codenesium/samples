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
        [Trait("Table", "Pet")]
        [Trait("Area", "Integration")]
        public class PetIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public PetIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiPetModelMapper mapper = new ApiPetModelMapper();

                        UpdateResponse<ApiPetResponseModel> updateResponse = await this.Client.PetUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.PetDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiPetResponseModel response = await this.Client.PetGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiPetResponseModel> response = await this.Client.PetAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiPetResponseModel> CreateRecord()
                {
                        var model = new ApiPetRequestModel();
                        model.SetProperties(1, 1, "B", 2);
                        CreateResponse<ApiPetResponseModel> result = await this.Client.PetCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.PetDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>f231e313248305f4381a753378a773e9</Hash>
</Codenesium>*/