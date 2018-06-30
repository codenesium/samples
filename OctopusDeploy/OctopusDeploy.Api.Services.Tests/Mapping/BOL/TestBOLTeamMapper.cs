using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Team")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLTeamMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLTeamMapper();
                        ApiTeamRequestModel model = new ApiTeamRequestModel();
                        model.SetProperties("A", "A", "A", "A", "A", "A", "A", "A");
                        BOTeam response = mapper.MapModelToBO("A", model);

                        response.EnvironmentIds.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.MemberUserIds.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectGroupIds.Should().Be("A");
                        response.ProjectIds.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLTeamMapper();
                        BOTeam bo = new BOTeam();
                        bo.SetProperties("A", "A", "A", "A", "A", "A", "A", "A", "A");
                        ApiTeamResponseModel response = mapper.MapBOToModel(bo);

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
                public void MapBOToModelList()
                {
                        var mapper = new BOLTeamMapper();
                        BOTeam bo = new BOTeam();
                        bo.SetProperties("A", "A", "A", "A", "A", "A", "A", "A", "A");
                        List<ApiTeamResponseModel> response = mapper.MapBOToModel(new List<BOTeam>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>303e5347730406232171231dc42ae57e</Hash>
</Codenesium>*/