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
		public int ShoppingCartItemID {get; set;}
		public string ShoppingCartID {get; set;}
		public int Quantity {get; set;}
		public int ProductID {get; set;}
		public DateTime DateCreated {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>00f24c31f66ad32c4e67b27ad423db40</Hash>
</Codenesium>*/