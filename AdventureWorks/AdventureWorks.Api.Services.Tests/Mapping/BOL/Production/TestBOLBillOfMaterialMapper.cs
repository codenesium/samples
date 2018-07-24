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
        [Trait("Table", "BillOfMaterial")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLBillOfMaterialMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLBillOfMaterialMapper();
                        ApiBillOfMaterialRequestModel model = new ApiBillOfMaterialRequestModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOBillOfMaterial response = mapper.MapModelToBO(1, model);

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
                        var mapper = new BOLBillOfMaterialMapper();
                        BOBillOfMaterial bo = new BOBillOfMaterial();
                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiBillOfMaterialResponseModel response = mapper.MapBOToModel(bo);

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
                        var mapper = new BOLBillOfMaterialMapper();
                        BOBillOfMaterial bo = new BOBillOfMaterial();
                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiBillOfMaterialResponseModel> response = mapper.MapBOToModel(new List<BOBillOfMaterial>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>e7195d29e19a80cf2505256d9d9b7fbb</Hash>
</Codenesium>*/