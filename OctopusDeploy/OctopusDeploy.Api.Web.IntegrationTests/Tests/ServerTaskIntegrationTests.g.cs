using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using OctopusDeployNS.Api.Client;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "ServerTask")]
        [Trait("Area", "Integration")]
        public class ServerTaskIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ServerTaskIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiServerTaskModelMapper mapper = new ApiServerTaskModelMapper();

                        UpdateResponse<ApiServerTaskResponseModel> updateResponse = await this.Client.ServerTaskUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ServerTaskDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiServerTaskResponseModel response = await this.Client.ServerTaskGetAsync("A");

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiServerTaskResponseModel> response = await this.Client.ServerTaskAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiServerTaskResponseModel> CreateRecord()
                {
                        var model = new ApiServerTaskRequestModel();
                        model.SetProperties(DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B", 2, "B", "B", true, true, "B", "B", "B", DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B");
                        CreateResponse<ApiServerTaskResponseModel> result = await this.Client.ServerTaskCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ServerTaskDeleteAsync("B");
                }
        }
}

/*<Codenesium>
    <Hash>2c9f977bc4c8f79bc34de46c7ae4c3f7</Hash>
</Codenesium>*/