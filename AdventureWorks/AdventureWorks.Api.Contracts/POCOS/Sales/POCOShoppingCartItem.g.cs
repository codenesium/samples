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
			int shoppingCartItemID,
			string shoppingCartID,
			int quantity,
			int productID,
			DateTime dateCreated,
			DateTime modifiedDate)
		{
			this.ShoppingCartItemID = shoppingCartItemID.ToInt();
			this.ShoppingCartID = shoppingCartID.ToString();
			this.Quantity = quantity.ToInt();
			this.DateCreated = dateCreated.ToDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.ProductID = new ReferenceEntity<int>(productID,
			                                          nameof(ApiResponse.Products));
		}

		public int ShoppingCartItemID { get; set; }
		public string ShoppingCartID { get; set; }
		public int Quantity { get; set; }
		public ReferenceEntity<int> ProductID { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeShoppingCartItemIDValue { get; set; } = true;

		public bool ShouldSerializeShoppingCartItemID()
		{
			return this.ShouldSerializeShoppingCartItemIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShoppingCartIDValue { get; set; } = true;

		public bool ShouldSerializeShoppingCartID()
		{
			return this.ShouldSerializeShoppingCartIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeQuantityValue { get; set; } = true;

		public bool ShouldSerializeQuantity()
		{
			return this.ShouldSerializeQuantityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

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
    <Hash>48a64fe694288278e6e306b2f641da2c</Hash>
</Codenesium>*/