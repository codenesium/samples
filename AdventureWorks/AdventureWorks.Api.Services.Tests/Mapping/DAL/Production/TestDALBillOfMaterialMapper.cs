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
        [Trait("Area", "DALMapper")]
        public class TestDALBillOfMaterialMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALBillOfMaterialMapper();
                        var bo = new BOBillOfMaterial();
                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BillOfMaterial response = mapper.MapBOToEF(bo);

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
                        var mapper = new DALBillOfMaterialMapper();
                        BillOfMaterial entity = new BillOfMaterial();
                        entity.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BOBillOfMaterial response = mapper.MapEFToBO(entity);

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
                        var mapper = new DALBillOfMaterialMapper();
                        BillOfMaterial entity = new BillOfMaterial();
                        entity.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        List<BOBillOfMaterial> response = mapper.MapEFToBO(new List<BillOfMaterial>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>09803fa3a38ee9452c402a420bec536d</Hash>
</Codenesium>*/