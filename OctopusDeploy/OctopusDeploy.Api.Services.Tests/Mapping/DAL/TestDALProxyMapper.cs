using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Proxy")]
        [Trait("Area", "DALMapper")]
        public class TestDALProxyActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALProxyMapper();

                        var bo = new BOProxy();

                        bo.SetProperties("A", "A", "A");

                        Proxy response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALProxyMapper();

                        Proxy entity = new Proxy();

                        entity.SetProperties("A", "A", "A");

                        BOProxy  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALProxyMapper();

                        Proxy entity = new Proxy();

                        entity.SetProperties("A", "A", "A");

                        List<BOProxy> response = mapper.MapEFToBO(new List<Proxy>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>de603699df03ff380ee2886205fd88d9</Hash>
</Codenesium>*/