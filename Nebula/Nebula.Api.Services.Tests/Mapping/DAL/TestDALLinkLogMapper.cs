using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LinkLog")]
        [Trait("Area", "DALMapper")]
        public class TestDALLinkLogActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALLinkLogMapper();

                        var bo = new BOLinkLog();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

                        LinkLog response = mapper.MapBOToEF(bo);

                        response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.LinkId.Should().Be(1);
                        response.Log.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALLinkLogMapper();

                        LinkLog entity = new LinkLog();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

                        BOLinkLog  response = mapper.MapEFToBO(entity);

                        response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.LinkId.Should().Be(1);
                        response.Log.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALLinkLogMapper();

                        LinkLog entity = new LinkLog();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

                        List<BOLinkLog> response = mapper.MapEFToBO(new List<LinkLog>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>71ad019827a815ff1246ebb213cacc74</Hash>
</Codenesium>*/