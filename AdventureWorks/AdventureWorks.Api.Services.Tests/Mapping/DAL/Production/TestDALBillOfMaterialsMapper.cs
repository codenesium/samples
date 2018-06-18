using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "BillOfMaterials")]
        [Trait("Area", "DALMapper")]
        public class TestDALBillOfMaterialsActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALBillOfMaterialsMapper();

                        var bo = new BOBillOfMaterials();

                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BillOfMaterials response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALBillOfMaterialsMapper();

                        BillOfMaterials entity = new BillOfMaterials();

                        entity.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BOBillOfMaterials  response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALBillOfMaterialsMapper();

                        BillOfMaterials entity = new BillOfMaterials();

                        entity.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        List<BOBillOfMaterials> response = mapper.MapEFToBO(new List<BillOfMaterials>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>e9a4b0e5c95dbdeb6433e7bc22d4f3ec</Hash>
</Codenesium>*/