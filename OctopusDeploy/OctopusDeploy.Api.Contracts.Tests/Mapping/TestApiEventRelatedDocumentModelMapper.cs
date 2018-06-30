using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "EventRelatedDocument")]
        [Trait("Area", "ApiModel")]
        public class TestApiEventRelatedDocumentModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiEventRelatedDocumentModelMapper();
                        var model = new ApiEventRelatedDocumentRequestModel();
                        model.SetProperties("A", "A");
                        ApiEventRelatedDocumentResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.EventId.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.RelatedDocumentId.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiEventRelatedDocumentModelMapper();
                        var model = new ApiEventRelatedDocumentResponseModel();
                        model.SetProperties(1, "A", "A");
                        ApiEventRelatedDocumentRequestModel response = mapper.MapResponseToRequest(model);

                        response.EventId.Should().Be("A");
                        response.RelatedDocumentId.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>a5ba5a07b0ba12f0e0a2ab33c44fa395</Hash>
</Codenesium>*/