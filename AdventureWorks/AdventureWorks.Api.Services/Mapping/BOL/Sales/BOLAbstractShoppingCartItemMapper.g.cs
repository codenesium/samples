using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractShoppingCartItemMapper
	{
		public virtual BOShoppingCartItem MapModelToBO(
			int shoppingCartItemID,
			ApiShoppingCartItemRequestModel model
			)
		{
			BOShoppingCartItem boShoppingCartItem = new BOShoppingCartItem();

			boShoppingCartItem.SetProperties(
				shoppingCartItemID,
				model.DateCreated,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ShoppingCartID);
			return boShoppingCartItem;
		}

		public virtual ApiShoppingCartItemResponseModel MapBOToModel(
			BOShoppingCartItem boShoppingCartItem)
		{
			var model = new ApiShoppingCartItemResponseModel();

			model.SetProperties(boShoppingCartItem.DateCreated, boShoppingCartItem.ModifiedDate, boShoppingCartItem.ProductID, boShoppingCartItem.Quantity, boShoppingCartItem.ShoppingCartID, boShoppingCartItem.ShoppingCartItemID);

			return model;
		}

		public virtual List<ApiShoppingCartItemResponseModel> MapBOToModel(
			List<BOShoppingCartItem> items)
		{
			List<ApiShoppingCartItemResponseModel> response = new List<ApiShoppingCartItemResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>74b61f2fe353e3caebe5d21d41798652</Hash>
</Codenesium>*/