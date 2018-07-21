using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StackOverflowNS.Api.Client;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "LinkTypes")]
        [Trait("Area", "Integration")]
        public class LinkTypesIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public LinkTypesIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiLinkTypesModelMapper mapper = new ApiLinkTypesModelMapper();

                        UpdateResponse<ApiLinkTypesResponseModel> updateResponse = await this.Client.LinkTypesUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.LinkTypesDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiLinkTypesResponseModel response = await this.Client.LinkTypesGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiLinkTypesResponseModel> response = await this.Client.LinkTypesAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiLinkTypesResponseModel> CreateRecord()
                {
                        var model = new ApiLinkTypesRequestModel();
                        model.SetProperties("B");
                        CreateResponse<ApiLinkTypesResponseModel> result = await this.Client.LinkTypesCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.LinkTypesDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>ff110f0556fa81e57f556b008915f76d</Hash>
</Codenesium>*/