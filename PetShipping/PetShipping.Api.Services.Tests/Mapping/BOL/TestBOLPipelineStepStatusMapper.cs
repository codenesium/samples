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
        [Trait("Table", "PipelineStepStatus")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPipelineStepStatusActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPipelineStepStatusMapper();

                        ApiPipelineStepStatusRequestModel model = new ApiPipelineStepStatusRequestModel();

                        model.SetProperties("A");
                        BOPipelineStepStatus response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPipelineStepStatusMapper();

                        BOPipelineStepStatus bo = new BOPipelineStepStatus();

                        bo.SetProperties(1, "A");
                        ApiPipelineStepStatusResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPipelineStepStatusMapper();

                        BOPipelineStepStatus bo = new BOPipelineStepStatus();

                        bo.SetProperties(1, "A");
                        List<ApiPipelineStepStatusResponseModel> response = mapper.MapBOToModel(new List<BOPipelineStepStatus>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>89f3f8f86a6647bd0a65799bd8ae9b27</Hash>
</Codenesium>*/