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
        [Trait("Table", "Lesson")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLLessonActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLLessonMapper();

                        ApiLessonRequestModel model = new ApiLessonRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A");
                        BOLesson response = mapper.MapModelToBO(1, model);

                        response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BillAmount.Should().Be(1);
                        response.LessonStatusId.Should().Be(1);
                        response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.StudentNotes.Should().Be("A");
                        response.StudioId.Should().Be(1);
                        response.TeacherNotes.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLLessonMapper();

                        BOLesson bo = new BOLesson();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A");
                        ApiLessonResponseModel response = mapper.MapBOToModel(bo);

                        response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BillAmount.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.LessonStatusId.Should().Be(1);
                        response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.StudentNotes.Should().Be("A");
                        response.StudioId.Should().Be(1);
                        response.TeacherNotes.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLLessonMapper();

                        BOLesson bo = new BOLesson();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A");
                        List<ApiLessonResponseModel> response = mapper.MapBOToModel(new List<BOLesson>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1c6a2899d99355f0dbb9a82d187bad49</Hash>
</Codenesium>*/