using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductInventory", Schema="Production")]
	public partial class EFProductInventory
	{
		public EFProductInventory()
		{}

		[Key]
		public int ProductID {get; set;}
		public short LocationID {get; set;}
		public string Shelf {get; set;}
		public int Bin {get; set;}
		public short Quantity {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
		[ForeignKey("LocationID")]
		public virtual EFLocation LocationRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>b84e28ea0f595402ebbe012000c6a3be</Hash>
</Codenesium>*/