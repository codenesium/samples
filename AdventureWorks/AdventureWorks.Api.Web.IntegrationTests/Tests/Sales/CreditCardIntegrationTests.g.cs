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
        [Trait("Table", "CreditCard")]
        [Trait("Area", "Integration")]
        public class CreditCardIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public CreditCardIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiCreditCardModelMapper mapper = new ApiCreditCardModelMapper();

                        UpdateResponse<ApiCreditCardResponseModel> updateResponse = await this.Client.CreditCardUpdateAsync(model.CreditCardID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.CreditCardDeleteAsync(model.CreditCardID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiCreditCardResponseModel response = await this.Client.CreditCardGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiCreditCardResponseModel> response = await this.Client.CreditCardAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiCreditCardResponseModel> CreateRecord()
                {
                        var model = new ApiCreditCardRequestModel();
                        model.SetProperties("B", "B", 2, 2, DateTime.Parse("1/1/1988 12:00:00 AM"));
                        CreateResponse<ApiCreditCardResponseModel> result = await this.Client.CreditCardCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.CreditCardDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>5ab4f33d8a39fc99b5a8c1ec2d56c9a2</Hash>
</Codenesium>*/