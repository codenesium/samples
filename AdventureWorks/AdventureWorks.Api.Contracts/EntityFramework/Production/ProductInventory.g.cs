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
		public int productID {get; set;}
		public short locationID {get; set;}
		public string shelf {get; set;}
		public int bin {get; set;}
		public short quantity {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>c45fdfc7a981295858a74058aeca10cf</Hash>
</Codenesium>*/