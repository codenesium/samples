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
        [Trait("Table", "ProductVendor")]
        [Trait("Area", "Integration")]
        public class ProductVendorIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ProductVendorIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiProductVendorModelMapper mapper = new ApiProductVendorModelMapper();

                        UpdateResponse<ApiProductVendorResponseModel> updateResponse = await this.Client.ProductVendorUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ProductVendorDeleteAsync(model.ProductID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiProductVendorResponseModel response = await this.Client.ProductVendorGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiProductVendorResponseModel> response = await this.Client.ProductVendorAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiProductVendorResponseModel> CreateRecord()
                {
                        var model = new ApiProductVendorRequestModel();
                        model.SetProperties(2, 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, "B");
                        CreateResponse<ApiProductVendorResponseModel> result = await this.Client.ProductVendorCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ProductVendorDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>7fcc8de494a06dcde1ce93944f22c2ef</Hash>
</Codenesium>*/