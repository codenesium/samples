using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCurrencyRate
	{
		public POCOCurrencyRate()
		{}

		public POCOCurrencyRate(
			int currencyRateID,
			DateTime currencyRateDate,
			string fromCurrencyCode,
			string toCurrencyCode,
			decimal averageRate,
			decimal endOfDayRate,
			DateTime modifiedDate)
		{
			this.CurrencyRateID = currencyRateID.ToInt();
			this.CurrencyRateDate = currencyRateDate.ToDateTime();
			this.AverageRate = averageRate;
			this.EndOfDayRate = endOfDayRate;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.FromCurrencyCode = new ReferenceEntity<string>(fromCurrencyCode,
			                                                    "Currency");
			this.ToCurrencyCode = new ReferenceEntity<string>(toCurrencyCode,
			                                                  "Currency");
		}

		public int CurrencyRateID { get; set; }
		public DateTime CurrencyRateDate { get; set; }
		public ReferenceEntity<string> FromCurrencyCode { get; set; }
		public ReferenceEntity<string> ToCurrencyCode { get; set; }
		public decimal AverageRate { get; set; }
		public decimal EndOfDayRate { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCurrencyRateIDValue { get; set; } = true;

		public bool ShouldSerializeCurrencyRateID()
		{
			return this.ShouldSerializeCurrencyRateIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyRateDateValue { get; set; } = true;

		public bool ShouldSerializeCurrencyRateDate()
		{
			return this.ShouldSerializeCurrencyRateDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFromCurrencyCodeValue { get; set; } = true;

		public bool ShouldSerializeFromCurrencyCode()
		{
			return this.ShouldSerializeFromCurrencyCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeToCurrencyCodeValue { get; set; } = true;

		public bool ShouldSerializeToCurrencyCode()
		{
			return this.ShouldSerializeToCurrencyCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAverageRateValue { get; set; } = true;

		public bool ShouldSerializeAverageRate()
		{
			return this.ShouldSerializeAverageRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndOfDayRateValue { get; set; } = true;

		public bool ShouldSerializeEndOfDayRate()
		{
			return this.ShouldSerializeEndOfDayRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCurrencyRateIDValue = false;
			this.ShouldSerializeCurrencyRateDateValue = false;
			this.ShouldSerializeFromCurrencyCodeValue = false;
			this.ShouldSerializeToCurrencyCodeValue = false;
			this.ShouldSerializeAverageRateValue = false;
			this.ShouldSerializeEndOfDayRateValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>117ee4ac9e9486398c4ab46bfc999b0c</Hash>
</Codenesium>*/