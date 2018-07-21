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
        [Trait("Table", "WorkerTaskLease")]
        [Trait("Area", "Integration")]
        public class WorkerTaskLeaseIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public WorkerTaskLeaseIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiWorkerTaskLeaseModelMapper mapper = new ApiWorkerTaskLeaseModelMapper();

                        UpdateResponse<ApiWorkerTaskLeaseResponseModel> updateResponse = await this.Client.WorkerTaskLeaseUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.WorkerTaskLeaseDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiWorkerTaskLeaseResponseModel response = await this.Client.WorkerTaskLeaseGetAsync("A");

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiWorkerTaskLeaseResponseModel> response = await this.Client.WorkerTaskLeaseAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiWorkerTaskLeaseResponseModel> CreateRecord()
                {
                        var model = new ApiWorkerTaskLeaseRequestModel();
                        model.SetProperties(true, "B", "B", "B", "B");
                        CreateResponse<ApiWorkerTaskLeaseResponseModel> result = await this.Client.WorkerTaskLeaseCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.WorkerTaskLeaseDeleteAsync("B");
                }
        }
}

/*<Codenesium>
    <Hash>84a27b9f7517b84369b936836114577e</Hash>
</Codenesium>*/