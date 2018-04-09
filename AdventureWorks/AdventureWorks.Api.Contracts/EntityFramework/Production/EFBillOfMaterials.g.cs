using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("BillOfMaterials", Schema="Production")]
	public partial class EFBillOfMaterials
	{
		public EFBillOfMaterials()
		{}

		public void SetProperties(int billOfMaterialsID,
		                          Nullable<int> productAssemblyID,
		                          int componentID,
		                          DateTime startDate,
		                          Nullable<DateTime> endDate,
		                          string unitMeasureCode,
		                          short bOMLevel,
		                          decimal perAssemblyQty,
		                          DateTime modifiedDate)
		{
			this.BillOfMaterialsID = billOfMaterialsID.ToInt();
			this.ProductAssemblyID = productAssemblyID.ToNullableInt();
			this.ComponentID = componentID.ToInt();
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.UnitMeasureCode = unitMeasureCode;
			this.BOMLevel = bOMLevel;
			this.PerAssemblyQty = perAssemblyQty.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

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

		public virtual EFProduct Product { get; set; }

		public virtual EFProduct Product1 { get; set; }

		public virtual EFUnitMeasure UnitMeasure { get; set; }
	}
}

/*<Codenesium>
    <Hash>b535b075f41d6cc3bf2029727ad6c8cf</Hash>
</Codenesium>*/