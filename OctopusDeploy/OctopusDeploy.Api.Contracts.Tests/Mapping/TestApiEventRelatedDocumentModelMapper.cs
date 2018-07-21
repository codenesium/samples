using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiEventRelatedDocumentModelMapper();
                        var model = new ApiEventRelatedDocumentRequestModel();
                        model.SetProperties("A", "A");

                        JsonPatchDocument<ApiEventRelatedDocumentRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiEventRelatedDocumentRequestModel();
                        patch.ApplyTo(response);

                        response.EventId.Should().Be("A");
                        response.RelatedDocumentId.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>cfa40c4a90fbae8ccd9e10bba991ef8c</Hash>
</Codenesium>*/