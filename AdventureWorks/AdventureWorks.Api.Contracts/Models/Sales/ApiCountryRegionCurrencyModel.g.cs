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
			this.CurrencyCode = currencyCode.ToString();
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
    <Hash>bf76e5f45835c11aac0ae9088cdede1f</Hash>
</Codenesium>*/