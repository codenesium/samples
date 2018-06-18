using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SchemaVersions")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSchemaVersionsActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSchemaVersionsMapper();

                        ApiSchemaVersionsRequestModel model = new ApiSchemaVersionsRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOSchemaVersions response = mapper.MapModelToBO(1, model);

                        response.Applied.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ScriptName.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSchemaVersionsMapper();

                        BOSchemaVersions bo = new BOSchemaVersions();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiSchemaVersionsResponseModel response = mapper.MapBOToModel(bo);

                        response.Applied.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be(1);
                        response.ScriptName.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSchemaVersionsMapper();

                        BOSchemaVersions bo = new BOSchemaVersions();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiSchemaVersionsResponseModel> response = mapper.MapBOToModel(new List<BOSchemaVersions>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>d6be8584ea39a60cbb3dc26e0b508910</Hash>
</Codenesium>*/