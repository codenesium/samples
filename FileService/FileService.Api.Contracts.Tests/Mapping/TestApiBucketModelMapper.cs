using FileServiceNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Bucket")]
        [Trait("Area", "ApiModel")]
        public class TestApiBucketModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiBucketModelMapper();
                        var model = new ApiBucketRequestModel();
                        model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
                        ApiBucketResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiBucketModelMapper();
                        var model = new ApiBucketResponseModel();
                        model.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
                        ApiBucketRequestModel response = mapper.MapResponseToRequest(model);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>0b4557cfef00e003062eb906826d09a9</Hash>
</Codenesium>*/