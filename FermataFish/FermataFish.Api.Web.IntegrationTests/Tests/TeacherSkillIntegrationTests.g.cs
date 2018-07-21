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
        [Trait("Table", "TeacherSkill")]
        [Trait("Area", "Integration")]
        public class TeacherSkillIntegrationTests : IClassFixture<TestWebApplicationFactory>
        {
                public TeacherSkillIntegrationTests(TestWebApplicationFactory fixture)
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

                        ApiTeacherSkillModelMapper mapper = new ApiTeacherSkillModelMapper();

                        UpdateResponse<ApiTeacherSkillResponseModel> updateResponse = await this.Client.TeacherSkillUpdateAsync(model.Id, mapper.MapResponseToRequest(model));

                        updateResponse.Record.Should().NotBeNull();
                        updateResponse.Success.Should().BeTrue();

                        await this.Cleanup();
                }

                [Fact]
                public async void TestDelete()
                {
                        var model = await this.CreateRecord();

                        await this.Client.TeacherSkillDeleteAsync(model.Id);

                        await this.Cleanup();
                }

                [Fact]
                public async void TestGet()
                {
                        ApiTeacherSkillResponseModel response = await this.Client.TeacherSkillGetAsync(1);

                        response.Should().NotBeNull();
                }

                [Fact]
                public async void TestAll()
                {
                        List<ApiTeacherSkillResponseModel> response = await this.Client.TeacherSkillAllAsync();

                        response.Count.Should().BeGreaterThan(0);
                }

                private async Task<ApiTeacherSkillResponseModel> CreateRecord()
                {
                        var model = new ApiTeacherSkillRequestModel();
                        model.SetProperties("B", 1);
                        CreateResponse<ApiTeacherSkillResponseModel> result = await this.Client.TeacherSkillCreateAsync(model);

                        result.Success.Should().BeTrue();
                        return result.Record;
                }

                private async Task Cleanup()
                {
                        await this.Client.TeacherSkillDeleteAsync(2);
                }
        }
}

/*<Codenesium>
    <Hash>071b5fb762fda21d66dbde924dd2ae48</Hash>
</Codenesium>*/