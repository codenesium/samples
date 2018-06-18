using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Pipeline")]
        [Trait("Area", "DALMapper")]
        public class TestDALPipelineActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPipelineMapper();

                        var bo = new BOPipeline();

                        bo.SetProperties(1, 1, 1);

                        Pipeline response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.PipelineStatusId.Should().Be(1);
                        response.SaleId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPipelineMapper();

                        Pipeline entity = new Pipeline();

                        entity.SetProperties(1, 1, 1);

                        BOPipeline  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.PipelineStatusId.Should().Be(1);
                        response.SaleId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPipelineMapper();

                        Pipeline entity = new Pipeline();

                        entity.SetProperties(1, 1, 1);

                        List<BOPipeline> response = mapper.MapEFToBO(new List<Pipeline>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>cb1eb98f591b2598ef90a13b43fccc1c</Hash>
</Codenesium>*/