using FermataFishNS.Api.Client;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FermataFishNS.Api.Web.IntegrationTests
{
        [Trait("Type", "Integration")]
        [Trait("Table", "LessonStatus")]
        [Trait("Area", "Integration")]
        public class LessonStatusIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public LessonStatusIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiLessonStatusModelMapper mapper = new ApiLessonStatusModelMapper();

                        UpdateResponse<ApiLessonStatusResponseModel> updateResponse = await this.Client.LessonStatusUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.LessonStatusDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiLessonStatusResponseModel response = await this.Client.LessonStatusGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiLessonStatusResponseModel> response = await this.Client.LessonStatusAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiLessonStatusResponseModel> CreateRecord()
                {
                        var model = new ApiLessonStatusRequestModel();
                        model.SetProperties("B", 1);
                        CreateResponse<ApiLessonStatusResponseModel> result = await this.Client.LessonStatusCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.LessonStatusDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>959dea4f8dcea4353822fe17280d8039</Hash>
</Codenesium>*/