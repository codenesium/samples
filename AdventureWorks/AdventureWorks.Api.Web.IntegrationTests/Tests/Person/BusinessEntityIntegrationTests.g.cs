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
        [Trait("Table", "BusinessEntity")]
        [Trait("Area", "Integration")]
        public class BusinessEntityIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public BusinessEntityIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiBusinessEntityModelMapper mapper = new ApiBusinessEntityModelMapper();

                        UpdateResponse<ApiBusinessEntityResponseModel> updateResponse = await this.Client.BusinessEntityUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.BusinessEntityDeleteAsync(model.BusinessEntityID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiBusinessEntityResponseModel response = await this.Client.BusinessEntityGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiBusinessEntityResponseModel> response = await this.Client.BusinessEntityAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiBusinessEntityResponseModel> CreateRecord()
                {
                        var model = new ApiBusinessEntityRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
                        CreateResponse<ApiBusinessEntityResponseModel> result = await this.Client.BusinessEntityCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.BusinessEntityDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>88e9dcf0ff5047cdc6cd5a556f55455b</Hash>
</Codenesium>*/