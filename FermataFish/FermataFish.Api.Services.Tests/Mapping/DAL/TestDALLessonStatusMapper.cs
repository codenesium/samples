using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LessonStatus")]
        [Trait("Area", "DALMapper")]
        public class TestDALLessonStatusMapper
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

                        BOLessonStatus response = mapper.MapEFToBO(entity);

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
    <Hash>4a034ac2ad0c0a9fdcc3205776f82102</Hash>
</Codenesium>*/