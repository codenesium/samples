using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "EventRelatedDocument")]
        [Trait("Area", "DALMapper")]
        public class TestDALEventRelatedDocumentMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALEventRelatedDocumentMapper();
                        var bo = new BOEventRelatedDocument();
                        bo.SetProperties(1, "A", "A");

                        EventRelatedDocument response = mapper.MapBOToEF(bo);

                        response.EventId.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.RelatedDocumentId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALEventRelatedDocumentMapper();
                        EventRelatedDocument entity = new EventRelatedDocument();
                        entity.SetProperties("A", 1, "A");

                        BOEventRelatedDocument response = mapper.MapEFToBO(entity);

                        response.EventId.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.RelatedDocumentId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALEventRelatedDocumentMapper();
                        EventRelatedDocument entity = new EventRelatedDocument();
                        entity.SetProperties("A", 1, "A");

                        List<BOEventRelatedDocument> response = mapper.MapEFToBO(new List<EventRelatedDocument>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2c35a188d5930e2f375db99667a8c9bf</Hash>
</Codenesium>*/