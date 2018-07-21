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
        [Trait("Table", "Species")]
        [Trait("Area", "Integration")]
        public class SpeciesIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public SpeciesIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiSpeciesModelMapper mapper = new ApiSpeciesModelMapper();

                        UpdateResponse<ApiSpeciesResponseModel> updateResponse = await this.Client.SpeciesUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.SpeciesDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiSpeciesResponseModel response = await this.Client.SpeciesGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiSpeciesResponseModel> response = await this.Client.SpeciesAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiSpeciesResponseModel> CreateRecord()
                {
                        var model = new ApiSpeciesRequestModel();
                        model.SetProperties("B");
                        CreateResponse<ApiSpeciesResponseModel> result = await this.Client.SpeciesCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.SpeciesDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>6b71b58ea1821dca3bcddfa121ae27f2</Hash>
</Codenesium>*/