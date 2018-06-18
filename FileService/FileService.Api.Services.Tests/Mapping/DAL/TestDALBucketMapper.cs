using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Bucket")]
        [Trait("Area", "DALMapper")]
        public class TestDALBucketActionMapper
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

                        BOBucket  response = mapper.MapEFToBO(entity);

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
    <Hash>7e0624c22bff796f6d1cb38ab6e5b7d1</Hash>
</Codenesium>*/