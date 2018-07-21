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
        [Trait("Table", "Password")]
        [Trait("Area", "Integration")]
        public class PasswordIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public PasswordIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiPasswordModelMapper mapper = new ApiPasswordModelMapper();

                        UpdateResponse<ApiPasswordResponseModel> updateResponse = await this.Client.PasswordUpdateAsync(model.BusinessEntityID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.PasswordDeleteAsync(model.BusinessEntityID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiPasswordResponseModel response = await this.Client.PasswordGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiPasswordResponseModel> response = await this.Client.PasswordAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiPasswordResponseModel> CreateRecord()
                {
                        var model = new ApiPasswordRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1988 12:00:00 AM"), "B", "B", Guid.Parse("3842cac4-b9a0-8223-0dcc-509a6f75849b"));
                        CreateResponse<ApiPasswordResponseModel> result = await this.Client.PasswordCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.PasswordDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>880208f50489363c17151b74a700d175</Hash>
</Codenesium>*/