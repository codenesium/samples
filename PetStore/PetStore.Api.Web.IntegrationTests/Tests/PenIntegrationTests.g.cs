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
        [Trait("Table", "Pen")]
        [Trait("Area", "Integration")]
        public class PenIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public PenIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiPenModelMapper mapper = new ApiPenModelMapper();

                        UpdateResponse<ApiPenResponseModel> updateResponse = await this.Client.PenUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.PenDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiPenResponseModel response = await this.Client.PenGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiPenResponseModel> response = await this.Client.PenAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiPenResponseModel> CreateRecord()
                {
                        var model = new ApiPenRequestModel();
                        model.SetProperties("B");
                        CreateResponse<ApiPenResponseModel> result = await this.Client.PenCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.PenDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>4c20a293a4682aefa2b869b589552e5a</Hash>
</Codenesium>*/