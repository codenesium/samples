using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "BillOfMaterials")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLBillOfMaterialsMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLBillOfMaterialsMapper();
                        ApiBillOfMaterialsRequestModel model = new ApiBillOfMaterialsRequestModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOBillOfMaterials response = mapper.MapModelToBO(1, model);

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
                public void MapBOToModel()
                {
                        var mapper = new BOLBillOfMaterialsMapper();
                        BOBillOfMaterials bo = new BOBillOfMaterials();
                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiBillOfMaterialsResponseModel response = mapper.MapBOToModel(bo);

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
                public void MapBOToModelList()
                {
                        var mapper = new BOLBillOfMaterialsMapper();
                        BOBillOfMaterials bo = new BOBillOfMaterials();
                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiBillOfMaterialsResponseModel> response = mapper.MapBOToModel(new List<BOBillOfMaterials>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2f3661730128e543dccde4279569becb</Hash>
</Codenesium>*/