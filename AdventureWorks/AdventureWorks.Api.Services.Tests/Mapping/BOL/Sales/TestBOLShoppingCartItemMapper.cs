using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ShoppingCartItem")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLShoppingCartItemActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLShoppingCartItemMapper();

                        ApiShoppingCartItemRequestModel model = new ApiShoppingCartItemRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
                        BOShoppingCartItem response = mapper.MapModelToBO(1, model);

                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.Quantity.Should().Be(1);
                        response.ShoppingCartID.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLShoppingCartItemMapper();

                        BOShoppingCartItem bo = new BOShoppingCartItem();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
                        ApiShoppingCartItemResponseModel response = mapper.MapBOToModel(bo);

                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.Quantity.Should().Be(1);
                        response.ShoppingCartID.Should().Be("A");
                        response.ShoppingCartItemID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLShoppingCartItemMapper();

                        BOShoppingCartItem bo = new BOShoppingCartItem();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
                        List<ApiShoppingCartItemResponseModel> response = mapper.MapBOToModel(new List<BOShoppingCartItem>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>d4cd722e4f1734983d4aef9df693748c</Hash>
</Codenesium>*/