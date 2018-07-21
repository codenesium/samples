using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "SelfReference")]
        [Trait("Area", "Integration")]
        public class SelfReferenceIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public SelfReferenceIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiSelfReferenceModelMapper mapper = new ApiSelfReferenceModelMapper();

                        UpdateResponse<ApiSelfReferenceResponseModel> updateResponse = await this.Client.SelfReferenceUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.SelfReferenceDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiSelfReferenceResponseModel response = await this.Client.SelfReferenceGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiSelfReferenceResponseModel> response = await this.Client.SelfReferenceAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiSelfReferenceResponseModel> CreateRecord()
                {
                        var model = new ApiSelfReferenceRequestModel();
                        model.SetProperties(2, 2);
                        CreateResponse<ApiSelfReferenceResponseModel> result = await this.Client.SelfReferenceCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.SelfReferenceDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>a8001180741e76e0f059bdeff4ed02c0</Hash>
</Codenesium>*/