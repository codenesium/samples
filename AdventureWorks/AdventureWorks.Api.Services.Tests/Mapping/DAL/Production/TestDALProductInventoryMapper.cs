using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductInventory")]
        [Trait("Area", "DALMapper")]
        public class TestDALProductInventoryActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALProductInventoryMapper();

                        var bo = new BOProductInventory();

                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");

                        ProductInventory response = mapper.MapBOToEF(bo);

                        response.Bin.Should().Be(1);
                        response.LocationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.Quantity.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Shelf.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALProductInventoryMapper();

                        ProductInventory entity = new ProductInventory();

                        entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");

                        BOProductInventory  response = mapper.MapEFToBO(entity);

                        response.Bin.Should().Be(1);
                        response.LocationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.Quantity.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.Shelf.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALProductInventoryMapper();

                        ProductInventory entity = new ProductInventory();

                        entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");

                        List<BOProductInventory> response = mapper.MapEFToBO(new List<ProductInventory>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>0716b0e02225d08a65642b7513e97b3a</Hash>
</Codenesium>*/