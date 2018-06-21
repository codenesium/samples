using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SpaceFeature")]
        [Trait("Area", "DALMapper")]
        public class TestDALSpaceFeatureMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSpaceFeatureMapper();
                        var bo = new BOSpaceFeature();
                        bo.SetProperties(1, "A", 1);

                        SpaceFeature response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSpaceFeatureMapper();
                        SpaceFeature entity = new SpaceFeature();
                        entity.SetProperties(1, "A", 1);

                        BOSpaceFeature response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSpaceFeatureMapper();
                        SpaceFeature entity = new SpaceFeature();
                        entity.SetProperties(1, "A", 1);

                        List<BOSpaceFeature> response = mapper.MapEFToBO(new List<SpaceFeature>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>09e919e0a320b1a004ec8ce9460df881</Hash>
</Codenesium>*/