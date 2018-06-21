using FluentAssertions;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Pen")]
        [Trait("Area", "DALMapper")]
        public class TestDALPenMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPenMapper();
                        var bo = new BOPen();
                        bo.SetProperties(1, "A");

                        Pen response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPenMapper();
                        Pen entity = new Pen();
                        entity.SetProperties(1, "A");

                        BOPen response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPenMapper();
                        Pen entity = new Pen();
                        entity.SetProperties(1, "A");

                        List<BOPen> response = mapper.MapEFToBO(new List<Pen>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>150b522bc63bce183981a1f822cadefc</Hash>
</Codenesium>*/