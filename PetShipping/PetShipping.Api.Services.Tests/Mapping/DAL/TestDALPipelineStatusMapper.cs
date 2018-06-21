using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PipelineStatus")]
        [Trait("Area", "DALMapper")]
        public class TestDALPipelineStatusMapper
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

                        BOPipelineStatus response = mapper.MapEFToBO(entity);

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
    <Hash>85c27023208dacc5b3c7b6171270cd81</Hash>
</Codenesium>*/