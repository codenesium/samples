using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractShoppingCartItemMapper
	{
		public virtual ShoppingCartItem MapBOToEF(
			BOShoppingCartItem bo)
		{
			ShoppingCartItem efShoppingCartItem = new ShoppingCartItem();
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
    <Hash>a0d4c9d098c7719dce06f9f17acf6dbc</Hash>
</Codenesium>*/