using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "HandlerPipelineStep")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLHandlerPipelineStepActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLHandlerPipelineStepMapper();

                        ApiHandlerPipelineStepRequestModel model = new ApiHandlerPipelineStepRequestModel();

                        model.SetProperties(1, 1);
                        BOHandlerPipelineStep response = mapper.MapModelToBO(1, model);

                        response.HandlerId.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLHandlerPipelineStepMapper();

                        BOHandlerPipelineStep bo = new BOHandlerPipelineStep();

                        bo.SetProperties(1, 1, 1);
                        ApiHandlerPipelineStepResponseModel response = mapper.MapBOToModel(bo);

                        response.HandlerId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLHandlerPipelineStepMapper();

                        BOHandlerPipelineStep bo = new BOHandlerPipelineStep();

                        bo.SetProperties(1, 1, 1);
                        List<ApiHandlerPipelineStepResponseModel> response = mapper.MapBOToModel(new List<BOHandlerPipelineStep>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>aea533cfb42bef9c5aa429fa52f0c134</Hash>
</Codenesium>*/