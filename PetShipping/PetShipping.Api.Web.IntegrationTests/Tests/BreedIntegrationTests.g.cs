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
        [Trait("Table", "Breed")]
        [Trait("Area", "Integration")]
        public class BreedIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public BreedIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiBreedModelMapper mapper = new ApiBreedModelMapper();

                        UpdateResponse<ApiBreedResponseModel> updateResponse = await this.Client.BreedUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.BreedDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiBreedResponseModel response = await this.Client.BreedGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiBreedResponseModel> response = await this.Client.BreedAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiBreedResponseModel> CreateRecord()
                {
                        var model = new ApiBreedRequestModel();
                        model.SetProperties("B", 1);
                        CreateResponse<ApiBreedResponseModel> result = await this.Client.BreedCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.BreedDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>b1d215fe4dad5ef9fe9e15dbb563e801</Hash>
</Codenesium>*/