using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStepDestination")]
        [Trait("Area", "ApiModel")]
        public class TestApiPipelineStepDestinationModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPipelineStepDestinationModelMapper();
                        var model = new ApiPipelineStepDestinationRequestModel();
                        model.SetProperties(1, 1);
                        ApiPipelineStepDestinationResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.DestinationId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPipelineStepDestinationModelMapper();
                        var model = new ApiPipelineStepDestinationResponseModel();
                        model.SetProperties(1, 1, 1);
                        ApiPipelineStepDestinationRequestModel response = mapper.MapResponseToRequest(model);

                        response.DestinationId.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>637e48703cc6f9edf80a8b1fb779679e</Hash>
</Codenesium>*/