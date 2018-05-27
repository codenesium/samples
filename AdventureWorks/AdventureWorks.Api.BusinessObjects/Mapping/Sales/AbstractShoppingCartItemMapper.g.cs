using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLShoppingCartItemMapper
	{
		public virtual DTOShoppingCartItem MapModelToDTO(
			int shoppingCartItemID,
			ApiShoppingCartItemRequestModel model
			)
		{
			DTOShoppingCartItem dtoShoppingCartItem = new DTOShoppingCartItem();

			dtoShoppingCartItem.SetProperties(
				shoppingCartItemID,
				model.DateCreated,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ShoppingCartID);
			return dtoShoppingCartItem;
		}

		public virtual ApiShoppingCartItemResponseModel MapDTOToModel(
			DTOShoppingCartItem dtoShoppingCartItem)
		{
			if (dtoShoppingCartItem == null)
			{
				return null;
			}

			var model = new ApiShoppingCartItemResponseModel();

			model.SetProperties(dtoShoppingCartItem.DateCreated, dtoShoppingCartItem.ModifiedDate, dtoShoppingCartItem.ProductID, dtoShoppingCartItem.Quantity, dtoShoppingCartItem.ShoppingCartID, dtoShoppingCartItem.ShoppingCartItemID);

			return model;
		}

		public virtual List<ApiShoppingCartItemResponseModel> MapDTOToModel(
			List<DTOShoppingCartItem> dtos)
		{
			List<ApiShoppingCartItemResponseModel> response = new List<ApiShoppingCartItemResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>be7e8adf45f6cfe83d68e89c219f71c4</Hash>
</Codenesium>*/