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
        [Trait("Table", "Store")]
        [Trait("Area", "Integration")]
        public class StoreIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public StoreIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiStoreModelMapper mapper = new ApiStoreModelMapper();

                        UpdateResponse<ApiStoreResponseModel> updateResponse = await this.Client.StoreUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.StoreDeleteAsync(model.BusinessEntityID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiStoreResponseModel response = await this.Client.StoreGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiStoreResponseModel> response = await this.Client.StoreAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiStoreResponseModel> CreateRecord()
                {
                        var model = new ApiStoreRequestModel();
                        model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"), 1);
                        CreateResponse<ApiStoreResponseModel> result = await this.Client.StoreCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.StoreDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>c93da3263e26e5bd8241a06b9af98819</Hash>
</Codenesium>*/