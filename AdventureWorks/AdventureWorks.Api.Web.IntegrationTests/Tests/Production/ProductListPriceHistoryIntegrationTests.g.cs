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
        [Trait("Table", "ProductListPriceHistory")]
        [Trait("Area", "Integration")]
        public class ProductListPriceHistoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ProductListPriceHistoryIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiProductListPriceHistoryModelMapper mapper = new ApiProductListPriceHistoryModelMapper();

                        UpdateResponse<ApiProductListPriceHistoryResponseModel> updateResponse = await this.Client.ProductListPriceHistoryUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ProductListPriceHistoryDeleteAsync(model.ProductID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiProductListPriceHistoryResponseModel response = await this.Client.ProductListPriceHistoryGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiProductListPriceHistoryResponseModel> response = await this.Client.ProductListPriceHistoryAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiProductListPriceHistoryResponseModel> CreateRecord()
                {
                        var model = new ApiProductListPriceHistoryRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"));
                        CreateResponse<ApiProductListPriceHistoryResponseModel> result = await this.Client.ProductListPriceHistoryCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ProductListPriceHistoryDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>27e162b45524952aac997e1a09b92135</Hash>
</Codenesium>*/