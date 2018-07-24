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
        [Trait("Table", "SalesTaxRate")]
        [Trait("Area", "Integration")]
        public class SalesTaxRateIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public SalesTaxRateIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiSalesTaxRateModelMapper mapper = new ApiSalesTaxRateModelMapper();

                        UpdateResponse<ApiSalesTaxRateResponseModel> updateResponse = await this.Client.SalesTaxRateUpdateAsync(model.SalesTaxRateID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.SalesTaxRateDeleteAsync(model.SalesTaxRateID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiSalesTaxRateResponseModel response = await this.Client.SalesTaxRateGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiSalesTaxRateResponseModel> response = await this.Client.SalesTaxRateAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiSalesTaxRateResponseModel> CreateRecord()
                {
                        var model = new ApiSalesTaxRateRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 2, 2m, 2);
                        CreateResponse<ApiSalesTaxRateResponseModel> result = await this.Client.SalesTaxRateCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.SalesTaxRateDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>d0f99290ed25e8823dd604caf07576fc</Hash>
</Codenesium>*/