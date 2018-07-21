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
        [Trait("Table", "DeploymentRelatedMachine")]
        [Trait("Area", "Integration")]
        public class DeploymentRelatedMachineIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public DeploymentRelatedMachineIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiDeploymentRelatedMachineModelMapper mapper = new ApiDeploymentRelatedMachineModelMapper();

                        UpdateResponse<ApiDeploymentRelatedMachineResponseModel> updateResponse = await this.Client.DeploymentRelatedMachineUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.DeploymentRelatedMachineDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiDeploymentRelatedMachineResponseModel response = await this.Client.DeploymentRelatedMachineGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiDeploymentRelatedMachineResponseModel> response = await this.Client.DeploymentRelatedMachineAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiDeploymentRelatedMachineResponseModel> CreateRecord()
                {
                        var model = new ApiDeploymentRelatedMachineRequestModel();
                        model.SetProperties("A", "B");
                        CreateResponse<ApiDeploymentRelatedMachineResponseModel> result = await this.Client.DeploymentRelatedMachineCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.DeploymentRelatedMachineDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>5286fa70036bffb3691b662e4315973b</Hash>
</Codenesium>*/