using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStepStatus")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPipelineStepStatusMapper
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
    <Hash>85348fa34cabe8e2f0d3b1237bafc7e2</Hash>
</Codenesium>*/