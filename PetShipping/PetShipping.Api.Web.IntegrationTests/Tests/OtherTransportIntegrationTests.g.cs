using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PetShippingNS.Api.Client;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "OtherTransport")]
        [Trait("Area", "Integration")]
        public class OtherTransportIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public OtherTransportIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiOtherTransportModelMapper mapper = new ApiOtherTransportModelMapper();

                        UpdateResponse<ApiOtherTransportResponseModel> updateResponse = await this.Client.OtherTransportUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.OtherTransportDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiOtherTransportResponseModel response = await this.Client.OtherTransportGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiOtherTransportResponseModel> response = await this.Client.OtherTransportAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiOtherTransportResponseModel> CreateRecord()
                {
                        var model = new ApiOtherTransportRequestModel();
                        model.SetProperties(1, 1);
                        CreateResponse<ApiOtherTransportResponseModel> result = await this.Client.OtherTransportCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.OtherTransportDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>ff88f2ad2bb5bce709fb48e1d17861c2</Hash>
</Codenesium>*/