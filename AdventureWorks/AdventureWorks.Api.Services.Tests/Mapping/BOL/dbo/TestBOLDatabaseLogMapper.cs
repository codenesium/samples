using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DatabaseLog")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLDatabaseLogActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLDatabaseLogMapper();

                        ApiDatabaseLogRequestModel model = new ApiDatabaseLogRequestModel();

                        model.SetProperties("A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
                        BODatabaseLog response = mapper.MapModelToBO(1, model);

                        response.DatabaseUser.Should().Be("A");
                        response.@Event.Should().Be("A");
                        response.@Object.Should().Be("A");
                        response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Schema.Should().Be("A");
                        response.TSQL.Should().Be("A");
                        response.XmlEvent.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLDatabaseLogMapper();

                        BODatabaseLog bo = new BODatabaseLog();

                        bo.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
                        ApiDatabaseLogResponseModel response = mapper.MapBOToModel(bo);

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
                public void MapBOToModelList()
                {
                        var mapper = new BOLDatabaseLogMapper();

                        BODatabaseLog bo = new BODatabaseLog();

                        bo.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
                        List<ApiDatabaseLogResponseModel> response = mapper.MapBOToModel(new List<BODatabaseLog>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>baa3f7119f15b456073dce4ec7a13097</Hash>
</Codenesium>*/