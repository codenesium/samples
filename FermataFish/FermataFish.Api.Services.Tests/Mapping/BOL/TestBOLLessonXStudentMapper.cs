using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LessonXStudent")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLLessonXStudentActionMapper
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
    <Hash>3dfa510d25307d913eefa15cb490d30c</Hash>
</Codenesium>*/