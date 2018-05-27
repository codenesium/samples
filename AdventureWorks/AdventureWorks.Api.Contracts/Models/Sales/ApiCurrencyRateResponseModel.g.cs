using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCurrencyRateResponseModel: AbstractApiResponseModel
	{
		public ApiCurrencyRateResponseModel() : base()
		{}

		public void SetProperties(
			decimal averageRate,
			DateTime currencyRateDate,
			int currencyRateID,
			decimal endOfDayRate,
			string fromCurrencyCode,
			DateTime modifiedDate,
			string toCurrencyCode)
		{
			this.AverageRate = averageRate.ToDecimal();
			this.CurrencyRateDate = currencyRateDate.ToDateTime();
			this.CurrencyRateID = currencyRateID.ToInt();
			this.EndOfDayRate = endOfDayRate.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.FromCurrencyCode = new ReferenceEntity<string>(fromCurrencyCode,
			                                                    nameof(ApiResponse.Currencies));
			this.ToCurrencyCode = new ReferenceEntity<string>(toCurrencyCode,
			                                                  nameof(ApiResponse.Currencies));
		}

		public decimal AverageRate { get; set; }
		public DateTime CurrencyRateDate { get; set; }
		public int CurrencyRateID { get; set; }
		public decimal EndOfDayRate { get; set; }
		public ReferenceEntity<string> FromCurrencyCode { get; set; }
		public DateTime ModifiedDate { get; set; }
		public ReferenceEntity<string> ToCurrencyCode { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAverageRateValue { get; set; } = true;

		public bool ShouldSerializeAverageRate()
		{
			return this.ShouldSerializeAverageRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyRateDateValue { get; set; } = true;

		public bool ShouldSerializeCurrencyRateDate()
		{
			return this.ShouldSerializeCurrencyRateDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCurrencyRateIDValue { get; set; } = true;

		public bool ShouldSerializeCurrencyRateID()
		{
			return this.ShouldSerializeCurrencyRateIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndOfDayRateValue { get; set; } = true;

		public bool ShouldSerializeEndOfDayRate()
		{
			return this.ShouldSerializeEndOfDayRateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFromCurrencyCodeValue { get; set; } = true;

		public bool ShouldSerializeFromCurrencyCode()
		{
			return this.ShouldSerializeFromCurrencyCodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeToCurrencyCodeValue { get; set; } = true;

		public bool ShouldSerializeToCurrencyCode()
		{
			return this.ShouldSerializeToCurrencyCodeValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAverageRateValue = false;
			this.ShouldSerializeCurrencyRateDateValue = false;
			this.ShouldSerializeCurrencyRateIDValue = false;
			this.ShouldSerializeEndOfDayRateValue = false;
			this.ShouldSerializeFromCurrencyCodeValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeToCurrencyCodeValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>ee7728d8ddff8fc7eb09346736c8fb8b</Hash>
</Codenesium>*/