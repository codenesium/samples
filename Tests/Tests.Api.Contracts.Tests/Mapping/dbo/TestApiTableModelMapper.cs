using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Table")]
        [Trait("Area", "ApiModel")]
        public class TestApiTableModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTableModelMapper();
                        var model = new ApiTableRequestModel();
                        model.SetProperties("A");
                        ApiTableResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTableModelMapper();
                        var model = new ApiTableResponseModel();
                        model.SetProperties(1, "A");
                        ApiTableRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiTableModelMapper();
                        var model = new ApiTableRequestModel();
                        model.SetProperties("A");

                        JsonPatchDocument<ApiTableRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiTableRequestModel();
                        patch.ApplyTo(response);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>f78e48fd7c62a38fd8252004c914a745</Hash>
</Codenesium>*/