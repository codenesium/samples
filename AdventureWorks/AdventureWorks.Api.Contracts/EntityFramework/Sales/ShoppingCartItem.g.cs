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
		public int shoppingCartItemID {get; set;}
		public string shoppingCartID {get; set;}
		public int quantity {get; set;}
		public int productID {get; set;}
		public DateTime dateCreated {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>1f5f8b0b877aa9a4f559905fb9a32556</Hash>
</Codenesium>*/