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
        [Trait("Table", "PipelineStatus")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPipelineStatusActionMapper
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
    <Hash>17e4b703cd4b182224e69283c3adfb5d</Hash>
</Codenesium>*/