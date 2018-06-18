using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DatabaseLog")]
        [Trait("Area", "DALMapper")]
        public class TestDALDatabaseLogActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALDatabaseLogMapper();

                        var bo = new BODatabaseLog();

                        bo.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");

                        DatabaseLog response = mapper.MapBOToEF(bo);

                        response.DatabaseLogID.Should().Be(1);
                        response.DatabaseUser.Should().Be("A");
                        response.@Event.Should().Be("A");
                        response.@Object.Should().Be("A");
                        response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Schema.Should().Be("A");
                        response.TSQL.Should().Be("A");
                        response.XmlEvent.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALDatabaseLogMapper();

                        DatabaseLog entity = new DatabaseLog();

                        entity.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");

                        BODatabaseLog  response = mapper.MapEFToBO(entity);

                        response.DatabaseLogID.Should().Be(1);
                        response.DatabaseUser.Should().Be("A");
                        response.@Event.Should().Be("A");
                        response.@Object.Should().Be("A");
                        response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Schema.Should().Be("A");
                        response.TSQL.Should().Be("A");
                        response.XmlEvent.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALDatabaseLogMapper();

                        DatabaseLog entity = new DatabaseLog();

                        entity.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");

                        List<BODatabaseLog> response = mapper.MapEFToBO(new List<DatabaseLog>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1a4334bb5a45a43380048bd8955d66f6</Hash>
</Codenesium>*/