using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractShoppingCartItemMapper
	{
		public virtual BOShoppingCartItem MapModelToBO(
			int shoppingCartItemID,
			ApiShoppingCartItemServerRequestModel model
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

		public virtual ApiShoppingCartItemServerResponseModel MapBOToModel(
			BOShoppingCartItem boShoppingCartItem)
		{
			var model = new ApiShoppingCartItemServerResponseModel();

			model.SetProperties(boShoppingCartItem.ShoppingCartItemID, boShoppingCartItem.DateCreated, boShoppingCartItem.ModifiedDate, boShoppingCartItem.ProductID, boShoppingCartItem.Quantity, boShoppingCartItem.ShoppingCartID);

			return model;
		}

		public virtual List<ApiShoppingCartItemServerResponseModel> MapBOToModel(
			List<BOShoppingCartItem> items)
		{
			List<ApiShoppingCartItemServerResponseModel> response = new List<ApiShoppingCartItemServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>012160669e9a489ce571cfc28dd313db</Hash>
</Codenesium>*/