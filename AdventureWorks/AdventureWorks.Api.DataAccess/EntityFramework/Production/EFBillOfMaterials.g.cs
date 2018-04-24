using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BillOfMaterials", Schema="Production")]
	public partial class EFBillOfMaterials: AbstractEntityFrameworkPOCO
	{
		public EFBillOfMaterials()
		{}

		public void SetProperties(
			int billOfMaterialsID,
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
			this.UnitMeasureCode = unitMeasureCode.ToString();
			this.BOMLevel = bOMLevel;
			this.PerAssemblyQty = perAssemblyQty.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BillOfMaterialsID", TypeName="int")]
		public int BillOfMaterialsID { get; set; }

		[Column("ProductAssemblyID", TypeName="int")]
		public Nullable<int> ProductAssemblyID { get; set; }

		[Column("ComponentID", TypeName="int")]
		public int ComponentID { get; set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; set; }

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate { get; set; }

		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode { get; set; }

		[Column("BOMLevel", TypeName="smallint")]
		public short BOMLevel { get; set; }

		[Column("PerAssemblyQty", TypeName="decimal")]
		public decimal PerAssemblyQty { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductAssemblyID")]
		public virtual EFProduct Product { get; set; }

		[ForeignKey("ComponentID")]
		public virtual EFProduct Product1 { get; set; }

		[ForeignKey("UnitMeasureCode")]
		public virtual EFUnitMeasure UnitMeasure { get; set; }
	}
}

/*<Codenesium>
    <Hash>5a670cb12af9426f231badad5b1b7a70</Hash>
</Codenesium>*/