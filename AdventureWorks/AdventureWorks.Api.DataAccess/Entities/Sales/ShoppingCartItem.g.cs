using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ShoppingCartItem", Schema="Sales")]
	public partial class ShoppingCartItem : AbstractEntity
	{
		public ShoppingCartItem()
		{
		}

		public virtual void SetProperties(
			DateTime dateCreated,
			DateTime modifiedDate,
			int productID,
			int quantity,
			string shoppingCartID,
			int shoppingCartItemID)
		{
			this.DateCreated = dateCreated;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Quantity = quantity;
			this.ShoppingCartID = shoppingCartID;
			this.ShoppingCartItemID = shoppingCartItemID;
		}

		[Column("DateCreated")]
		public DateTime DateCreated { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("ProductID")]
		public int ProductID { get; private set; }

		[Column("Quantity")]
		public int Quantity { get; private set; }

		[MaxLength(50)]
		[Column("ShoppingCartID")]
		public string ShoppingCartID { get; private set; }

		[Key]
		[Column("ShoppingCartItemID")]
		public int ShoppingCartItemID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a1a22625abdef8e0517f12b09a212a75</Hash>
</Codenesium>*/