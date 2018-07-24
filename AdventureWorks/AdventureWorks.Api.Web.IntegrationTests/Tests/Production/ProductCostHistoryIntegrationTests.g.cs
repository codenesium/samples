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
        [Trait("Table", "ProductCostHistory")]
        [Trait("Area", "Integration")]
        public class ProductCostHistoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ProductCostHistoryIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiProductCostHistoryModelMapper mapper = new ApiProductCostHistoryModelMapper();

                        UpdateResponse<ApiProductCostHistoryResponseModel> updateResponse = await this.Client.ProductCostHistoryUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ProductCostHistoryDeleteAsync(model.ProductID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiProductCostHistoryResponseModel response = await this.Client.ProductCostHistoryGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiProductCostHistoryResponseModel> response = await this.Client.ProductCostHistoryAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiProductCostHistoryResponseModel> CreateRecord()
                {
                        var model = new ApiProductCostHistoryRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2m, DateTime.Parse("1/1/1988 12:00:00 AM"));
                        CreateResponse<ApiProductCostHistoryResponseModel> result = await this.Client.ProductCostHistoryCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ProductCostHistoryDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>92bc8e9e49ced7609055a66f09f827ae</Hash>
</Codenesium>*/