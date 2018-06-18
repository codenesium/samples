using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "EventRelatedDocument")]
        [Trait("Area", "DALMapper")]
        public class TestDALEventRelatedDocumentActionMapper
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

                        BOEventRelatedDocument  response = mapper.MapEFToBO(entity);

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
    <Hash>f3b793d09cbbbf317599dda81b0fab56</Hash>
</Codenesium>*/