using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionCurrencyRepository
	{
		Task<POCOCountryRegionCurrency> Create(ApiCountryRegionCurrencyModel model);

		Task Update(string countryRegionCode,
		            ApiCountryRegionCurrencyModel model);

		Task Delete(string countryRegionCode);

		Task<POCOCountryRegionCurrency> Get(string countryRegionCode);

		Task<List<POCOCountryRegionCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOCountryRegionCurrency>> GetCurrencyCode(string currencyCode);
	}
}

/*<Codenesium>
    <Hash>356a559ecc0f88eda0bb833d01650831</Hash>
</Codenesium>*/