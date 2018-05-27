using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOShoppingCartItem: AbstractDTO
	{
		public DTOShoppingCartItem() : base()
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

		public DateTime DateCreated { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }
		public string ShoppingCartID { get; set; }
		public int ShoppingCartItemID { get; set; }
	}
}

/*<Codenesium>
    <Hash>605c1fe0f26abcaebcc49c069c61a722</Hash>
</Codenesium>*/