using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetStoreNS.Api.Client;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Web.IntegrationTests
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
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B", 1, 3810.59m, 1);
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
    <Hash>31f64ec8a1c782c61c2b037f6fdea279</Hash>
</Codenesium>*/