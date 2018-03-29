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
		public int BillOfMaterialsID {get; set;}
		public Nullable<int> ProductAssemblyID {get; set;}
		public int ComponentID {get; set;}
		public DateTime StartDate {get; set;}
		public Nullable<DateTime> EndDate {get; set;}
		public string UnitMeasureCode {get; set;}
		public short BOMLevel {get; set;}
		public decimal PerAssemblyQty {get; set;}
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
    <Hash>02aa4c7b54a341a110038b5b0a3c607d</Hash>
</Codenesium>*/