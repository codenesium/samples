using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "MachinePolicy")]
        [Trait("Area", "DALMapper")]
        public class TestDALMachinePolicyMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALMachinePolicyMapper();
                        var bo = new BOMachinePolicy();
                        bo.SetProperties("A", true, "A", "A");

                        MachinePolicy response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be("A");
                        response.IsDefault.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALMachinePolicyMapper();
                        MachinePolicy entity = new MachinePolicy();
                        entity.SetProperties("A", true, "A", "A");

                        BOMachinePolicy response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be("A");
                        response.IsDefault.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALMachinePolicyMapper();
                        MachinePolicy entity = new MachinePolicy();
                        entity.SetProperties("A", true, "A", "A");

                        List<BOMachinePolicy> response = mapper.MapEFToBO(new List<MachinePolicy>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>71233e61e03222e40b5a0bcbc7bb2c95</Hash>
</Codenesium>*/