using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCountryRegionCurrencyModel
	{
		public ApiCountryRegionCurrencyModel()
		{}

		public ApiCountryRegionCurrencyModel(
			string currencyCode,
			DateTime modifiedDate)
		{
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string currencyCode;

		[Required]
		public string CurrencyCode
		{
			get
			{
				return this.currencyCode;
			}

			set
			{
				this.currencyCode = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>8053988cb32d24eab73c310b4133ed82</Hash>
</Codenesium>*/