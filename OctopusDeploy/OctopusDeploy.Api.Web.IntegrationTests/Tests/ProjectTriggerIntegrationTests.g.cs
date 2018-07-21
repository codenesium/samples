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
        [Trait("Table", "ProjectTrigger")]
        [Trait("Area", "Integration")]
        public class ProjectTriggerIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ProjectTriggerIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiProjectTriggerModelMapper mapper = new ApiProjectTriggerModelMapper();

                        UpdateResponse<ApiProjectTriggerResponseModel> updateResponse = await this.Client.ProjectTriggerUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ProjectTriggerDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiProjectTriggerResponseModel response = await this.Client.ProjectTriggerGetAsync("A");

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiProjectTriggerResponseModel> response = await this.Client.ProjectTriggerAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiProjectTriggerResponseModel> CreateRecord()
                {
                        var model = new ApiProjectTriggerRequestModel();
                        model.SetProperties(true, "B", "B", "B", "B");
                        CreateResponse<ApiProjectTriggerResponseModel> result = await this.Client.ProjectTriggerCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ProjectTriggerDeleteAsync("B");
                }
        }
}

/*<Codenesium>
    <Hash>2bc417a9ef2af6806f3e5ffcc539bac0</Hash>
</Codenesium>*/