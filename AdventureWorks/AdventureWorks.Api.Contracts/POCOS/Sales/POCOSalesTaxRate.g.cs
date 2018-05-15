using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSalesTaxRate
	{
		public POCOSalesTaxRate()
		{}

		public POCOSalesTaxRate(
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int salesTaxRateID,
			int stateProvinceID,
			decimal taxRate,
			int taxType)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.SalesTaxRateID = salesTaxRateID.ToInt();
			this.StateProvinceID = stateProvinceID.ToInt();
			this.TaxRate = taxRate.ToDecimal();
			this.TaxType = taxType.ToInt();
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public int SalesTaxRateID { get; set; }
		public int StateProvinceID { get; set; }
		public decimal TaxRate { get; set; }
		public int TaxType { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSalesTaxRateIDValue { get; set; } = true;

		public bool ShouldSerializeSalesTaxRateID()
		{
			return this.ShouldSerializeSalesTaxRateIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStateProvinceIDValue { get; set; } = true;

		public bool ShouldSerializeStateProvinceID()
		{
			return this.ShouldSerializeStateProvinceIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTaxRateValue { get; set; } = true;

		public bool ShouldSerializeTaxRate()
		{
			return this.ShouldSerializeTaxRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTaxTypeValue { get; set; } = true;

		public bool ShouldSerializeTaxType()
		{
			return this.ShouldSerializeTaxTypeValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSalesTaxRateIDValue = false;
			this.ShouldSerializeStateProvinceIDValue = false;
			this.ShouldSerializeTaxRateValue = false;
			this.ShouldSerializeTaxTypeValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>b00caf68770e3bc2e00b10e308d91703</Hash>
</Codenesium>*/