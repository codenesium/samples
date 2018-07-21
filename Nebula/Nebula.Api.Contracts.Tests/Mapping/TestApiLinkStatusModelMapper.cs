using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LinkStatus")]
        [Trait("Area", "ApiModel")]
        public class TestApiLinkStatusModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiLinkStatusModelMapper();
                        var model = new ApiLinkStatusRequestModel();
                        model.SetProperties("A");
                        ApiLinkStatusResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiLinkStatusModelMapper();
                        var model = new ApiLinkStatusResponseModel();
                        model.SetProperties(1, "A");
                        ApiLinkStatusRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiLinkStatusModelMapper();
                        var model = new ApiLinkStatusRequestModel();
                        model.SetProperties("A");

                        JsonPatchDocument<ApiLinkStatusRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiLinkStatusRequestModel();
                        patch.ApplyTo(response);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>79cc5d2edbaca9e5273ec64294fc1f22</Hash>
</Codenesium>*/