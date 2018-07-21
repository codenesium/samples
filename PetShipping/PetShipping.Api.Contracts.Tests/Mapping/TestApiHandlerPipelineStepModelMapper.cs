using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiHandlerPipelineStepModelMapper();
                        var model = new ApiHandlerPipelineStepRequestModel();
                        model.SetProperties(1, 1);

                        JsonPatchDocument<ApiHandlerPipelineStepRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiHandlerPipelineStepRequestModel();
                        patch.ApplyTo(response);

                        response.HandlerId.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>62442392992a92a030378f230ac0927e</Hash>
</Codenesium>*/