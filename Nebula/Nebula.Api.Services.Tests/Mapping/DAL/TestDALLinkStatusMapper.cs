using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LinkStatus")]
        [Trait("Area", "DALMapper")]
        public class TestDALLinkStatusMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALLinkStatusMapper();
                        var bo = new BOLinkStatus();
                        bo.SetProperties(1, "A");

                        LinkStatus response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALLinkStatusMapper();
                        LinkStatus entity = new LinkStatus();
                        entity.SetProperties(1, "A");

                        BOLinkStatus response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALLinkStatusMapper();
                        LinkStatus entity = new LinkStatus();
                        entity.SetProperties(1, "A");

                        List<BOLinkStatus> response = mapper.MapEFToBO(new List<LinkStatus>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>333b03f61cacbd6b17a6e6164e6d65c6</Hash>
</Codenesium>*/