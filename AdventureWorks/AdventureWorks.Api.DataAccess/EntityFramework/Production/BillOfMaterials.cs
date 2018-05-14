using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BillOfMaterials", Schema="Production")]
	public partial class BillOfMaterials: AbstractEntityFrameworkPOCO
	{
		public BillOfMaterials()
		{}

		public void SetProperties(
			int billOfMaterialsID,
			short bOMLevel,
			int componentID,
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			decimal perAssemblyQty,
			Nullable<int> productAssemblyID,
			DateTime startDate,
			string unitMeasureCode)
		{
			this.BillOfMaterialsID = billOfMaterialsID.ToInt();
			this.BOMLevel = bOMLevel;
			this.ComponentID = componentID.ToInt();
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PerAssemblyQty = perAssemblyQty.ToDecimal();
			this.ProductAssemblyID = productAssemblyID.ToNullableInt();
			this.StartDate = startDate.ToDateTime();
			this.UnitMeasureCode = unitMeasureCode.ToString();
		}

		[Key]
		[Column("BillOfMaterialsID", TypeName="int")]
		public int BillOfMaterialsID { get; set; }

		[Column("BOMLevel", TypeName="smallint")]
		public short BOMLevel { get; set; }

		[Column("ComponentID", TypeName="int")]
		public int ComponentID { get; set; }

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("PerAssemblyQty", TypeName="decimal")]
		public decimal PerAssemblyQty { get; set; }

		[Column("ProductAssemblyID", TypeName="int")]
		public Nullable<int> ProductAssemblyID { get; set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; set; }

		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode { get; set; }
	}
}

/*<Codenesium>
    <Hash>756adf8fc6ed5d1c553554f950f4888d</Hash>
</Codenesium>*/