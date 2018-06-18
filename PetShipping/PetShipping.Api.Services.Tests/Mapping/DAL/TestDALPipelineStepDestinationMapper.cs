using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStepDestination")]
        [Trait("Area", "DALMapper")]
        public class TestDALPipelineStepDestinationActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPipelineStepDestinationMapper();

                        var bo = new BOPipelineStepDestination();

                        bo.SetProperties(1, 1, 1);

                        PipelineStepDestination response = mapper.MapBOToEF(bo);

                        response.DestinationId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPipelineStepDestinationMapper();

                        PipelineStepDestination entity = new PipelineStepDestination();

                        entity.SetProperties(1, 1, 1);

                        BOPipelineStepDestination  response = mapper.MapEFToBO(entity);

                        response.DestinationId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPipelineStepDestinationMapper();

                        PipelineStepDestination entity = new PipelineStepDestination();

                        entity.SetProperties(1, 1, 1);

                        List<BOPipelineStepDestination> response = mapper.MapEFToBO(new List<PipelineStepDestination>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>3a9e7179f3138ea1a22125d4c9a6520e</Hash>
</Codenesium>*/