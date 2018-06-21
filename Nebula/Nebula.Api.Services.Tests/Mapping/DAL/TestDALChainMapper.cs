using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Chain")]
        [Trait("Area", "DALMapper")]
        public class TestDALChainMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALChainMapper();
                        var bo = new BOChain();
                        bo.SetProperties(1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);

                        Chain response = mapper.MapBOToEF(bo);

                        response.ChainStatusId.Should().Be(1);
                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.TeamId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALChainMapper();
                        Chain entity = new Chain();
                        entity.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1);

                        BOChain response = mapper.MapEFToBO(entity);

                        response.ChainStatusId.Should().Be(1);
                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.TeamId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALChainMapper();
                        Chain entity = new Chain();
                        entity.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1);

                        List<BOChain> response = mapper.MapEFToBO(new List<Chain>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>ae4fdfd6e42c324dc8e7f3269964e2e4</Hash>
</Codenesium>*/