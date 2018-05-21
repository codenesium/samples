using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCurrency: AbstractPOCO
	{
		public POCOCurrency() : base()
		{}

		public POCOCurrency(
			string currencyCode,
			DateTime modifiedDate,
			string name)
		{
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public string CurrencyCode { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCurrencyCodeValue { get; set; } = true;

		public bool ShouldSerializeCurrencyCode()
		{
			return this.ShouldSerializeCurrencyCodeValue;
		}

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

		public void DisableAllFields()
		{
			this.ShouldSerializeCurrencyCodeValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>71c1c314ba1f507c315a4f78704c713f</Hash>
</Codenesium>*/