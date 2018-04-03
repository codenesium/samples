using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOBillOfMaterials
	{
		public POCOBillOfMaterials()
		{}

		public POCOBillOfMaterials(int billOfMaterialsID,
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

		public int BillOfMaterialsID {get; set;}
		public Nullable<int> ProductAssemblyID {get; set;}
		public int ComponentID {get; set;}
		public DateTime StartDate {get; set;}
		public Nullable<DateTime> EndDate {get; set;}
		public string UnitMeasureCode {get; set;}
		public short BOMLevel {get; set;}
		public decimal PerAssemblyQty {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeBillOfMaterialsIDValue {get; set;} = true;

		public bool ShouldSerializeBillOfMaterialsID()
		{
			return ShouldSerializeBillOfMaterialsIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductAssemblyIDValue {get; set;} = true;

		public bool ShouldSerializeProductAssemblyID()
		{
			return ShouldSerializeProductAssemblyIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeComponentIDValue {get; set;} = true;

		public bool ShouldSerializeComponentID()
		{
			return ShouldSerializeComponentIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartDateValue {get; set;} = true;

		public bool ShouldSerializeStartDate()
		{
			return ShouldSerializeStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndDateValue {get; set;} = true;

		public bool ShouldSerializeEndDate()
		{
			return ShouldSerializeEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitMeasureCodeValue {get; set;} = true;

		public bool ShouldSerializeUnitMeasureCode()
		{
			return ShouldSerializeUnitMeasureCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBOMLevelValue {get; set;} = true;

		public bool ShouldSerializeBOMLevel()
		{
			return ShouldSerializeBOMLevelValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePerAssemblyQtyValue {get; set;} = true;

		public bool ShouldSerializePerAssemblyQty()
		{
			return ShouldSerializePerAssemblyQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>9c96a4680923276f952e882b0d4e9f6c</Hash>
</Codenesium>*/