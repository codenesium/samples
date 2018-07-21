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
        [Trait("Table", "DeploymentEnvironment")]
        [Trait("Area", "Integration")]
        public class DeploymentEnvironmentIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public DeploymentEnvironmentIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiDeploymentEnvironmentModelMapper mapper = new ApiDeploymentEnvironmentModelMapper();

                        UpdateResponse<ApiDeploymentEnvironmentResponseModel> updateResponse = await this.Client.DeploymentEnvironmentUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.DeploymentEnvironmentDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiDeploymentEnvironmentResponseModel response = await this.Client.DeploymentEnvironmentGetAsync("A");

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiDeploymentEnvironmentResponseModel> response = await this.Client.DeploymentEnvironmentAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiDeploymentEnvironmentResponseModel> CreateRecord()
                {
                        var model = new ApiDeploymentEnvironmentRequestModel();
                        model.SetProperties(BitConverter.GetBytes(2), "B", "B", 2);
                        CreateResponse<ApiDeploymentEnvironmentResponseModel> result = await this.Client.DeploymentEnvironmentCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.DeploymentEnvironmentDeleteAsync("B");
                }
        }
}

/*<Codenesium>
    <Hash>8ec8bdee6264cf9451f1c389ccd6e230</Hash>
</Codenesium>*/