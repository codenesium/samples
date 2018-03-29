using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class CountryRegionCurrencyModel
	{
		public CountryRegionCurrencyModel()
		{}

		public CountryRegionCurrencyModel(string currencyCode,
		                                  DateTime modifiedDate)
		{
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public CountryRegionCurrencyModel(POCOCountryRegionCurrency poco)
		{
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.CurrencyCode = poco.CurrencyCode.Value.ToString();
		}

		private string _currencyCode;
		[Required]
		public string CurrencyCode
		{
			get
			{
				return _currencyCode;
			}
			set
			{
				this._currencyCode = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>13ac9ad20ec49ba9876182e2a46619d0</Hash>
</Codenesium>*/