using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "MachineRefTeam")]
        [Trait("Area", "DALMapper")]
        public class TestDALMachineRefTeamActionMapper
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

                        BOMachineRefTeam  response = mapper.MapEFToBO(entity);

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
    <Hash>04729e8db128967c1a3ee9aa4cdb3458</Hash>
</Codenesium>*/