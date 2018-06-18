using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ChainStatus")]
        [Trait("Area", "DALMapper")]
        public class TestDALChainStatusActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALChainStatusMapper();

                        var bo = new BOChainStatus();

                        bo.SetProperties(1, "A");

                        ChainStatus response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALChainStatusMapper();

                        ChainStatus entity = new ChainStatus();

                        entity.SetProperties(1, "A");

                        BOChainStatus  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALChainStatusMapper();

                        ChainStatus entity = new ChainStatus();

                        entity.SetProperties(1, "A");

                        List<BOChainStatus> response = mapper.MapEFToBO(new List<ChainStatus>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>747c9eff300e7264af7cffe86a7b0610</Hash>
</Codenesium>*/