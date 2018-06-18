using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStatus")]
        [Trait("Area", "DALMapper")]
        public class TestDALPipelineStatusActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPipelineStatusMapper();

                        var bo = new BOPipelineStatus();

                        bo.SetProperties(1, "A");

                        PipelineStatus response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPipelineStatusMapper();

                        PipelineStatus entity = new PipelineStatus();

                        entity.SetProperties(1, "A");

                        BOPipelineStatus  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPipelineStatusMapper();

                        PipelineStatus entity = new PipelineStatus();

                        entity.SetProperties(1, "A");

                        List<BOPipelineStatus> response = mapper.MapEFToBO(new List<PipelineStatus>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>12c143c9506ed6abd7034aa4c9934d47</Hash>
</Codenesium>*/