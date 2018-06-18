using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ActionTemplate")]
        [Trait("Area", "DALMapper")]
        public class TestDALActionTemplateActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALActionTemplateMapper();

                        var bo = new BOActionTemplate();

                        bo.SetProperties("A", "A", "A", "A", "A", 1);

                        ActionTemplate response = mapper.MapBOToEF(bo);

                        response.ActionType.Should().Be("A");
                        response.CommunityActionTemplateId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALActionTemplateMapper();

                        ActionTemplate entity = new ActionTemplate();

                        entity.SetProperties("A", "A", "A", "A", "A", 1);

                        BOActionTemplate  response = mapper.MapEFToBO(entity);

                        response.ActionType.Should().Be("A");
                        response.CommunityActionTemplateId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALActionTemplateMapper();

                        ActionTemplate entity = new ActionTemplate();

                        entity.SetProperties("A", "A", "A", "A", "A", 1);

                        List<BOActionTemplate> response = mapper.MapEFToBO(new List<ActionTemplate>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>3a1bb73e59a7dd56c9ec10ff8b7ba838</Hash>
</Codenesium>*/