using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Space")]
        [Trait("Area", "DALMapper")]
        public class TestDALSpaceActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSpaceMapper();

                        var bo = new BOSpace();

                        bo.SetProperties(1, "A", "A", 1);

                        Space response = mapper.MapBOToEF(bo);

                        response.Description.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSpaceMapper();

                        Space entity = new Space();

                        entity.SetProperties("A", 1, "A", 1);

                        BOSpace  response = mapper.MapEFToBO(entity);

                        response.Description.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSpaceMapper();

                        Space entity = new Space();

                        entity.SetProperties("A", 1, "A", 1);

                        List<BOSpace> response = mapper.MapEFToBO(new List<Space>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>0351e3e73de639d9bc05f48dedd72b84</Hash>
</Codenesium>*/