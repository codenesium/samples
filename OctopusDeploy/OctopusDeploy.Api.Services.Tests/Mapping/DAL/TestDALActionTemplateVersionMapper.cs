using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ActionTemplateVersion")]
        [Trait("Area", "DALMapper")]
        public class TestDALActionTemplateVersionActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALActionTemplateVersionMapper();

                        var bo = new BOActionTemplateVersion();

                        bo.SetProperties("A", "A", "A", "A", "A", 1);

                        ActionTemplateVersion response = mapper.MapBOToEF(bo);

                        response.ActionType.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.LatestActionTemplateId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALActionTemplateVersionMapper();

                        ActionTemplateVersion entity = new ActionTemplateVersion();

                        entity.SetProperties("A", "A", "A", "A", "A", 1);

                        BOActionTemplateVersion  response = mapper.MapEFToBO(entity);

                        response.ActionType.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.LatestActionTemplateId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALActionTemplateVersionMapper();

                        ActionTemplateVersion entity = new ActionTemplateVersion();

                        entity.SetProperties("A", "A", "A", "A", "A", 1);

                        List<BOActionTemplateVersion> response = mapper.MapEFToBO(new List<ActionTemplateVersion>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>ded2ba04d3be64fcfa3b184e9521204d</Hash>
</Codenesium>*/