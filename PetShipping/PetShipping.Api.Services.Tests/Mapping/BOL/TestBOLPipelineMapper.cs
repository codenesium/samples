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
        [Trait("Table", "Pipeline")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPipelineActionMapper
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
    <Hash>d64e26f141ca9a0f2fe9c61efe6de143</Hash>
</Codenesium>*/