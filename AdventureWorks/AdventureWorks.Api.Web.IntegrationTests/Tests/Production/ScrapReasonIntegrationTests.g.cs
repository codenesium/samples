using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "ScrapReason")]
        [Trait("Area", "Integration")]
        public class ScrapReasonIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ScrapReasonIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiScrapReasonModelMapper mapper = new ApiScrapReasonModelMapper();

                        UpdateResponse<ApiScrapReasonResponseModel> updateResponse = await this.Client.ScrapReasonUpdateAsync(model.ScrapReasonID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ScrapReasonDeleteAsync(model.ScrapReasonID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiScrapReasonResponseModel response = await this.Client.ScrapReasonGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiScrapReasonResponseModel> response = await this.Client.ScrapReasonAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiScrapReasonResponseModel> CreateRecord()
                {
                        var model = new ApiScrapReasonRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
                        CreateResponse<ApiScrapReasonResponseModel> result = await this.Client.ScrapReasonCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ScrapReasonDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>c9374dff3672ae14778ecf4cad55f65b</Hash>
</Codenesium>*/