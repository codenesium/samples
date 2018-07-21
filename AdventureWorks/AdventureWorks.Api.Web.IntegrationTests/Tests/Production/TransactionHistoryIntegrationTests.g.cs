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
        [Trait("Table", "TransactionHistory")]
        [Trait("Area", "Integration")]
        public class TransactionHistoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public TransactionHistoryIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiTransactionHistoryModelMapper mapper = new ApiTransactionHistoryModelMapper();

                        UpdateResponse<ApiTransactionHistoryResponseModel> updateResponse = await this.Client.TransactionHistoryUpdateAsync(model.TransactionID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.TransactionHistoryDeleteAsync(model.TransactionID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiTransactionHistoryResponseModel response = await this.Client.TransactionHistoryGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiTransactionHistoryResponseModel> response = await this.Client.TransactionHistoryAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiTransactionHistoryResponseModel> CreateRecord()
                {
                        var model = new ApiTransactionHistoryRequestModel();
                        model.SetProperties(3810.59m, DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
                        CreateResponse<ApiTransactionHistoryResponseModel> result = await this.Client.TransactionHistoryCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.TransactionHistoryDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>5aac6d0485fec75fce23b7d285731e77</Hash>
</Codenesium>*/