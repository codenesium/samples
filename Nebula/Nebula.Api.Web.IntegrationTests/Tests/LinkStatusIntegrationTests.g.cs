using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NebulaNS.Api.Client;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "LinkStatus")]
        [Trait("Area", "Integration")]
        public class LinkStatusIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public LinkStatusIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiLinkStatusModelMapper mapper = new ApiLinkStatusModelMapper();

                        UpdateResponse<ApiLinkStatusResponseModel> updateResponse = await this.Client.LinkStatusUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.LinkStatusDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiLinkStatusResponseModel response = await this.Client.LinkStatusGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiLinkStatusResponseModel> response = await this.Client.LinkStatusAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiLinkStatusResponseModel> CreateRecord()
                {
                        var model = new ApiLinkStatusRequestModel();
                        model.SetProperties("B");
                        CreateResponse<ApiLinkStatusResponseModel> result = await this.Client.LinkStatusCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.LinkStatusDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>05b0f6a723006cb9a13b1e33cdc78812</Hash>
</Codenesium>*/