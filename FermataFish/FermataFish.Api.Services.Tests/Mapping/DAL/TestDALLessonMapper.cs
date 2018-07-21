using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Lesson")]
        [Trait("Area", "DALMapper")]
        public class TestDALLessonMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALLessonMapper();
                        var bo = new BOLesson();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A");

                        Lesson response = mapper.MapBOToEF(bo);

                        response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BillAmount.Should().Be(1m);
                        response.Id.Should().Be(1);
                        response.LessonStatusId.Should().Be(1);
                        response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.StudentNotes.Should().Be("A");
                        response.StudioId.Should().Be(1);
                        response.TeacherNotes.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALLessonMapper();
                        Lesson entity = new Lesson();
                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A");

                        BOLesson response = mapper.MapEFToBO(entity);

                        response.ActualEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ActualStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.BillAmount.Should().Be(1m);
                        response.Id.Should().Be(1);
                        response.LessonStatusId.Should().Be(1);
                        response.ScheduledEndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ScheduledStartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.StudentNotes.Should().Be("A");
                        response.StudioId.Should().Be(1);
                        response.TeacherNotes.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALLessonMapper();
                        Lesson entity = new Lesson();
                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A");

                        List<BOLesson> response = mapper.MapEFToBO(new List<Lesson>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>923dd6d62a5d147275bfc3270f060d0f</Hash>
</Codenesium>*/