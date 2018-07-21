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
        [Trait("Table", "AddressType")]
        [Trait("Area", "Integration")]
        public class AddressTypeIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public AddressTypeIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiAddressTypeModelMapper mapper = new ApiAddressTypeModelMapper();

                        UpdateResponse<ApiAddressTypeResponseModel> updateResponse = await this.Client.AddressTypeUpdateAsync(model.AddressTypeID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.AddressTypeDeleteAsync(model.AddressTypeID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiAddressTypeResponseModel response = await this.Client.AddressTypeGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiAddressTypeResponseModel> response = await this.Client.AddressTypeAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiAddressTypeResponseModel> CreateRecord()
                {
                        var model = new ApiAddressTypeRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
                        CreateResponse<ApiAddressTypeResponseModel> result = await this.Client.AddressTypeCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.AddressTypeDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>299789e942cc2abca3f67769270a951f</Hash>
</Codenesium>*/