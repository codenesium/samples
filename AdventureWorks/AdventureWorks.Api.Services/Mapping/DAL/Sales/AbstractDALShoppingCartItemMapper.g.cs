using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALShoppingCartItemMapper
	{
		public virtual ShoppingCartItem MapModelToEntity(
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

		public virtual ApiShoppingCartItemServerResponseModel MapEntityToModel(
			ShoppingCartItem item)
		{
			var model = new ApiShoppingCartItemServerResponseModel();

			model.SetProperties(item.ShoppingCartItemID,
			                    item.DateCreated,
			                    item.ModifiedDate,
			                    item.ProductID,
			                    item.Quantity,
			                    item.ShoppingCartID);

			return model;
		}

		public virtual List<ApiShoppingCartItemServerResponseModel> MapEntityToModel(
			List<ShoppingCartItem> items)
		{
			List<ApiShoppingCartItemServerResponseModel> response = new List<ApiShoppingCartItemServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e15e8739e3ce4691bcf5055d53913881</Hash>
</Codenesium>*/