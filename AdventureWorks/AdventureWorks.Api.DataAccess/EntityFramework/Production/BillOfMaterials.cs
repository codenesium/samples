using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BillOfMaterials", Schema="Production")]
	public partial class BillOfMaterials: AbstractEntity
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
			this.UnitMeasureCode = unitMeasureCode;
		}

		[Key]
		[Column("BillOfMaterialsID", TypeName="int")]
		public int BillOfMaterialsID { get; private set; }

		[Column("BOMLevel", TypeName="smallint")]
		public short BOMLevel { get; private set; }

		[Column("ComponentID", TypeName="int")]
		public int ComponentID { get; private set; }

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("PerAssemblyQty", TypeName="decimal")]
		public decimal PerAssemblyQty { get; private set; }

		[Column("ProductAssemblyID", TypeName="int")]
		public Nullable<int> ProductAssemblyID { get; private set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; private set; }

		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>78884a15f1c7f67fad5b99c003ca2b2d</Hash>
</Codenesium>*/