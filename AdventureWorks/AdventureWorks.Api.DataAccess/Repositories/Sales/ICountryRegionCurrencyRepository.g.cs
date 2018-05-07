using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionCurrencyRepository
	{
		string Create(CountryRegionCurrencyModel model);

		void Update(string countryRegionCode,
		            CountryRegionCurrencyModel model);

		void Delete(string countryRegionCode);

		POCOCountryRegionCurrency Get(string countryRegionCode);

		List<POCOCountryRegionCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>31b00a3fd45c93cfd5a058867e62761c</Hash>
</Codenesium>*/