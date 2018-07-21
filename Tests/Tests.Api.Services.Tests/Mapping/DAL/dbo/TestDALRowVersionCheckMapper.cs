using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "RowVersionCheck")]
        [Trait("Area", "DALMapper")]
        public class TestDALRowVersionCheckMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALRowVersionCheckMapper();
                        var bo = new BORowVersionCheck();
                        bo.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        RowVersionCheck response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALRowVersionCheckMapper();
                        RowVersionCheck entity = new RowVersionCheck();
                        entity.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        BORowVersionCheck response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.RowVersion.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALRowVersionCheckMapper();
                        RowVersionCheck entity = new RowVersionCheck();
                        entity.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        List<BORowVersionCheck> response = mapper.MapEFToBO(new List<RowVersionCheck>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>e45d4e37d4f612da29ae652843406d49</Hash>
</Codenesium>*/