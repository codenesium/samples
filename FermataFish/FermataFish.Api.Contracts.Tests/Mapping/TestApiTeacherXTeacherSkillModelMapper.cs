using FermataFishNS.Api.Contracts;
using FluentAssertions;
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
        }
}

/*<Codenesium>
    <Hash>eb8ea92876258d355cb131830e6b7f7e</Hash>
</Codenesium>*/