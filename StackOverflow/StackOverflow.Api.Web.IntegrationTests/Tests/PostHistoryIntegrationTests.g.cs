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
        [Trait("Table", "PostHistory")]
        [Trait("Area", "Integration")]
        public class PostHistoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public PostHistoryIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiPostHistoryModelMapper mapper = new ApiPostHistoryModelMapper();

                        UpdateResponse<ApiPostHistoryResponseModel> updateResponse = await this.Client.PostHistoryUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.PostHistoryDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiPostHistoryResponseModel response = await this.Client.PostHistoryGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiPostHistoryResponseModel> response = await this.Client.PostHistoryAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiPostHistoryResponseModel> CreateRecord()
                {
                        var model = new ApiPostHistoryRequestModel();
                        model.SetProperties("B", DateTime.Parse("1/1/1988 12:00:00 AM"), 2, 2, "B", "B", "B", 2);
                        CreateResponse<ApiPostHistoryResponseModel> result = await this.Client.PostHistoryCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.PostHistoryDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>1973108a6f28bdce79b3c6c610e150d9</Hash>
</Codenesium>*/