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
        [Trait("Table", "LessonXTeacher")]
        [Trait("Area", "Integration")]
        public class LessonXTeacherIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public LessonXTeacherIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiLessonXTeacherModelMapper mapper = new ApiLessonXTeacherModelMapper();

                        UpdateResponse<ApiLessonXTeacherResponseModel> updateResponse = await this.Client.LessonXTeacherUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.LessonXTeacherDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiLessonXTeacherResponseModel response = await this.Client.LessonXTeacherGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiLessonXTeacherResponseModel> response = await this.Client.LessonXTeacherAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiLessonXTeacherResponseModel> CreateRecord()
                {
                        var model = new ApiLessonXTeacherRequestModel();
                        model.SetProperties(1, 1);
                        CreateResponse<ApiLessonXTeacherResponseModel> result = await this.Client.LessonXTeacherCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.LessonXTeacherDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>94a05458f5c53e6d36c7b84f425c6cbd</Hash>
</Codenesium>*/