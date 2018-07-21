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
        [Trait("Table", "Artifact")]
        [Trait("Area", "Integration")]
        public class ArtifactIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ArtifactIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiArtifactModelMapper mapper = new ApiArtifactModelMapper();

                        UpdateResponse<ApiArtifactResponseModel> updateResponse = await this.Client.ArtifactUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ArtifactDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiArtifactResponseModel response = await this.Client.ArtifactGetAsync("A");

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiArtifactResponseModel> response = await this.Client.ArtifactAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiArtifactResponseModel> CreateRecord()
                {
                        var model = new ApiArtifactRequestModel();
                        model.SetProperties(DateTimeOffset.Parse("1/1/1988 12:00:00 AM"), "B", "B", "B", "B", "B", "B");
                        CreateResponse<ApiArtifactResponseModel> result = await this.Client.ArtifactCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ArtifactDeleteAsync("B");
                }
        }
}

/*<Codenesium>
    <Hash>02451e64dee0df6ce683429098758087</Hash>
</Codenesium>*/