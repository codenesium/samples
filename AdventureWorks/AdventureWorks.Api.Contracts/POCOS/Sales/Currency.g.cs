using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCurrency
	{
		public POCOCurrency()
		{}

		public POCOCurrency(string currencyCode,
		                    string name,
		                    DateTime modifiedDate)
		{
			this.CurrencyCode = currencyCode;
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public string CurrencyCode {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyCodeValue {get; set;} = true;

		public bool ShouldSerializeCurrencyCode()
		{
			return ShouldSerializeCurrencyCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCurrencyCodeValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>bd267bd53f7d0a52ea43938a9bffd54f</Hash>
</Codenesium>*/