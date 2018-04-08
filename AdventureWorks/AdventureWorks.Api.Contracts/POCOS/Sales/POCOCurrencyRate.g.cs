using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOCurrencyRate
	{
		public POCOCurrencyRate()
		{}

		public POCOCurrencyRate(int currencyRateID,
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

			FromCurrencyCode = new ReferenceEntity<string>(fromCurrencyCode,
			                                               "Currency");
			ToCurrencyCode = new ReferenceEntity<string>(toCurrencyCode,
			                                             "Currency");
		}

		public int CurrencyRateID {get; set;}
		public DateTime CurrencyRateDate {get; set;}
		public ReferenceEntity<string>FromCurrencyCode {get; set;}
		public ReferenceEntity<string>ToCurrencyCode {get; set;}
		public decimal AverageRate {get; set;}
		public decimal EndOfDayRate {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyRateIDValue {get; set;} = true;

		public bool ShouldSerializeCurrencyRateID()
		{
			return ShouldSerializeCurrencyRateIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyRateDateValue {get; set;} = true;

		public bool ShouldSerializeCurrencyRateDate()
		{
			return ShouldSerializeCurrencyRateDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFromCurrencyCodeValue {get; set;} = true;

		public bool ShouldSerializeFromCurrencyCode()
		{
			return ShouldSerializeFromCurrencyCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeToCurrencyCodeValue {get; set;} = true;

		public bool ShouldSerializeToCurrencyCode()
		{
			return ShouldSerializeToCurrencyCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAverageRateValue {get; set;} = true;

		public bool ShouldSerializeAverageRate()
		{
			return ShouldSerializeAverageRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndOfDayRateValue {get; set;} = true;

		public bool ShouldSerializeEndOfDayRate()
		{
			return ShouldSerializeEndOfDayRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>c277ece6a2af5cb1530ac8fd97764217</Hash>
</Codenesium>*/