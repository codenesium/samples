using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TeacherXTeacherSkill")]
        [Trait("Area", "ApiModel")]
        public class TestApiTeacherXTeacherSkillModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTeacherXTeacherSkillModelMapper();
                        var model = new ApiTeacherXTeacherSkillRequestModel();
                        model.SetProperties(1, 1);
                        ApiTeacherXTeacherSkillResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTeacherXTeacherSkillModelMapper();
                        var model = new ApiTeacherXTeacherSkillResponseModel();
                        model.SetProperties(1, 1, 1);
                        ApiTeacherXTeacherSkillRequestModel response = mapper.MapResponseToRequest(model);

                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiTeacherXTeacherSkillModelMapper();
                        var model = new ApiTeacherXTeacherSkillRequestModel();
                        model.SetProperties(1, 1);

                        JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiTeacherXTeacherSkillRequestModel();
                        patch.ApplyTo(response);

                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>9b4199ef347e0e9e5bf7a6ffdb0eaeb5</Hash>
</Codenesium>*/