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

		public CountryRegionCurrencyModel(
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
    <Hash>2bcd143d29b23086a3d83b140c87ae67</Hash>
</Codenesium>*/