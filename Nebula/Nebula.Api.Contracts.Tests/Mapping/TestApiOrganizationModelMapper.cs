using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Organization")]
        [Trait("Area", "ApiModel")]
        public class TestApiOrganizationModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiOrganizationModelMapper();
                        var model = new ApiOrganizationRequestModel();
                        model.SetProperties("A");
                        ApiOrganizationResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiOrganizationModelMapper();
                        var model = new ApiOrganizationResponseModel();
                        model.SetProperties(1, "A");
                        ApiOrganizationRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiOrganizationModelMapper();
                        var model = new ApiOrganizationRequestModel();
                        model.SetProperties("A");

                        JsonPatchDocument<ApiOrganizationRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiOrganizationRequestModel();
                        patch.ApplyTo(response);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>41b6e0e2df25acef6af1df2ad0040720</Hash>
</Codenesium>*/