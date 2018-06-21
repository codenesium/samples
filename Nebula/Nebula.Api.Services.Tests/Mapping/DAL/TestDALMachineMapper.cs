using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Machine")]
        [Trait("Area", "DALMapper")]
        public class TestDALMachineMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALMachineMapper();
                        var bo = new BOMachine();
                        bo.SetProperties(1, "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");

                        Machine response = mapper.MapBOToEF(bo);

                        response.Description.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.JwtKey.Should().Be("A");
                        response.LastIpAddress.Should().Be("A");
                        response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALMachineMapper();
                        Machine entity = new Machine();
                        entity.SetProperties("A", 1, "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");

                        BOMachine response = mapper.MapEFToBO(entity);

                        response.Description.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.JwtKey.Should().Be("A");
                        response.LastIpAddress.Should().Be("A");
                        response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALMachineMapper();
                        Machine entity = new Machine();
                        entity.SetProperties("A", 1, "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");

                        List<BOMachine> response = mapper.MapEFToBO(new List<Machine>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>60fcaaa61362ab2272974226a486331e</Hash>
</Codenesium>*/