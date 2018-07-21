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
        [Trait("Table", "ProductProductPhoto")]
        [Trait("Area", "Integration")]
        public class ProductProductPhotoIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ProductProductPhotoIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiProductProductPhotoModelMapper mapper = new ApiProductProductPhotoModelMapper();

                        UpdateResponse<ApiProductProductPhotoResponseModel> updateResponse = await this.Client.ProductProductPhotoUpdateAsync(model.ProductID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ProductProductPhotoDeleteAsync(model.ProductID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiProductProductPhotoResponseModel response = await this.Client.ProductProductPhotoGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiProductProductPhotoResponseModel> response = await this.Client.ProductProductPhotoAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiProductProductPhotoResponseModel> CreateRecord()
                {
                        var model = new ApiProductProductPhotoRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), true, 2);
                        CreateResponse<ApiProductProductPhotoResponseModel> result = await this.Client.ProductProductPhotoCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ProductProductPhotoDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>7972917d96695f4422787c05ac2f58d7</Hash>
</Codenesium>*/