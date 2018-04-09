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

		public virtual EFProduct Product { get; set; }

		public virtual EFLocation Location { get; set; }
	}
}

/*<Codenesium>
    <Hash>41f9ffe7e56817ce52a43975fa69e73e</Hash>
</Codenesium>*/