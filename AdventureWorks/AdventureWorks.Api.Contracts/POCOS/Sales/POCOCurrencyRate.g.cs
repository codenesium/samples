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
			this.AverageRate = averageRate.ToDecimal();
			this.EndOfDayRate = endOfDayRate.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.FromCurrencyCode = new ReferenceEntity<string>(fromCurrencyCode,
			                                                    nameof(ApiResponse.Currencies));
			this.ToCurrencyCode = new ReferenceEntity<string>(toCurrencyCode,
			                                                  nameof(ApiResponse.Currencies));
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
    <Hash>171e68d965f9e78ffa43c8d0b8a4deb9</Hash>
</Codenesium>*/