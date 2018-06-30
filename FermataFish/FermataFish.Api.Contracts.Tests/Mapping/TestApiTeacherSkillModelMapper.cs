using FermataFishNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TeacherSkill")]
        [Trait("Area", "ApiModel")]
        public class TestApiTeacherSkillModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTeacherSkillModelMapper();
                        var model = new ApiTeacherSkillRequestModel();
                        model.SetProperties("A", 1);
                        ApiTeacherSkillResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTeacherSkillModelMapper();
                        var model = new ApiTeacherSkillResponseModel();
                        model.SetProperties(1, "A", 1);
                        ApiTeacherSkillRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>538896fdce3a25772141322476f83ab1</Hash>
</Codenesium>*/