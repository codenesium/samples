using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ShoppingCartItem", Schema="Sales")]
	public partial class ShoppingCartItem: AbstractEntityFrameworkDTO
	{
		public ShoppingCartItem()
		{}

		public void SetProperties(
			int shoppingCartItemID,
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

		[Column("DateCreated", TypeName="datetime")]
		public DateTime DateCreated { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("Quantity", TypeName="int")]
		public int Quantity { get; set; }

		[Column("ShoppingCartID", TypeName="nvarchar(50)")]
		public string ShoppingCartID { get; set; }

		[Key]
		[Column("ShoppingCartItemID", TypeName="int")]
		public int ShoppingCartItemID { get; set; }
	}
}

/*<Codenesium>
    <Hash>af0e3f0ca0f65c2b6f2e3265d13249a5</Hash>
</Codenesium>*/