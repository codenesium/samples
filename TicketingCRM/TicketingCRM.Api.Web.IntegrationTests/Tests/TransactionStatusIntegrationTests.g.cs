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
        [Trait("Table", "TransactionStatus")]
        [Trait("Area", "Integration")]
        public class TransactionStatusIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public TransactionStatusIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiTransactionStatusModelMapper mapper = new ApiTransactionStatusModelMapper();

                        UpdateResponse<ApiTransactionStatusResponseModel> updateResponse = await this.Client.TransactionStatusUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.TransactionStatusDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiTransactionStatusResponseModel response = await this.Client.TransactionStatusGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiTransactionStatusResponseModel> response = await this.Client.TransactionStatusAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiTransactionStatusResponseModel> CreateRecord()
                {
                        var model = new ApiTransactionStatusRequestModel();
                        model.SetProperties("B");
                        CreateResponse<ApiTransactionStatusResponseModel> result = await this.Client.TransactionStatusCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.TransactionStatusDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>4a50da7adb44370315fcff5d5c577321</Hash>
</Codenesium>*/