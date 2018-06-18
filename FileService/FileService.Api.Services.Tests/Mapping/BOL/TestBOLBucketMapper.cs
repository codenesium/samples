using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;

namespace FileServiceNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Bucket")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLBucketActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLBucketMapper();

                        ApiBucketRequestModel model = new ApiBucketRequestModel();

                        model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
                        BOBucket response = mapper.MapModelToBO(1, model);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLBucketMapper();

                        BOBucket bo = new BOBucket();

                        bo.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
                        ApiBucketResponseModel response = mapper.MapBOToModel(bo);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLBucketMapper();

                        BOBucket bo = new BOBucket();

                        bo.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
                        List<ApiBucketResponseModel> response = mapper.MapBOToModel(new List<BOBucket>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>f26e0caf25e33ba7867faf0ca081346f</Hash>
</Codenesium>*/