using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiShoppingCartItemRequestModel : AbstractApiRequestModel
	{
		public ApiShoppingCartItemRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime DateCreated { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int Quantity { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string ShoppingCartID { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>8848ae0f08bd3395957d29d490c014bb</Hash>
</Codenesium>*/