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
        [Trait("Table", "ActionTemplateVersion")]
        [Trait("Area", "Integration")]
        public class ActionTemplateVersionIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public ActionTemplateVersionIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiActionTemplateVersionModelMapper mapper = new ApiActionTemplateVersionModelMapper();

                        UpdateResponse<ApiActionTemplateVersionResponseModel> updateResponse = await this.Client.ActionTemplateVersionUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.ActionTemplateVersionDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiActionTemplateVersionResponseModel response = await this.Client.ActionTemplateVersionGetAsync("A");

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiActionTemplateVersionResponseModel> response = await this.Client.ActionTemplateVersionAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiActionTemplateVersionResponseModel> CreateRecord()
                {
                        var model = new ApiActionTemplateVersionRequestModel();
                        model.SetProperties("B", "B", "B", "B", 2);
                        CreateResponse<ApiActionTemplateVersionResponseModel> result = await this.Client.ActionTemplateVersionCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.ActionTemplateVersionDeleteAsync("B");
                }
        }
}

/*<Codenesium>
    <Hash>4b078b0a99032f6d90c467c8c4a9b2b1</Hash>
</Codenesium>*/