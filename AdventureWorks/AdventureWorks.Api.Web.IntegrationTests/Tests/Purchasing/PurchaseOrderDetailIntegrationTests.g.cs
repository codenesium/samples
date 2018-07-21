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
        [Trait("Table", "PurchaseOrderDetail")]
        [Trait("Area", "Integration")]
        public class PurchaseOrderDetailIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public PurchaseOrderDetailIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiPurchaseOrderDetailModelMapper mapper = new ApiPurchaseOrderDetailModelMapper();

                        UpdateResponse<ApiPurchaseOrderDetailResponseModel> updateResponse = await this.Client.PurchaseOrderDetailUpdateAsync(model.PurchaseOrderID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.PurchaseOrderDetailDeleteAsync(model.PurchaseOrderID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiPurchaseOrderDetailResponseModel response = await this.Client.PurchaseOrderDetailGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiPurchaseOrderDetailResponseModel> response = await this.Client.PurchaseOrderDetailAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiPurchaseOrderDetailResponseModel> CreateRecord()
                {
                        var model = new ApiPurchaseOrderDetailRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 3810.59m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 3810.59m, 3810.59m, 3810.59m, 3810.59m);
                        CreateResponse<ApiPurchaseOrderDetailResponseModel> result = await this.Client.PurchaseOrderDetailCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.PurchaseOrderDetailDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>7321f2c2c32af3006d9c8d807b105a95</Hash>
</Codenesium>*/