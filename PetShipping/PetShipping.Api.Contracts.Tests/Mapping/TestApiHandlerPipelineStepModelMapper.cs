using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "HandlerPipelineStep")]
        [Trait("Area", "ApiModel")]
        public class TestApiHandlerPipelineStepModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiHandlerPipelineStepModelMapper();
                        var model = new ApiHandlerPipelineStepRequestModel();
                        model.SetProperties(1, 1);
                        ApiHandlerPipelineStepResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.HandlerId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiHandlerPipelineStepModelMapper();
                        var model = new ApiHandlerPipelineStepResponseModel();
                        model.SetProperties(1, 1, 1);
                        ApiHandlerPipelineStepRequestModel response = mapper.MapResponseToRequest(model);

                        response.HandlerId.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>6c424310ee651f2d60fb64950595fc72</Hash>
</Codenesium>*/