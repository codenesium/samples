using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiShoppingCartItemClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>1df5492e2ad983f50717c2e4b8a958b4</Hash>
</Codenesium>*/