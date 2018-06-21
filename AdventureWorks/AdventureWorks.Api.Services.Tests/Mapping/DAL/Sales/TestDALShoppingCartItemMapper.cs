using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ShoppingCartItem")]
        [Trait("Area", "DALMapper")]
        public class TestDALShoppingCartItemMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALShoppingCartItemMapper();
                        var bo = new BOShoppingCartItem();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

                        ShoppingCartItem response = mapper.MapBOToEF(bo);

                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.Quantity.Should().Be(1);
                        response.ShoppingCartID.Should().Be("A");
                        response.ShoppingCartItemID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALShoppingCartItemMapper();
                        ShoppingCartItem entity = new ShoppingCartItem();
                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);

                        BOShoppingCartItem response = mapper.MapEFToBO(entity);

                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.Quantity.Should().Be(1);
                        response.ShoppingCartID.Should().Be("A");
                        response.ShoppingCartItemID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALShoppingCartItemMapper();
                        ShoppingCartItem entity = new ShoppingCartItem();
                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);

                        List<BOShoppingCartItem> response = mapper.MapEFToBO(new List<ShoppingCartItem>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2aeef9c74be9bd34efb65bbe2c1aa1de</Hash>
</Codenesium>*/