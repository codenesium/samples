using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiShoppingCartItemServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiShoppingCartItemServerRequestModel()
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
		public DateTime DateCreated { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

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
    <Hash>31f9822acfe140997f013dda241ff298</Hash>
</Codenesium>*/