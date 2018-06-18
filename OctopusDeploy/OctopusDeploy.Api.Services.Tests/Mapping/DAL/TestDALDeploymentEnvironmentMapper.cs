using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DeploymentEnvironment")]
        [Trait("Area", "DALMapper")]
        public class TestDALDeploymentEnvironmentActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALDeploymentEnvironmentMapper();

                        var bo = new BODeploymentEnvironment();

                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", 1);

                        DeploymentEnvironment response = mapper.MapBOToEF(bo);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALDeploymentEnvironmentMapper();

                        DeploymentEnvironment entity = new DeploymentEnvironment();

                        entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", 1);

                        BODeploymentEnvironment  response = mapper.MapEFToBO(entity);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.SortOrder.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALDeploymentEnvironmentMapper();

                        DeploymentEnvironment entity = new DeploymentEnvironment();

                        entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", 1);

                        List<BODeploymentEnvironment> response = mapper.MapEFToBO(new List<DeploymentEnvironment>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>a347b9c7ef097197f137bbc7cc6a9398</Hash>
</Codenesium>*/