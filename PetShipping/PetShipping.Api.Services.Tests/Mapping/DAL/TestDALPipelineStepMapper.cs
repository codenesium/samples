using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStep")]
        [Trait("Area", "DALMapper")]
        public class TestDALPipelineStepActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPipelineStepMapper();

                        var bo = new BOPipelineStep();

                        bo.SetProperties(1, "A", 1, 1);

                        PipelineStep response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.PipelineStepStatusId.Should().Be(1);
                        response.ShipperId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPipelineStepMapper();

                        PipelineStep entity = new PipelineStep();

                        entity.SetProperties(1, "A", 1, 1);

                        BOPipelineStep  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.PipelineStepStatusId.Should().Be(1);
                        response.ShipperId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPipelineStepMapper();

                        PipelineStep entity = new PipelineStep();

                        entity.SetProperties(1, "A", 1, 1);

                        List<BOPipelineStep> response = mapper.MapEFToBO(new List<PipelineStep>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>fbb4ef74adaefdce0adad5308cbb950f</Hash>
</Codenesium>*/