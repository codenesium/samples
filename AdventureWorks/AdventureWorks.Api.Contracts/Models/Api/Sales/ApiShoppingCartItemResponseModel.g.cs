using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiShoppingCartItemResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int shoppingCartItemID,
			DateTime dateCreated,
			DateTime modifiedDate,
			int productID,
			int quantity,
			string shoppingCartID)
		{
			this.ShoppingCartItemID = shoppingCartItemID;
			this.DateCreated = dateCreated;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Quantity = quantity;
			this.ShoppingCartID = shoppingCartID;
		}

		[JsonProperty]
		public DateTime DateCreated { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public int Quantity { get; private set; }

		[JsonProperty]
		public string ShoppingCartID { get; private set; }

		[JsonProperty]
		public int ShoppingCartItemID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a6a64b539027317506db7e29810444d4</Hash>
</Codenesium>*/