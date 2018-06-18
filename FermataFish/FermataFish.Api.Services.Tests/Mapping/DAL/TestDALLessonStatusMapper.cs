using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LessonStatus")]
        [Trait("Area", "DALMapper")]
        public class TestDALLessonStatusActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALLessonStatusMapper();

                        var bo = new BOLessonStatus();

                        bo.SetProperties(1, "A", 1);

                        LessonStatus response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALLessonStatusMapper();

                        LessonStatus entity = new LessonStatus();

                        entity.SetProperties(1, "A", 1);

                        BOLessonStatus  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALLessonStatusMapper();

                        LessonStatus entity = new LessonStatus();

                        entity.SetProperties(1, "A", 1);

                        List<BOLessonStatus> response = mapper.MapEFToBO(new List<LessonStatus>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>8daf2db46cc5ca3e161c6f18b529b592</Hash>
</Codenesium>*/