using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.Contracts
{
	[Table("ShoppingCartItem", Schema="Sales")]
	public partial class EFShoppingCartItem
	{
		public EFShoppingCartItem()
		{}

		public void SetProperties(
			int shoppingCartItemID,
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

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ShoppingCartItemID", TypeName="int")]
		public int ShoppingCartItemID { get; set; }

		[Column("ShoppingCartID", TypeName="nvarchar(50)")]
		public string ShoppingCartID { get; set; }

		[Column("Quantity", TypeName="int")]
		public int Quantity { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("DateCreated", TypeName="datetime")]
		public DateTime DateCreated { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }
	}
}

/*<Codenesium>
    <Hash>a1fff58c2f71889c447eeb90d1757833</Hash>
</Codenesium>*/