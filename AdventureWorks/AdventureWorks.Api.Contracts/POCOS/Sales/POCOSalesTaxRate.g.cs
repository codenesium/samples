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
			int salesTaxRateID,
			int stateProvinceID,
			int taxType,
			decimal taxRate,
			string name,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.SalesTaxRateID = salesTaxRateID.ToInt();
			this.TaxType = taxType;
			this.TaxRate = taxRate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.StateProvinceID = new ReferenceEntity<int>(stateProvinceID,
			                                                "StateProvince");
		}

		public int SalesTaxRateID { get; set; }
		public ReferenceEntity<int> StateProvinceID { get; set; }
		public int TaxType { get; set; }
		public decimal TaxRate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

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
		public bool ShouldSerializeTaxTypeValue { get; set; } = true;

		public bool ShouldSerializeTaxType()
		{
			return this.ShouldSerializeTaxTypeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTaxRateValue { get; set; } = true;

		public bool ShouldSerializeTaxRate()
		{
			return this.ShouldSerializeTaxRateValue;
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
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeSalesTaxRateIDValue = false;
			this.ShouldSerializeStateProvinceIDValue = false;
			this.ShouldSerializeTaxTypeValue = false;
			this.ShouldSerializeTaxRateValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>8b064755e68c12ce16f550145bf8431e</Hash>
</Codenesium>*/