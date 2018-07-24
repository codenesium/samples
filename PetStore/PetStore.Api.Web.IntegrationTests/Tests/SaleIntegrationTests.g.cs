using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetStoreNS.Api.Client;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Sale")]
        [Trait("Area", "Integration")]
        public class SaleIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public SaleIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiSaleModelMapper mapper = new ApiSaleModelMapper();

                        UpdateResponse<ApiSaleResponseModel> updateResponse = await this.Client.SaleUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.SaleDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiSaleResponseModel response = await this.Client.SaleGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiSaleResponseModel> response = await this.Client.SaleAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiSaleResponseModel> CreateRecord()
                {
                        var model = new ApiSaleRequestModel();
                        model.SetProperties(2m, "B", "B", 1, 1, "B");
                        CreateResponse<ApiSaleResponseModel> result = await this.Client.SaleCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.SaleDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>413a62926aafdd14a0d19e3f039d99cd</Hash>
</Codenesium>*/