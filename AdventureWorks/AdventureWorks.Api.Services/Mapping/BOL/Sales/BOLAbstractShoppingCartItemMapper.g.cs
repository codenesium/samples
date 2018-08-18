using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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

			model.SetProperties(boShoppingCartItem.ShoppingCartItemID, boShoppingCartItem.DateCreated, boShoppingCartItem.ModifiedDate, boShoppingCartItem.ProductID, boShoppingCartItem.Quantity, boShoppingCartItem.ShoppingCartID);

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
    <Hash>c6402e49d8ea814bfa5e072655c509b1</Hash>
</Codenesium>*/