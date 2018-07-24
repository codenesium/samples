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
        [Trait("Table", "BillOfMaterial")]
        [Trait("Area", "Integration")]
        public class BillOfMaterialIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public BillOfMaterialIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiBillOfMaterialModelMapper mapper = new ApiBillOfMaterialModelMapper();

                        UpdateResponse<ApiBillOfMaterialResponseModel> updateResponse = await this.Client.BillOfMaterialUpdateAsync(model.BillOfMaterialsID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.BillOfMaterialDeleteAsync(model.BillOfMaterialsID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiBillOfMaterialResponseModel response = await this.Client.BillOfMaterialGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiBillOfMaterialResponseModel> response = await this.Client.BillOfMaterialAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiBillOfMaterialResponseModel> CreateRecord()
                {
                        var model = new ApiBillOfMaterialRequestModel();
                        model.SetProperties(2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
                        CreateResponse<ApiBillOfMaterialResponseModel> result = await this.Client.BillOfMaterialCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.BillOfMaterialDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>5317d7a3c745cda0f6068e978b227c01</Hash>
</Codenesium>*/