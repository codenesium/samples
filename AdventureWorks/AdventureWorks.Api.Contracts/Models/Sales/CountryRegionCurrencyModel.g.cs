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
    <Hash>450513f463d1015041a97cc6db277f02</Hash>
</Codenesium>*/