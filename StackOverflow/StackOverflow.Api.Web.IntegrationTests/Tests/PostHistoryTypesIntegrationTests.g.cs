using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using StackOverflowNS.Api.Client;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "PostHistoryTypes")]
        [Trait("Area", "Integration")]
        public class PostHistoryTypesIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public PostHistoryTypesIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiPostHistoryTypesModelMapper mapper = new ApiPostHistoryTypesModelMapper();

                        UpdateResponse<ApiPostHistoryTypesResponseModel> updateResponse = await this.Client.PostHistoryTypesUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.PostHistoryTypesDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiPostHistoryTypesResponseModel response = await this.Client.PostHistoryTypesGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiPostHistoryTypesResponseModel> response = await this.Client.PostHistoryTypesAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiPostHistoryTypesResponseModel> CreateRecord()
                {
                        var model = new ApiPostHistoryTypesRequestModel();
                        model.SetProperties("B");
                        CreateResponse<ApiPostHistoryTypesResponseModel> result = await this.Client.PostHistoryTypesCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.PostHistoryTypesDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>873580abf94e9735e181aaed8085d254</Hash>
</Codenesium>*/