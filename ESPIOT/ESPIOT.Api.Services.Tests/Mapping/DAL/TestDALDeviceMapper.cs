using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;

namespace ESPIOTNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Device")]
        [Trait("Area", "DALMapper")]
        public class TestDALDeviceActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALDeviceMapper();

                        var bo = new BODevice();

                        bo.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        Device response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALDeviceMapper();

                        Device entity = new Device();

                        entity.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        BODevice  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALDeviceMapper();

                        Device entity = new Device();

                        entity.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        List<BODevice> response = mapper.MapEFToBO(new List<Device>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>c36098d8b97b74063248f4f4419a3012</Hash>
</Codenesium>*/