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
			this.FromCurrencyCode = fromCurrencyCode;
			this.ToCurrencyCode = toCurrencyCode;
			this.AverageRate = averageRate;
			this.EndOfDayRate = endOfDayRate;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int CurrencyRateID {get; set;}
		public DateTime CurrencyRateDate {get; set;}
		public string FromCurrencyCode {get; set;}
		public string ToCurrencyCode {get; set;}
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
    <Hash>e36cbe9a4f01bba12b3551bb1f3e98b8</Hash>
</Codenesium>*/