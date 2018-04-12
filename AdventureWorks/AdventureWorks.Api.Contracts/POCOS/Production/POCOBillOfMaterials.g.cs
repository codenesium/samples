using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOBillOfMaterials
	{
		public POCOBillOfMaterials()
		{}

		public POCOBillOfMaterials(
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
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.BOMLevel = bOMLevel;
			this.PerAssemblyQty = perAssemblyQty.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.ProductAssemblyID = new ReferenceEntity<Nullable<int>>(productAssemblyID,
			                                                            "Product");
			this.ComponentID = new ReferenceEntity<int>(componentID,
			                                            "Product");
			this.UnitMeasureCode = new ReferenceEntity<string>(unitMeasureCode,
			                                                   "UnitMeasure");
		}

		public int BillOfMaterialsID { get; set; }
		public ReferenceEntity<Nullable<int>> ProductAssemblyID { get; set; }
		public ReferenceEntity<int> ComponentID { get; set; }
		public DateTime StartDate { get; set; }
		public Nullable<DateTime> EndDate { get; set; }
		public ReferenceEntity<string> UnitMeasureCode { get; set; }
		public short BOMLevel { get; set; }
		public decimal PerAssemblyQty { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBillOfMaterialsIDValue { get; set; } = true;

		public bool ShouldSerializeBillOfMaterialsID()
		{
			return this.ShouldSerializeBillOfMaterialsIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductAssemblyIDValue { get; set; } = true;

		public bool ShouldSerializeProductAssemblyID()
		{
			return this.ShouldSerializeProductAssemblyIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeComponentIDValue { get; set; } = true;

		public bool ShouldSerializeComponentID()
		{
			return this.ShouldSerializeComponentIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartDateValue { get; set; } = true;

		public bool ShouldSerializeStartDate()
		{
			return this.ShouldSerializeStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndDateValue { get; set; } = true;

		public bool ShouldSerializeEndDate()
		{
			return this.ShouldSerializeEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitMeasureCodeValue { get; set; } = true;

		public bool ShouldSerializeUnitMeasureCode()
		{
			return this.ShouldSerializeUnitMeasureCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBOMLevelValue { get; set; } = true;

		public bool ShouldSerializeBOMLevel()
		{
			return this.ShouldSerializeBOMLevelValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePerAssemblyQtyValue { get; set; } = true;

		public bool ShouldSerializePerAssemblyQty()
		{
			return this.ShouldSerializePerAssemblyQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBillOfMaterialsIDValue = false;
			this.ShouldSerializeProductAssemblyIDValue = false;
			this.ShouldSerializeComponentIDValue = false;
			this.ShouldSerializeStartDateValue = false;
			this.ShouldSerializeEndDateValue = false;
			this.ShouldSerializeUnitMeasureCodeValue = false;
			this.ShouldSerializeBOMLevelValue = false;
			this.ShouldSerializePerAssemblyQtyValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>0f69627edcd0ae3d8439bc76850014d8</Hash>
</Codenesium>*/