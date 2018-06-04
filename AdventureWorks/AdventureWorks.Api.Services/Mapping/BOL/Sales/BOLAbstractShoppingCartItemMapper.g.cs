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
			BOShoppingCartItem BOShoppingCartItem = new BOShoppingCartItem();

			BOShoppingCartItem.SetProperties(
				shoppingCartItemID,
				model.DateCreated,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ShoppingCartID);
			return BOShoppingCartItem;
		}

		public virtual ApiShoppingCartItemResponseModel MapBOToModel(
			BOShoppingCartItem BOShoppingCartItem)
		{
			if (BOShoppingCartItem == null)
			{
				return null;
			}

			var model = new ApiShoppingCartItemResponseModel();

			model.SetProperties(BOShoppingCartItem.DateCreated, BOShoppingCartItem.ModifiedDate, BOShoppingCartItem.ProductID, BOShoppingCartItem.Quantity, BOShoppingCartItem.ShoppingCartID, BOShoppingCartItem.ShoppingCartItemID);

			return model;
		}

		public virtual List<ApiShoppingCartItemResponseModel> MapBOToModel(
			List<BOShoppingCartItem> BOs)
		{
			List<ApiShoppingCartItemResponseModel> response = new List<ApiShoppingCartItemResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3925831e7462f243e629836f690d7997</Hash>
</Codenesium>*/