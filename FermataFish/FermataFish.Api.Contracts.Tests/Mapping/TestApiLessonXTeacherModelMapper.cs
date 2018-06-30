using FermataFishNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LessonXTeacher")]
        [Trait("Area", "ApiModel")]
        public class TestApiLessonXTeacherModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiLessonXTeacherModelMapper();
                        var model = new ApiLessonXTeacherRequestModel();
                        model.SetProperties(1, 1);
                        ApiLessonXTeacherResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.LessonId.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiLessonXTeacherModelMapper();
                        var model = new ApiLessonXTeacherResponseModel();
                        model.SetProperties(1, 1, 1);
                        ApiLessonXTeacherRequestModel response = mapper.MapResponseToRequest(model);

                        response.LessonId.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>89c8dd8e69c15ff0f723f61252e2e59e</Hash>
</Codenesium>*/