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
        [Trait("Table", "Project")]
        [Trait("Area", "Integration")]
        public class ProjectIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ProjectIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiProjectModelMapper mapper = new ApiProjectModelMapper();

                        UpdateResponse<ApiProjectResponseModel> updateResponse = await this.Client.ProjectUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ProjectDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiProjectResponseModel response = await this.Client.ProjectGetAsync("A");

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiProjectResponseModel> response = await this.Client.ProjectAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiProjectResponseModel> CreateRecord()
                {
                        var model = new ApiProjectRequestModel();
                        model.SetProperties(true, BitConverter.GetBytes(2), "B", true, "B", true, "B", "B", "B", "B", "B", "B");
                        CreateResponse<ApiProjectResponseModel> result = await this.Client.ProjectCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ProjectDeleteAsync("B");
                }
        }
}

/*<Codenesium>
    <Hash>ff201b2d8dfb8a6f50a4fd67bbc0f893</Hash>
</Codenesium>*/