using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LinkTypes")]
        [Trait("Area", "ApiModel")]
        public class TestApiLinkTypesModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiLinkTypesModelMapper();
                        var model = new ApiLinkTypesRequestModel();
                        model.SetProperties("A");
                        ApiLinkTypesResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiLinkTypesModelMapper();
                        var model = new ApiLinkTypesResponseModel();
                        model.SetProperties(1, "A");
                        ApiLinkTypesRequestModel response = mapper.MapResponseToRequest(model);

                        response.Type.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiLinkTypesModelMapper();
                        var model = new ApiLinkTypesRequestModel();
                        model.SetProperties("A");

                        JsonPatchDocument<ApiLinkTypesRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiLinkTypesRequestModel();
                        patch.ApplyTo(response);

                        response.Type.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>23a9e667bea2c763e70b43976fae878f</Hash>
</Codenesium>*/