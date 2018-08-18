using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCountryRegionCurrencyResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string countryRegionCode,
			string currencyCode,
			DateTime modifiedDate)
		{
			this.CountryRegionCode = countryRegionCode;
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate;

			this.CurrencyCodeEntity = nameof(ApiResponse.Currencies);
		}

		[JsonProperty]
		public string CountryRegionCode { get; private set; }

		[JsonProperty]
		public string CurrencyCode { get; private set; }

		[JsonProperty]
		public string CurrencyCodeEntity { get; set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>68656f7bdddde9d655ac28d9c0e60650</Hash>
</Codenesium>*/