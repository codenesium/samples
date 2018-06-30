using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStep")]
        [Trait("Area", "ApiModel")]
        public class TestApiPipelineStepModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPipelineStepModelMapper();
                        var model = new ApiPipelineStepRequestModel();
                        model.SetProperties("A", 1, 1);
                        ApiPipelineStepResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.PipelineStepStatusId.Should().Be(1);
                        response.ShipperId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPipelineStepModelMapper();
                        var model = new ApiPipelineStepResponseModel();
                        model.SetProperties(1, "A", 1, 1);
                        ApiPipelineStepRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                        response.PipelineStepStatusId.Should().Be(1);
                        response.ShipperId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>5695534c653ea41124456515060dd4a9</Hash>
</Codenesium>*/