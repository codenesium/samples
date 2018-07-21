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
        [Trait("Table", "Tags")]
        [Trait("Area", "Integration")]
        public class TagsIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public TagsIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiTagsModelMapper mapper = new ApiTagsModelMapper();

                        UpdateResponse<ApiTagsResponseModel> updateResponse = await this.Client.TagsUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.TagsDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiTagsResponseModel response = await this.Client.TagsGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiTagsResponseModel> response = await this.Client.TagsAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiTagsResponseModel> CreateRecord()
                {
                        var model = new ApiTagsRequestModel();
                        model.SetProperties(2, 2, "B", 2);
                        CreateResponse<ApiTagsResponseModel> result = await this.Client.TagsCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.TagsDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>e2096335e1dfbe8d0f0ee1946aaadb2c</Hash>
</Codenesium>*/