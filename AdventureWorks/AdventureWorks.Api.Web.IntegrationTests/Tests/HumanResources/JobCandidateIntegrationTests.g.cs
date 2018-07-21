using AdventureWorksNS.Api.Client;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "JobCandidate")]
        [Trait("Area", "Integration")]
        public class JobCandidateIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public JobCandidateIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiJobCandidateModelMapper mapper = new ApiJobCandidateModelMapper();

                        UpdateResponse<ApiJobCandidateResponseModel> updateResponse = await this.Client.JobCandidateUpdateAsync(model.JobCandidateID, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.JobCandidateDeleteAsync(model.JobCandidateID);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiJobCandidateResponseModel response = await this.Client.JobCandidateGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiJobCandidateResponseModel> response = await this.Client.JobCandidateAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiJobCandidateResponseModel> CreateRecord()
                {
                        var model = new ApiJobCandidateRequestModel();
                        model.SetProperties(2, DateTime.Parse("1/1/1988 12:00:00 AM"), "B");
                        CreateResponse<ApiJobCandidateResponseModel> result = await this.Client.JobCandidateCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.JobCandidateDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>c22726bf39d69e0f6b9f2cd9e08aa692</Hash>
</Codenesium>*/