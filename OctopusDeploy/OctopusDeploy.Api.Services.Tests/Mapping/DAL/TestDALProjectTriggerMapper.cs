using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProjectTrigger")]
        [Trait("Area", "DALMapper")]
        public class TestDALProjectTriggerMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALProjectTriggerMapper();
                        var bo = new BOProjectTrigger();
                        bo.SetProperties("A", true, "A", "A", "A", "A");

                        ProjectTrigger response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.TriggerType.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALProjectTriggerMapper();
                        ProjectTrigger entity = new ProjectTrigger();
                        entity.SetProperties("A", true, "A", "A", "A", "A");

                        BOProjectTrigger response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.TriggerType.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALProjectTriggerMapper();
                        ProjectTrigger entity = new ProjectTrigger();
                        entity.SetProperties("A", true, "A", "A", "A", "A");

                        List<BOProjectTrigger> response = mapper.MapEFToBO(new List<ProjectTrigger>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>9d2e7bd97d79208899d9b94e35b1b499</Hash>
</Codenesium>*/