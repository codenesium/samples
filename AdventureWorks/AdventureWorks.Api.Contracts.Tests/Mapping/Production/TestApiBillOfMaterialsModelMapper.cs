using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "BillOfMaterials")]
        [Trait("Area", "ApiModel")]
        public class TestApiBillOfMaterialsModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiBillOfMaterialsModelMapper();
                        var model = new ApiBillOfMaterialsRequestModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiBillOfMaterialsResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BillOfMaterialsID.Should().Be(1);
                        response.BOMLevel.Should().Be(1);
                        response.ComponentID.Should().Be(1);
                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PerAssemblyQty.Should().Be(1);
                        response.ProductAssemblyID.Should().Be(1);
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.UnitMeasureCode.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiBillOfMaterialsModelMapper();
                        var model = new ApiBillOfMaterialsResponseModel();
                        model.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiBillOfMaterialsRequestModel response = mapper.MapResponseToRequest(model);

                        response.BOMLevel.Should().Be(1);
                        response.ComponentID.Should().Be(1);
                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PerAssemblyQty.Should().Be(1);
                        response.ProductAssemblyID.Should().Be(1);
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.UnitMeasureCode.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>b0fccbe16032cec463495590b6eca164</Hash>
</Codenesium>*/