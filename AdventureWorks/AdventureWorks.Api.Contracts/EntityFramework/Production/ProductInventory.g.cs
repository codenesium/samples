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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}
		[Column("LocationID", TypeName="smallint")]
		public short LocationID {get; set;}
		[Column("Shelf", TypeName="nvarchar(10)")]
		public string Shelf {get; set;}
		[Column("Bin", TypeName="tinyint")]
		public int Bin {get; set;}
		[Column("Quantity", TypeName="smallint")]
		public short Quantity {get; set;}
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
		[ForeignKey("LocationID")]
		public virtual EFLocation LocationRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>e1e5a7d065c59dd5c6caa80e3677f6c4</Hash>
</Codenesium>*/