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
        [Trait("Table", "LinkLog")]
        [Trait("Area", "Integration")]
        public class LinkLogIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public LinkLogIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiLinkLogModelMapper mapper = new ApiLinkLogModelMapper();

                        UpdateResponse<ApiLinkLogResponseModel> updateResponse = await this.Client.LinkLogUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.LinkLogDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiLinkLogResponseModel response = await this.Client.LinkLogGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiLinkLogResponseModel> response = await this.Client.LinkLogAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiLinkLogResponseModel> CreateRecord()
                {
                        var model = new ApiLinkLogRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 1, "B");
                        CreateResponse<ApiLinkLogResponseModel> result = await this.Client.LinkLogCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.LinkLogDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>b584165a08effca584dee071f7912a63</Hash>
</Codenesium>*/