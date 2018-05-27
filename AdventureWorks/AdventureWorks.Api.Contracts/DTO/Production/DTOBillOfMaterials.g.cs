using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOBillOfMaterials: AbstractDTO
	{
		public DTOBillOfMaterials() : base()
		{}

		public void SetProperties(int billOfMaterialsID,
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

		public int BillOfMaterialsID { get; set; }
		public short BOMLevel { get; set; }
		public int ComponentID { get; set; }
		public Nullable<DateTime> EndDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public decimal PerAssemblyQty { get; set; }
		public Nullable<int> ProductAssemblyID { get; set; }
		public DateTime StartDate { get; set; }
		public string UnitMeasureCode { get; set; }
	}
}

/*<Codenesium>
    <Hash>5ab830a808795d270691dae0561d0e0e</Hash>
</Codenesium>*/