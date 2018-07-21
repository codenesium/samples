using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ChainStatus")]
        [Trait("Area", "ApiModel")]
        public class TestApiChainStatusModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiChainStatusModelMapper();
                        var model = new ApiChainStatusRequestModel();
                        model.SetProperties("A");
                        ApiChainStatusResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiChainStatusModelMapper();
                        var model = new ApiChainStatusResponseModel();
                        model.SetProperties(1, "A");
                        ApiChainStatusRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiChainStatusModelMapper();
                        var model = new ApiChainStatusRequestModel();
                        model.SetProperties("A");

                        JsonPatchDocument<ApiChainStatusRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiChainStatusRequestModel();
                        patch.ApplyTo(response);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>166789b6dcaba4fda0f0594acca23300</Hash>
</Codenesium>*/