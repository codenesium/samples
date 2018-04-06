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
		public virtual EFProduct ProductRef { get; set; }
		[ForeignKey("ComponentID")]
		public virtual EFProduct ProductRef1 { get; set; }
		[ForeignKey("UnitMeasureCode")]
		public virtual EFUnitMeasure UnitMeasureRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>426a2cc75c33348e56d72f6e5841b897</Hash>
</Codenesium>*/