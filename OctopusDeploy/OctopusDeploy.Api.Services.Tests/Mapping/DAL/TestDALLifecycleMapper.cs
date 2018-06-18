using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Lifecycle")]
        [Trait("Area", "DALMapper")]
        public class TestDALLifecycleActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALLifecycleMapper();

                        var bo = new BOLifecycle();

                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A");

                        Lifecycle response = mapper.MapBOToEF(bo);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALLifecycleMapper();

                        Lifecycle entity = new Lifecycle();

                        entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A");

                        BOLifecycle  response = mapper.MapEFToBO(entity);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALLifecycleMapper();

                        Lifecycle entity = new Lifecycle();

                        entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A");

                        List<BOLifecycle> response = mapper.MapEFToBO(new List<Lifecycle>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>30406945b74fa98a15b0476cd755a200</Hash>
</Codenesium>*/