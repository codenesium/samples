using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "MachineRefTeam")]
        [Trait("Area", "DALMapper")]
        public class TestDALMachineRefTeamMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALMachineRefTeamMapper();
                        var bo = new BOMachineRefTeam();
                        bo.SetProperties(1, 1, 1);

                        MachineRefTeam response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.MachineId.Should().Be(1);
                        response.TeamId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALMachineRefTeamMapper();
                        MachineRefTeam entity = new MachineRefTeam();
                        entity.SetProperties(1, 1, 1);

                        BOMachineRefTeam response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.MachineId.Should().Be(1);
                        response.TeamId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALMachineRefTeamMapper();
                        MachineRefTeam entity = new MachineRefTeam();
                        entity.SetProperties(1, 1, 1);

                        List<BOMachineRefTeam> response = mapper.MapEFToBO(new List<MachineRefTeam>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>353260c598652f249d4d08286b2b3705</Hash>
</Codenesium>*/