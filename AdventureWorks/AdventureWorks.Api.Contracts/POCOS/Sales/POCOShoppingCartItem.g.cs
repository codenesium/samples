using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOShoppingCartItem
	{
		public POCOShoppingCartItem()
		{}

		public POCOShoppingCartItem(
			DateTime dateCreated,
			DateTime modifiedDate,
			int productID,
			int quantity,
			string shoppingCartID,
			int shoppingCartItemID)
		{
			this.DateCreated = dateCreated.ToDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.Quantity = quantity.ToInt();
			this.ShoppingCartID = shoppingCartID.ToString();
			this.ShoppingCartItemID = shoppingCartItemID.ToInt();
		}

		public DateTime DateCreated { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }
		public string ShoppingCartID { get; set; }
		public int ShoppingCartItemID { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDateCreatedValue { get; set; } = true;

		public bool ShouldSerializeDateCreated()
		{
			return this.ShouldSerializeDateCreatedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeQuantityValue { get; set; } = true;

		public bool ShouldSerializeQuantity()
		{
			return this.ShouldSerializeQuantityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShoppingCartIDValue { get; set; } = true;

		public bool ShouldSerializeShoppingCartID()
		{
			return this.ShouldSerializeShoppingCartIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShoppingCartItemIDValue { get; set; } = true;

		public bool ShouldSerializeShoppingCartItemID()
		{
			return this.ShouldSerializeShoppingCartItemIDValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDateCreatedValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeQuantityValue = false;
			this.ShouldSerializeShoppingCartIDValue = false;
			this.ShouldSerializeShoppingCartItemIDValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>ba534228c1fcfc9c57ef186c91e73198</Hash>
</Codenesium>*/