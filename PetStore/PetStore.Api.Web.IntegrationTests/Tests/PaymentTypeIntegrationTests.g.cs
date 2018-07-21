using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetStoreNS.Api.Client;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetStoreNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "PaymentType")]
        [Trait("Area", "Integration")]
        public class PaymentTypeIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public PaymentTypeIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiPaymentTypeModelMapper mapper = new ApiPaymentTypeModelMapper();

                        UpdateResponse<ApiPaymentTypeResponseModel> updateResponse = await this.Client.PaymentTypeUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.PaymentTypeDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiPaymentTypeResponseModel response = await this.Client.PaymentTypeGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiPaymentTypeResponseModel> response = await this.Client.PaymentTypeAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiPaymentTypeResponseModel> CreateRecord()
                {
                        var model = new ApiPaymentTypeRequestModel();
                        model.SetProperties("B");
                        CreateResponse<ApiPaymentTypeResponseModel> result = await this.Client.PaymentTypeCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.PaymentTypeDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>c11f8584726abffa6ecad172338a7717</Hash>
</Codenesium>*/