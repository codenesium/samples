using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Mutex")]
        [Trait("Area", "DALMapper")]
        public class TestDALMutexActionMapper
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

                        BOMutex  response = mapper.MapEFToBO(entity);

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
    <Hash>777dd09debf45d9a86cf5ddeb87757ce</Hash>
</Codenesium>*/