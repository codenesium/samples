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
        [Trait("Table", "EmployeePayHistory")]
        [Trait("Area", "Integration")]
        public class EmployeePayHistoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public EmployeePayHistoryIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiEmployeePayHistoryModelMapper mapper = new ApiEmployeePayHistoryModelMapper();

                        UpdateResponse<ApiEmployeePayHistoryResponseModel> updateResponse = await this.Client.EmployeePayHistoryUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.EmployeePayHistoryDeleteAsync(model.BusinessEntityID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiEmployeePayHistoryResponseModel response = await this.Client.EmployeePayHistoryGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiEmployeePayHistoryResponseModel> response = await this.Client.EmployeePayHistoryAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiEmployeePayHistoryResponseModel> CreateRecord()
                {
                        var model = new ApiEmployeePayHistoryRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2m, DateTime.Parse("1/1/1988 12:00:00 AM"));
                        CreateResponse<ApiEmployeePayHistoryResponseModel> result = await this.Client.EmployeePayHistoryCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.EmployeePayHistoryDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>a32a0a1bca30397dd6676ef0cc08e003</Hash>
</Codenesium>*/