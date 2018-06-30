using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "HandlerPipelineStep")]
        [Trait("Area", "DALMapper")]
        public class TestDALHandlerPipelineStepMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALHandlerPipelineStepMapper();
                        var bo = new BOHandlerPipelineStep();
                        bo.SetProperties(1, 1, 1);

                        HandlerPipelineStep response = mapper.MapBOToEF(bo);

                        response.HandlerId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALHandlerPipelineStepMapper();
                        HandlerPipelineStep entity = new HandlerPipelineStep();
                        entity.SetProperties(1, 1, 1);

                        BOHandlerPipelineStep response = mapper.MapEFToBO(entity);

                        response.HandlerId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALHandlerPipelineStepMapper();
                        HandlerPipelineStep entity = new HandlerPipelineStep();
                        entity.SetProperties(1, 1, 1);

                        List<BOHandlerPipelineStep> response = mapper.MapEFToBO(new List<HandlerPipelineStep>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>4e66b72be5835e055dea15a650d6204a</Hash>
</Codenesium>*/