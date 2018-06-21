using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LessonXStudent")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLLessonXStudentMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLLessonXStudentMapper();
                        ApiLessonXStudentRequestModel model = new ApiLessonXStudentRequestModel();
                        model.SetProperties(1, 1);
                        BOLessonXStudent response = mapper.MapModelToBO(1, model);

                        response.LessonId.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLLessonXStudentMapper();
                        BOLessonXStudent bo = new BOLessonXStudent();
                        bo.SetProperties(1, 1, 1);
                        ApiLessonXStudentResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.LessonId.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLLessonXStudentMapper();
                        BOLessonXStudent bo = new BOLessonXStudent();
                        bo.SetProperties(1, 1, 1);
                        List<ApiLessonXStudentResponseModel> response = mapper.MapBOToModel(new List<BOLessonXStudent>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>e6d7e197a78e8081053317e1cdc5d73a</Hash>
</Codenesium>*/