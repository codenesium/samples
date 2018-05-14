using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionCurrencyRepository
	{
		POCOCountryRegionCurrency Create(ApiCountryRegionCurrencyModel model);

		void Update(string countryRegionCode,
		            ApiCountryRegionCurrencyModel model);

		void Delete(string countryRegionCode);

		POCOCountryRegionCurrency Get(string countryRegionCode);

		List<POCOCountryRegionCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountryRegionCurrency> GetCurrencyCode(string currencyCode);
	}
}

/*<Codenesium>
    <Hash>7b727ce036cc16d67889d705ba7d3466</Hash>
</Codenesium>*/