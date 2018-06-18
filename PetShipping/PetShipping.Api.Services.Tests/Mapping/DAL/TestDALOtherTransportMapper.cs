using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "OtherTransport")]
        [Trait("Area", "DALMapper")]
        public class TestDALOtherTransportActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALOtherTransportMapper();

                        var bo = new BOOtherTransport();

                        bo.SetProperties(1, 1, 1);

                        OtherTransport response = mapper.MapBOToEF(bo);

                        response.HandlerId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALOtherTransportMapper();

                        OtherTransport entity = new OtherTransport();

                        entity.SetProperties(1, 1, 1);

                        BOOtherTransport  response = mapper.MapEFToBO(entity);

                        response.HandlerId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.PipelineStepId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALOtherTransportMapper();

                        OtherTransport entity = new OtherTransport();

                        entity.SetProperties(1, 1, 1);

                        List<BOOtherTransport> response = mapper.MapEFToBO(new List<OtherTransport>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>54f06c66507a59d2e4fdbe97914564cd</Hash>
</Codenesium>*/