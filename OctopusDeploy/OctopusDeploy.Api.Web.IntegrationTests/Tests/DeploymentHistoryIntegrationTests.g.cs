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
        [Trait("Table", "DeploymentHistory")]
        [Trait("Area", "Integration")]
        public class DeploymentHistoryIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public DeploymentHistoryIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiDeploymentHistoryModelMapper mapper = new ApiDeploymentHistoryModelMapper();

                        UpdateResponse<ApiDeploymentHistoryResponseModel> updateResponse = await this.Client.DeploymentHistoryUpdateAsync(model.DeploymentId, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.DeploymentHistoryDeleteAsync(model.DeploymentId);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiDeploymentHistoryResponseModel response = await this.Client.DeploymentHistoryGetAsync("A");

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiDeploymentHistoryResponseModel> response = await this.Client.DeploymentHistoryAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiDeploymentHistoryResponseModel> CreateRecord()
                {
                        var model = new ApiDeploymentHistoryRequestModel();
                        model.SetProperties("B", "B", DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B", 2, "B", "B", "B", "B", "B", DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B", DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B");
                        CreateResponse<ApiDeploymentHistoryResponseModel> result = await this.Client.DeploymentHistoryCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.DeploymentHistoryDeleteAsync("B");
                }
        }
}

/*<Codenesium>
    <Hash>5d48ee50d924340dfb302b7770aeec14</Hash>
</Codenesium>*/