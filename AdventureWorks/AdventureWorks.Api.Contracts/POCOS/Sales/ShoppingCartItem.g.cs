using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOShoppingCartItem
	{
		public POCOShoppingCartItem()
		{}

		public POCOShoppingCartItem(int shoppingCartItemID,
		                            string shoppingCartID,
		                            int quantity,
		                            int productID,
		                            DateTime dateCreated,
		                            DateTime modifiedDate)
		{
			this.ShoppingCartItemID = shoppingCartItemID.ToInt();
			this.ShoppingCartID = shoppingCartID;
			this.Quantity = quantity.ToInt();
			this.ProductID = productID.ToInt();
			this.DateCreated = dateCreated.ToDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ShoppingCartItemID {get; set;}
		public string ShoppingCartID {get; set;}
		public int Quantity {get; set;}
		public int ProductID {get; set;}
		public DateTime DateCreated {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeShoppingCartItemIDValue {get; set;} = true;

		public bool ShouldSerializeShoppingCartItemID()
		{
			return ShouldSerializeShoppingCartItemIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShoppingCartIDValue {get; set;} = true;

		public bool ShouldSerializeShoppingCartID()
		{
			return ShouldSerializeShoppingCartIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeQuantityValue {get; set;} = true;

		public bool ShouldSerializeQuantity()
		{
			return ShouldSerializeQuantityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateCreatedValue {get; set;} = true;

		public bool ShouldSerializeDateCreated()
		{
			return ShouldSerializeDateCreatedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeShoppingCartItemIDValue = false;
			this.ShouldSerializeShoppingCartIDValue = false;
			this.ShouldSerializeQuantityValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeDateCreatedValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>eb0c4a27596a7e937ae17be8c0979568</Hash>
</Codenesium>*/