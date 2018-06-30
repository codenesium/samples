using FermataFishNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LessonXStudent")]
        [Trait("Area", "ApiModel")]
        public class TestApiLessonXStudentModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiLessonXStudentModelMapper();
                        var model = new ApiLessonXStudentRequestModel();
                        model.SetProperties(1, 1);
                        ApiLessonXStudentResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.LessonId.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiLessonXStudentModelMapper();
                        var model = new ApiLessonXStudentResponseModel();
                        model.SetProperties(1, 1, 1);
                        ApiLessonXStudentRequestModel response = mapper.MapResponseToRequest(model);

                        response.LessonId.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>bcf35ac0ff91b9d005f74a937b0f8611</Hash>
</Codenesium>*/