using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DatabaseLog")]
        [Trait("Area", "DALMapper")]
        public class TestDALDatabaseLogMapper
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
                        response.Tsql.Should().Be("A");
                        response.XmlEvent.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALDatabaseLogMapper();
                        DatabaseLog entity = new DatabaseLog();
                        entity.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");

                        BODatabaseLog response = mapper.MapEFToBO(entity);

                        response.DatabaseLogID.Should().Be(1);
                        response.DatabaseUser.Should().Be("A");
                        response.@Event.Should().Be("A");
                        response.@Object.Should().Be("A");
                        response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Schema.Should().Be("A");
                        response.Tsql.Should().Be("A");
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
    <Hash>a68cf2a7324ce025f6eb932a0cf375ee</Hash>
</Codenesium>*/