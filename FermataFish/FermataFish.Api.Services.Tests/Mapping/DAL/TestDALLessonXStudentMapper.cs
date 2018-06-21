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
        [Trait("Area", "DALMapper")]
        public class TestDALLessonXStudentMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALLessonXStudentMapper();
                        var bo = new BOLessonXStudent();
                        bo.SetProperties(1, 1, 1);

                        LessonXStudent response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.LessonId.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALLessonXStudentMapper();
                        LessonXStudent entity = new LessonXStudent();
                        entity.SetProperties(1, 1, 1);

                        BOLessonXStudent response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.LessonId.Should().Be(1);
                        response.StudentId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALLessonXStudentMapper();
                        LessonXStudent entity = new LessonXStudent();
                        entity.SetProperties(1, 1, 1);

                        List<BOLessonXStudent> response = mapper.MapEFToBO(new List<LessonXStudent>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>38e1bba635b4f21fc8702e1af531e6c8</Hash>
</Codenesium>*/