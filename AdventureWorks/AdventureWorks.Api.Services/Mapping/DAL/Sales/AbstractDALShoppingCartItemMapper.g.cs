using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALShoppingCartItemMapper
	{
		public virtual ShoppingCartItem MapModelToBO(
			int shoppingCartItemID,
			ApiShoppingCartItemServerRequestModel model
			)
		{
			ShoppingCartItem item = new ShoppingCartItem();
			item.SetProperties(
				shoppingCartItemID,
				model.DateCreated,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ShoppingCartID);
			return item;
		}

		public virtual ApiShoppingCartItemServerResponseModel MapBOToModel(
			ShoppingCartItem item)
		{
			var model = new ApiShoppingCartItemServerResponseModel();

			model.SetProperties(item.ShoppingCartItemID, item.DateCreated, item.ModifiedDate, item.ProductID, item.Quantity, item.ShoppingCartID);

			return model;
		}

		public virtual List<ApiShoppingCartItemServerResponseModel> MapBOToModel(
			List<ShoppingCartItem> items)
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
    <Hash>cfc9b4bac2839e01f4d2f9ee9e796f53</Hash>
</Codenesium>*/