using FermataFishNS.Api.Client;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Space")]
        [Trait("Area", "Integration")]
        public class SpaceIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public SpaceIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiSpaceModelMapper mapper = new ApiSpaceModelMapper();

                        UpdateResponse<ApiSpaceResponseModel> updateResponse = await this.Client.SpaceUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.SpaceDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiSpaceResponseModel response = await this.Client.SpaceGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiSpaceResponseModel> response = await this.Client.SpaceAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiSpaceResponseModel> CreateRecord()
                {
                        var model = new ApiSpaceRequestModel();
                        model.SetProperties("B", "B", 1);
                        CreateResponse<ApiSpaceResponseModel> result = await this.Client.SpaceCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.SpaceDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>2fa517d4fc2b0e92d0912fcbe91a9a29</Hash>
</Codenesium>*/