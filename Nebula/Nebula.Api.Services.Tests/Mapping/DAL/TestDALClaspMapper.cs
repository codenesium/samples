using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Clasp")]
        [Trait("Area", "DALMapper")]
        public class TestDALClaspActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALClaspMapper();

                        var bo = new BOClasp();

                        bo.SetProperties(1, 1, 1);

                        Clasp response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.NextChainId.Should().Be(1);
                        response.PreviousChainId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALClaspMapper();

                        Clasp entity = new Clasp();

                        entity.SetProperties(1, 1, 1);

                        BOClasp  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.NextChainId.Should().Be(1);
                        response.PreviousChainId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALClaspMapper();

                        Clasp entity = new Clasp();

                        entity.SetProperties(1, 1, 1);

                        List<BOClasp> response = mapper.MapEFToBO(new List<Clasp>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>bb9f81eb204c52b3f3335109407fb696</Hash>
</Codenesium>*/