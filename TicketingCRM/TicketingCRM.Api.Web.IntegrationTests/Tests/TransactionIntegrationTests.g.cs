using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "Transaction")]
        [Trait("Area", "Integration")]
        public class TransactionIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public TransactionIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiTransactionModelMapper mapper = new ApiTransactionModelMapper();

                        UpdateResponse<ApiTransactionResponseModel> updateResponse = await this.Client.TransactionUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.TransactionDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiTransactionResponseModel response = await this.Client.TransactionGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiTransactionResponseModel> response = await this.Client.TransactionAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiTransactionResponseModel> CreateRecord()
                {
                        var model = new ApiTransactionRequestModel();
                        model.SetProperties(2m, "B", 1);
                        CreateResponse<ApiTransactionResponseModel> result = await this.Client.TransactionCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.TransactionDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>0334c5311fa81b02204485469ed11d02</Hash>
</Codenesium>*/