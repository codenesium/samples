using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("BillOfMaterials", Schema="Production")]
	public partial class EFBillOfMaterials
	{
		public EFBillOfMaterials()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BillOfMaterialsID", TypeName="int")]
		public int BillOfMaterialsID {get; set;}

		[Column("ProductAssemblyID", TypeName="int")]
		public Nullable<int> ProductAssemblyID {get; set;}

		[Column("ComponentID", TypeName="int")]
		public int ComponentID {get; set;}

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate {get; set;}

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate {get; set;}

		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode {get; set;}

		[Column("BOMLevel", TypeName="smallint")]
		public short BOMLevel {get; set;}

		[Column("PerAssemblyQty", TypeName="decimal")]
		public decimal PerAssemblyQty {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductAssemblyID")]
		public virtual EFProduct Product { get; set; }
		[ForeignKey("ComponentID")]
		public virtual EFProduct Product1 { get; set; }
		[ForeignKey("UnitMeasureCode")]
		public virtual EFUnitMeasure UnitMeasure { get; set; }
	}
}

/*<Codenesium>
    <Hash>8b0db37228a6856a46cc29e49756a07c</Hash>
</Codenesium>*/