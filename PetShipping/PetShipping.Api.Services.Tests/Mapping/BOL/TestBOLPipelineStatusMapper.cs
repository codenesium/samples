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
        [Trait("Table", "PipelineStatus")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPipelineStatusMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPipelineStatusMapper();
                        ApiPipelineStatusRequestModel model = new ApiPipelineStatusRequestModel();
                        model.SetProperties("A");
                        BOPipelineStatus response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPipelineStatusMapper();
                        BOPipelineStatus bo = new BOPipelineStatus();
                        bo.SetProperties(1, "A");
                        ApiPipelineStatusResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPipelineStatusMapper();
                        BOPipelineStatus bo = new BOPipelineStatus();
                        bo.SetProperties(1, "A");
                        List<ApiPipelineStatusResponseModel> response = mapper.MapBOToModel(new List<BOPipelineStatus>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>dc0b27bd1b71eecdd9b22263f912805f</Hash>
</Codenesium>*/