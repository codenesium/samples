using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ShoppingCartItem", Schema="Sales")]
	public partial class ShoppingCartItem: AbstractEntity
	{
		public ShoppingCartItem()
		{}

		public void SetProperties(
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
			this.ShoppingCartID = shoppingCartID;
			this.ShoppingCartItemID = shoppingCartItemID.ToInt();
		}

		[Column("DateCreated", TypeName="datetime")]
		public DateTime DateCreated { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; private set; }

		[Column("Quantity", TypeName="int")]
		public int Quantity { get; private set; }

		[Column("ShoppingCartID", TypeName="nvarchar(50)")]
		public string ShoppingCartID { get; private set; }

		[Key]
		[Column("ShoppingCartItemID", TypeName="int")]
		public int ShoppingCartItemID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0dda5569c5f9e7dfde4784bc24915c36</Hash>
</Codenesium>*/