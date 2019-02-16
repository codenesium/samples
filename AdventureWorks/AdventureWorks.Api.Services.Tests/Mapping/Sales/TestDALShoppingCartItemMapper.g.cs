using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ShoppingCartItem")]
	[Trait("Area", "DALMapper")]
	public class TestDALShoppingCartItemMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALShoppingCartItemMapper();
			ApiShoppingCartItemServerRequestModel model = new ApiShoppingCartItemServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			ShoppingCartItem response = mapper.MapModelToBO(1, model);

			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ShoppingCartID.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALShoppingCartItemMapper();
			ShoppingCartItem item = new ShoppingCartItem();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			ApiShoppingCartItemServerResponseModel response = mapper.MapBOToModel(item);

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
			var mapper = new DALShoppingCartItemMapper();
			ShoppingCartItem item = new ShoppingCartItem();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			List<ApiShoppingCartItemServerResponseModel> response = mapper.MapBOToModel(new List<ShoppingCartItem>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6db9dd041cdaa37f645634af271c8c40</Hash>
</Codenesium>*/