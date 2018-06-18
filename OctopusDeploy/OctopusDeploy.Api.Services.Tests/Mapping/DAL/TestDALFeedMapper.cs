using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Feed")]
        [Trait("Area", "DALMapper")]
        public class TestDALFeedActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALFeedMapper();

                        var bo = new BOFeed();

                        bo.SetProperties("A", "A", "A", "A", "A");

                        Feed response = mapper.MapBOToEF(bo);

                        response.FeedType.Should().Be("A");
                        response.FeedUri.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALFeedMapper();

                        Feed entity = new Feed();

                        entity.SetProperties("A", "A", "A", "A", "A");

                        BOFeed  response = mapper.MapEFToBO(entity);

                        response.FeedType.Should().Be("A");
                        response.FeedUri.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALFeedMapper();

                        Feed entity = new Feed();

                        entity.SetProperties("A", "A", "A", "A", "A");

                        List<BOFeed> response = mapper.MapEFToBO(new List<Feed>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>e9c62bc2ea66f616ebf0889773fc3ac0</Hash>
</Codenesium>*/