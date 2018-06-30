using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStepStatus")]
        [Trait("Area", "ApiModel")]
        public class TestApiPipelineStepStatusModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPipelineStepStatusModelMapper();
                        var model = new ApiPipelineStepStatusRequestModel();
                        model.SetProperties("A");
                        ApiPipelineStepStatusResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPipelineStepStatusModelMapper();
                        var model = new ApiPipelineStepStatusResponseModel();
                        model.SetProperties(1, "A");
                        ApiPipelineStepStatusRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>2d60a1754bce46821f440a2b44282287</Hash>
</Codenesium>*/