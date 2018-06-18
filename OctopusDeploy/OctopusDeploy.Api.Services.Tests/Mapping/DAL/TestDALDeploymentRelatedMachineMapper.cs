using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DeploymentRelatedMachine")]
        [Trait("Area", "DALMapper")]
        public class TestDALDeploymentRelatedMachineActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALDeploymentRelatedMachineMapper();

                        var bo = new BODeploymentRelatedMachine();

                        bo.SetProperties(1, "A", "A");

                        DeploymentRelatedMachine response = mapper.MapBOToEF(bo);

                        response.DeploymentId.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.MachineId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALDeploymentRelatedMachineMapper();

                        DeploymentRelatedMachine entity = new DeploymentRelatedMachine();

                        entity.SetProperties("A", 1, "A");

                        BODeploymentRelatedMachine  response = mapper.MapEFToBO(entity);

                        response.DeploymentId.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.MachineId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALDeploymentRelatedMachineMapper();

                        DeploymentRelatedMachine entity = new DeploymentRelatedMachine();

                        entity.SetProperties("A", 1, "A");

                        List<BODeploymentRelatedMachine> response = mapper.MapEFToBO(new List<DeploymentRelatedMachine>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>ab83c9b7c95e275e7646addf9e73267b</Hash>
</Codenesium>*/