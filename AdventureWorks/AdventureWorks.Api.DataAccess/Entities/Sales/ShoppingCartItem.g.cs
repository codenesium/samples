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
			int shoppingCartItemID,
			DateTime dateCreated,
			DateTime modifiedDate,
			int productID,
			int quantity,
			string shoppingCartID)
		{
			this.ShoppingCartItemID = shoppingCartItemID;
			this.DateCreated = dateCreated;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Quantity = quantity;
			this.ShoppingCartID = shoppingCartID;
		}

		[Column("DateCreated")]
		public virtual DateTime DateCreated { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Column("Quantity")]
		public virtual int Quantity { get; private set; }

		[MaxLength(50)]
		[Column("ShoppingCartID")]
		public virtual string ShoppingCartID { get; private set; }

		[Key]
		[Column("ShoppingCartItemID")]
		public virtual int ShoppingCartItemID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b3ba63e30eb06c5d3b5d6f06cd32ec90</Hash>
</Codenesium>*/