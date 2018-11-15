using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiShoppingCartItemClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiShoppingCartItemClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime dateCreated,
			DateTime modifiedDate,
			int productID,
			int quantity,
			string shoppingCartID)
		{
			this.DateCreated = dateCreated;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Quantity = quantity;
			this.ShoppingCartID = shoppingCartID;
		}

		[JsonProperty]
		public DateTime DateCreated { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int ProductID { get; private set; } = default(int);

		[JsonProperty]
		public int Quantity { get; private set; } = default(int);

		[JsonProperty]
		public string ShoppingCartID { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>0a788f690a2f7cc24bfdbbae14d45062</Hash>
</Codenesium>*/