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
        [Trait("Table", "LessonXTeacher")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLLessonXTeacherActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLLessonXTeacherMapper();

                        ApiLessonXTeacherRequestModel model = new ApiLessonXTeacherRequestModel();

                        model.SetProperties(1, 1);
                        BOLessonXTeacher response = mapper.MapModelToBO(1, model);

                        response.LessonId.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLLessonXTeacherMapper();

                        BOLessonXTeacher bo = new BOLessonXTeacher();

                        bo.SetProperties(1, 1, 1);
                        ApiLessonXTeacherResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.LessonId.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLLessonXTeacherMapper();

                        BOLessonXTeacher bo = new BOLessonXTeacher();

                        bo.SetProperties(1, 1, 1);
                        List<ApiLessonXTeacherResponseModel> response = mapper.MapBOToModel(new List<BOLessonXTeacher>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>9be57b708f538bcd1653492c921598b2</Hash>
</Codenesium>*/