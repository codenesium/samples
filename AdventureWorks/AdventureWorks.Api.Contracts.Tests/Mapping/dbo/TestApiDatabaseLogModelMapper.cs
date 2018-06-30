using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DatabaseLog")]
        [Trait("Area", "ApiModel")]
        public class TestApiDatabaseLogModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiDatabaseLogModelMapper();
                        var model = new ApiDatabaseLogRequestModel();
                        model.SetProperties("A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
                        ApiDatabaseLogResponseModel response = mapper.MapRequestToResponse(1, model);

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
                public void MapResponseToRequest()
                {
                        var mapper = new ApiDatabaseLogModelMapper();
                        var model = new ApiDatabaseLogResponseModel();
                        model.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A");
                        ApiDatabaseLogRequestModel response = mapper.MapResponseToRequest(model);

                        response.DatabaseUser.Should().Be("A");
                        response.@Event.Should().Be("A");
                        response.@Object.Should().Be("A");
                        response.PostTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Schema.Should().Be("A");
                        response.TSQL.Should().Be("A");
                        response.XmlEvent.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>b72b21c2fa7b26da9bbecd8f4f789143</Hash>
</Codenesium>*/