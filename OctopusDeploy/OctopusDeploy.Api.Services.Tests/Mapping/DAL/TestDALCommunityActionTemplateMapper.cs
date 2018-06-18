using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CommunityActionTemplate")]
        [Trait("Area", "DALMapper")]
        public class TestDALCommunityActionTemplateActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALCommunityActionTemplateMapper();

                        var bo = new BOCommunityActionTemplate();

                        bo.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");

                        CommunityActionTemplate response = mapper.MapBOToEF(bo);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALCommunityActionTemplateMapper();

                        CommunityActionTemplate entity = new CommunityActionTemplate();

                        entity.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A", "A");

                        BOCommunityActionTemplate  response = mapper.MapEFToBO(entity);

                        response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALCommunityActionTemplateMapper();

                        CommunityActionTemplate entity = new CommunityActionTemplate();

                        entity.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A", "A");

                        List<BOCommunityActionTemplate> response = mapper.MapEFToBO(new List<CommunityActionTemplate>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>7334f4dc1148f123cf7ac85bc033d32f</Hash>
</Codenesium>*/