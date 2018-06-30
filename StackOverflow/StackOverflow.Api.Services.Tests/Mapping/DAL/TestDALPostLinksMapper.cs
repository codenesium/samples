using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PostLinks")]
        [Trait("Area", "DALMapper")]
        public class TestDALPostLinksMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPostLinksMapper();
                        var bo = new BOPostLinks();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);

                        PostLinks response = mapper.MapBOToEF(bo);

                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.LinkTypeId.Should().Be(1);
                        response.PostId.Should().Be(1);
                        response.RelatedPostId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPostLinksMapper();
                        PostLinks entity = new PostLinks();
                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);

                        BOPostLinks response = mapper.MapEFToBO(entity);

                        response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.LinkTypeId.Should().Be(1);
                        response.PostId.Should().Be(1);
                        response.RelatedPostId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPostLinksMapper();
                        PostLinks entity = new PostLinks();
                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);

                        List<BOPostLinks> response = mapper.MapEFToBO(new List<PostLinks>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>f08a710e9adabb370eb1e3911ade1703</Hash>
</Codenesium>*/