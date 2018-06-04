using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALShoppingCartItemMapper
	{
		public virtual ShoppingCartItem MapBOToEF(
			BOShoppingCartItem bo)
		{
			ShoppingCartItem efShoppingCartItem = new ShoppingCartItem ();

			efShoppingCartItem.SetProperties(
				bo.DateCreated,
				bo.ModifiedDate,
				bo.ProductID,
				bo.Quantity,
				bo.ShoppingCartID,
				bo.ShoppingCartItemID);
			return efShoppingCartItem;
		}

		public virtual BOShoppingCartItem MapEFToBO(
			ShoppingCartItem ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOShoppingCartItem();

			bo.SetProperties(
				ef.ShoppingCartItemID,
				ef.DateCreated,
				ef.ModifiedDate,
				ef.ProductID,
				ef.Quantity,
				ef.ShoppingCartID);
			return bo;
		}

		public virtual List<BOShoppingCartItem> MapEFToBO(
			List<ShoppingCartItem> records)
		{
			List<BOShoppingCartItem> response = new List<BOShoppingCartItem>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ae6fbdfaaab473ab9a99cc78f7b91a6c</Hash>
</Codenesium>*/