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
        [Trait("Table", "ProductReview")]
        [Trait("Area", "Integration")]
        public class ProductReviewIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ProductReviewIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiProductReviewModelMapper mapper = new ApiProductReviewModelMapper();

                        UpdateResponse<ApiProductReviewResponseModel> updateResponse = await this.Client.ProductReviewUpdateAsync(model.ProductReviewID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ProductReviewDeleteAsync(model.ProductReviewID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiProductReviewResponseModel response = await this.Client.ProductReviewGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiProductReviewResponseModel> response = await this.Client.ProductReviewAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiProductReviewResponseModel> CreateRecord()
                {
                        var model = new ApiProductReviewRequestModel();
                        model.SetProperties("B", "B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
                        CreateResponse<ApiProductReviewResponseModel> result = await this.Client.ProductReviewCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ProductReviewDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>de1873070cba6ffff2f7848cde2aa136</Hash>
</Codenesium>*/