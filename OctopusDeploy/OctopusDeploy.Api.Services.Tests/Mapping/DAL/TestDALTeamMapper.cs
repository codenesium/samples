using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
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

                        bo.SetProperties("A", "A", "A", "A", "A", "A", "A", "A", "A");

                        Team response = mapper.MapBOToEF(bo);

                        response.EnvironmentIds.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.MemberUserIds.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupIds.Should().Be("A");
                        response.ProjectIds.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALTeamMapper();

                        Team entity = new Team();

                        entity.SetProperties("A", "A", "A", "A", "A", "A", "A", "A", "A");

                        BOTeam  response = mapper.MapEFToBO(entity);

                        response.EnvironmentIds.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.MemberUserIds.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupIds.Should().Be("A");
                        response.ProjectIds.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALTeamMapper();

                        Team entity = new Team();

                        entity.SetProperties("A", "A", "A", "A", "A", "A", "A", "A", "A");

                        List<BOTeam> response = mapper.MapEFToBO(new List<Team>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>e6ccc9300131ec4c0bf7718e4fe7b8fd</Hash>
</Codenesium>*/