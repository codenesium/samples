using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "UnitMeasure")]
        [Trait("Area", "ApiModel")]
        public class TestApiUnitMeasureModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiUnitMeasureModelMapper();
                        var model = new ApiUnitMeasureRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiUnitMeasureResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.UnitMeasureCode.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiUnitMeasureModelMapper();
                        var model = new ApiUnitMeasureResponseModel();
                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiUnitMeasureRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiUnitMeasureModelMapper();
                        var model = new ApiUnitMeasureRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        JsonPatchDocument<ApiUnitMeasureRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiUnitMeasureRequestModel();
                        patch.ApplyTo(response);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>639ecc6bbea13f58c09a905aba745cca</Hash>
</Codenesium>*/