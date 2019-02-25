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
		public void MapModelToEntity()
		{
			var mapper = new DALShoppingCartItemMapper();
			ApiShoppingCartItemServerRequestModel model = new ApiShoppingCartItemServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			ShoppingCartItem response = mapper.MapModelToEntity(1, model);

			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ShoppingCartID.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALShoppingCartItemMapper();
			ShoppingCartItem item = new ShoppingCartItem();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			ApiShoppingCartItemServerResponseModel response = mapper.MapEntityToModel(item);

			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ShoppingCartID.Should().Be("A");
			response.ShoppingCartItemID.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALShoppingCartItemMapper();
			ShoppingCartItem item = new ShoppingCartItem();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");
			List<ApiShoppingCartItemServerResponseModel> response = mapper.MapEntityToModel(new List<ShoppingCartItem>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>81f93175935302f3812586eed9e6c573</Hash>
</Codenesium>*/