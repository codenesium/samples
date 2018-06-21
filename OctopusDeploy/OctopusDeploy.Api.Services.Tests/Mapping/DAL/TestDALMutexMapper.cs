using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Mutex")]
        [Trait("Area", "DALMapper")]
        public class TestDALMutexMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALMutexMapper();
                        var bo = new BOMutex();
                        bo.SetProperties("A", "A");

                        Mutex response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALMutexMapper();
                        Mutex entity = new Mutex();
                        entity.SetProperties("A", "A");

                        BOMutex response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALMutexMapper();
                        Mutex entity = new Mutex();
                        entity.SetProperties("A", "A");

                        List<BOMutex> response = mapper.MapEFToBO(new List<Mutex>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>5acdfbc5e8c93cb0af2512bec23bbaf3</Hash>
</Codenesium>*/