using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SpaceXSpaceFeature")]
        [Trait("Area", "DALMapper")]
        public class TestDALSpaceXSpaceFeatureActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSpaceXSpaceFeatureMapper();

                        var bo = new BOSpaceXSpaceFeature();

                        bo.SetProperties(1, 1, 1);

                        SpaceXSpaceFeature response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.SpaceFeatureId.Should().Be(1);
                        response.SpaceId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSpaceXSpaceFeatureMapper();

                        SpaceXSpaceFeature entity = new SpaceXSpaceFeature();

                        entity.SetProperties(1, 1, 1);

                        BOSpaceXSpaceFeature  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.SpaceFeatureId.Should().Be(1);
                        response.SpaceId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSpaceXSpaceFeatureMapper();

                        SpaceXSpaceFeature entity = new SpaceXSpaceFeature();

                        entity.SetProperties(1, 1, 1);

                        List<BOSpaceXSpaceFeature> response = mapper.MapEFToBO(new List<SpaceXSpaceFeature>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>89c7d568382a70650032a44d30b2bf26</Hash>
</Codenesium>*/