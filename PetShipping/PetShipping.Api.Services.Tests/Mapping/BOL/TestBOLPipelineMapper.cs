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
        [Trait("Table", "Pipeline")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPipelineMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPipelineMapper();
                        ApiPipelineRequestModel model = new ApiPipelineRequestModel();
                        model.SetProperties(1, 1);
                        BOPipeline response = mapper.MapModelToBO(1, model);

                        response.PipelineStatusId.Should().Be(1);
                        response.SaleId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPipelineMapper();
                        BOPipeline bo = new BOPipeline();
                        bo.SetProperties(1, 1, 1);
                        ApiPipelineResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.PipelineStatusId.Should().Be(1);
                        response.SaleId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPipelineMapper();
                        BOPipeline bo = new BOPipeline();
                        bo.SetProperties(1, 1, 1);
                        List<ApiPipelineResponseModel> response = mapper.MapBOToModel(new List<BOPipeline>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>70dc1472d6f58c5622e603d987e9616b</Hash>
</Codenesium>*/