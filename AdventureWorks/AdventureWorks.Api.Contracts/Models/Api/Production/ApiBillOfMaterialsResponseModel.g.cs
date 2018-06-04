using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiBillOfMaterialsResponseModel: AbstractApiResponseModel
	{
		public ApiBillOfMaterialsResponseModel() : base()
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

		public int BillOfMaterialsID { get; private set; }
		public short BOMLevel { get; private set; }
		public int ComponentID { get; private set; }
		public Nullable<DateTime> EndDate { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public decimal PerAssemblyQty { get; private set; }
		public Nullable<int> ProductAssemblyID { get; private set; }
		public DateTime StartDate { get; private set; }
		public string UnitMeasureCode { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeBillOfMaterialsIDValue { get; set; } = true;

		public bool ShouldSerializeBillOfMaterialsID()
		{
			return this.ShouldSerializeBillOfMaterialsIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBOMLevelValue { get; set; } = true;

		public bool ShouldSerializeBOMLevel()
		{
			return this.ShouldSerializeBOMLevelValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeComponentIDValue { get; set; } = true;

		public bool ShouldSerializeComponentID()
		{
			return this.ShouldSerializeComponentIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndDateValue { get; set; } = true;

		public bool ShouldSerializeEndDate()
		{
			return this.ShouldSerializeEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePerAssemblyQtyValue { get; set; } = true;

		public bool ShouldSerializePerAssemblyQty()
		{
			return this.ShouldSerializePerAssemblyQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductAssemblyIDValue { get; set; } = true;

		public bool ShouldSerializeProductAssemblyID()
		{
			return this.ShouldSerializeProductAssemblyIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartDateValue { get; set; } = true;

		public bool ShouldSerializeStartDate()
		{
			return this.ShouldSerializeStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeUnitMeasureCodeValue { get; set; } = true;

		public bool ShouldSerializeUnitMeasureCode()
		{
			return this.ShouldSerializeUnitMeasureCodeValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBillOfMaterialsIDValue = false;
			this.ShouldSerializeBOMLevelValue = false;
			this.ShouldSerializeComponentIDValue = false;
			this.ShouldSerializeEndDateValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializePerAssemblyQtyValue = false;
			this.ShouldSerializeProductAssemblyIDValue = false;
			this.ShouldSerializeStartDateValue = false;
			this.ShouldSerializeUnitMeasureCodeValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>3940dc92d8acacc05adb3dd185e1a02c</Hash>
</Codenesium>*/