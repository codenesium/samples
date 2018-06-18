using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Team")]
        [Trait("Area", "DALMapper")]
        public class TestDALTeamActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALTeamMapper();

                        var bo = new BOTeam();

                        bo.SetProperties(1, "A", 1);

                        Team response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.OrganizationId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALTeamMapper();

                        Team entity = new Team();

                        entity.SetProperties(1, "A", 1);

                        BOTeam  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.OrganizationId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALTeamMapper();

                        Team entity = new Team();

                        entity.SetProperties(1, "A", 1);

                        List<BOTeam> response = mapper.MapEFToBO(new List<Team>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>24ca22bdca05a639687d91fbeee7cae7</Hash>
</Codenesium>*/