using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Machine")]
        [Trait("Area", "DALMapper")]
        public class TestDALMachineActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALMachineMapper();

                        var bo = new BOMachine();

                        bo.SetProperties("A", "A", "A", "A", true, "A", "A", "A", "A", "A", "A", "A", "A");

                        Machine response = mapper.MapBOToEF(bo);

                        response.CommunicationStyle.Should().Be("A");
                        response.EnvironmentIds.Should().Be("A");
                        response.Fingerprint.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.MachinePolicyId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Roles.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                        response.Thumbprint.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALMachineMapper();

                        Machine entity = new Machine();

                        entity.SetProperties("A", "A", "A", "A", true, "A", "A", "A", "A", "A", "A", "A", "A");

                        BOMachine  response = mapper.MapEFToBO(entity);

                        response.CommunicationStyle.Should().Be("A");
                        response.EnvironmentIds.Should().Be("A");
                        response.Fingerprint.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.MachinePolicyId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.RelatedDocumentIds.Should().Be("A");
                        response.Roles.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                        response.Thumbprint.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALMachineMapper();

                        Machine entity = new Machine();

                        entity.SetProperties("A", "A", "A", "A", true, "A", "A", "A", "A", "A", "A", "A", "A");

                        List<BOMachine> response = mapper.MapEFToBO(new List<Machine>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>872c54d90314716fe2f24831fa27626b</Hash>
</Codenesium>*/