using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOShoppingCartItem: AbstractBusinessObject
	{
		public BOShoppingCartItem() : base()
		{}

		public void SetProperties(int shoppingCartItemID,
		                          DateTime dateCreated,
		                          DateTime modifiedDate,
		                          int productID,
		                          int quantity,
		                          string shoppingCartID)
		{
			this.DateCreated = dateCreated.ToDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.Quantity = quantity.ToInt();
			this.ShoppingCartID = shoppingCartID;
			this.ShoppingCartItemID = shoppingCartItemID.ToInt();
		}

		public DateTime DateCreated { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductID { get; private set; }
		public int Quantity { get; private set; }
		public string ShoppingCartID { get; private set; }
		public int ShoppingCartItemID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e23b5978e763dbfb202980faa76b3ced</Hash>
</Codenesium>*/