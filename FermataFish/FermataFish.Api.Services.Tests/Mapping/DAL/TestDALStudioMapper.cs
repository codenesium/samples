using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Studio")]
        [Trait("Area", "DALMapper")]
        public class TestDALStudioMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALStudioMapper();
                        var bo = new BOStudio();
                        bo.SetProperties(1, "A", "A", "A", "A", 1, "A", "A");

                        Studio response = mapper.MapBOToEF(bo);

                        response.Address1.Should().Be("A");
                        response.Address2.Should().Be("A");
                        response.City.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StateId.Should().Be(1);
                        response.Website.Should().Be("A");
                        response.Zip.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALStudioMapper();
                        Studio entity = new Studio();
                        entity.SetProperties("A", "A", "A", 1, "A", 1, "A", "A");

                        BOStudio response = mapper.MapEFToBO(entity);

                        response.Address1.Should().Be("A");
                        response.Address2.Should().Be("A");
                        response.City.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StateId.Should().Be(1);
                        response.Website.Should().Be("A");
                        response.Zip.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALStudioMapper();
                        Studio entity = new Studio();
                        entity.SetProperties("A", "A", "A", 1, "A", 1, "A", "A");

                        List<BOStudio> response = mapper.MapEFToBO(new List<Studio>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>67a9a3212fef535479146ae8b98b7c37</Hash>
</Codenesium>*/