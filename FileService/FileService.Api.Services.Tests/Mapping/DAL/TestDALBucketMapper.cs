using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Bucket")]
        [Trait("Area", "DALMapper")]
        public class TestDALBucketMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALBucketMapper();
                        var bo = new BOBucket();
                        bo.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");

                        Bucket response = mapper.MapBOToEF(bo);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALBucketMapper();
                        Bucket entity = new Bucket();
                        entity.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A");

                        BOBucket response = mapper.MapEFToBO(entity);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALBucketMapper();
                        Bucket entity = new Bucket();
                        entity.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A");

                        List<BOBucket> response = mapper.MapEFToBO(new List<Bucket>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>3aa0363f4f69faecca6ec6c239a97926</Hash>
</Codenesium>*/