using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "SchemaBPerson")]
        [Trait("Area", "Integration")]
        public class SchemaBPersonIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public SchemaBPersonIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiSchemaBPersonModelMapper mapper = new ApiSchemaBPersonModelMapper();

                        UpdateResponse<ApiSchemaBPersonResponseModel> updateResponse = await this.Client.SchemaBPersonUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.SchemaBPersonDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiSchemaBPersonResponseModel response = await this.Client.SchemaBPersonGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiSchemaBPersonResponseModel> response = await this.Client.SchemaBPersonAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiSchemaBPersonResponseModel> CreateRecord()
                {
                        var model = new ApiSchemaBPersonRequestModel();
                        model.SetProperties("B");
                        CreateResponse<ApiSchemaBPersonResponseModel> result = await this.Client.SchemaBPersonCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.SchemaBPersonDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>59be81d54dc65f343d80df548b7f6787</Hash>
</Codenesium>*/