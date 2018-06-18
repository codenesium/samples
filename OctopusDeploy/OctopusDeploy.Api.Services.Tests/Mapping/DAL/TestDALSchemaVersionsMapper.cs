using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SchemaVersions")]
        [Trait("Area", "DALMapper")]
        public class TestDALSchemaVersionsActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSchemaVersionsMapper();

                        var bo = new BOSchemaVersions();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        SchemaVersions response = mapper.MapBOToEF(bo);

                        response.Applied.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.ScriptName.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSchemaVersionsMapper();

                        SchemaVersions entity = new SchemaVersions();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

                        BOSchemaVersions  response = mapper.MapEFToBO(entity);

                        response.Applied.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.ScriptName.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSchemaVersionsMapper();

                        SchemaVersions entity = new SchemaVersions();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

                        List<BOSchemaVersions> response = mapper.MapEFToBO(new List<SchemaVersions>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>52b0cb7bd753b89b0ce30f0171fa3d21</Hash>
</Codenesium>*/