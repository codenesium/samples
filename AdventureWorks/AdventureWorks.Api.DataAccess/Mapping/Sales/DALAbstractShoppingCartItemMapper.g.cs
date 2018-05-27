using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALShoppingCartItemMapper
	{
		public virtual void MapDTOToEF(
			int shoppingCartItemID,
			DTOShoppingCartItem dto,
			ShoppingCartItem efShoppingCartItem)
		{
			efShoppingCartItem.SetProperties(
				shoppingCartItemID,
				dto.DateCreated,
				dto.ModifiedDate,
				dto.ProductID,
				dto.Quantity,
				dto.ShoppingCartID);
		}

		public virtual DTOShoppingCartItem MapEFToDTO(
			ShoppingCartItem ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOShoppingCartItem();

			dto.SetProperties(
				ef.ShoppingCartItemID,
				ef.DateCreated,
				ef.ModifiedDate,
				ef.ProductID,
				ef.Quantity,
				ef.ShoppingCartID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>e0bd41b8e89c7ba0582f1cf72e14fa0c</Hash>
</Codenesium>*/