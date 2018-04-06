using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ShoppingCartItem", Schema="Sales")]
	public partial class EFShoppingCartItem
	{
		public EFShoppingCartItem()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ShoppingCartItemID", TypeName="int")]
		public int ShoppingCartItemID {get; set;}
		[Column("ShoppingCartID", TypeName="nvarchar(50)")]
		public string ShoppingCartID {get; set;}
		[Column("Quantity", TypeName="int")]
		public int Quantity {get; set;}
		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}
		[Column("DateCreated", TypeName="datetime")]
		public DateTime DateCreated {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>46f10d31fa602f9eb1d0225dd934b3b2</Hash>
</Codenesium>*/