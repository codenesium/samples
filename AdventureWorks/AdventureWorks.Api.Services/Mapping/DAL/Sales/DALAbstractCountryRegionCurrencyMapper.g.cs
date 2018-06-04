using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCountryRegionCurrencyMapper
	{
		public virtual CountryRegionCurrency MapBOToEF(
			BOCountryRegionCurrency bo)
		{
			CountryRegionCurrency efCountryRegionCurrency = new CountryRegionCurrency ();

			efCountryRegionCurrency.SetProperties(
				bo.CountryRegionCode,
				bo.CurrencyCode,
				bo.ModifiedDate);
			return efCountryRegionCurrency;
		}

		public virtual BOCountryRegionCurrency MapEFToBO(
			CountryRegionCurrency ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOCountryRegionCurrency();

			bo.SetProperties(
				ef.CountryRegionCode,
				ef.CurrencyCode,
				ef.ModifiedDate);
			return bo;
		}

		public virtual List<BOCountryRegionCurrency> MapEFToBO(
			List<CountryRegionCurrency> records)
		{
			List<BOCountryRegionCurrency> response = new List<BOCountryRegionCurrency>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>65f6d311796e3da8390a3dda6bc53ad7</Hash>
</Codenesium>*/