using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionCurrencyRepository
	{
		Task<DTOCountryRegionCurrency> Create(DTOCountryRegionCurrency dto);

		Task Update(string countryRegionCode,
		            DTOCountryRegionCurrency dto);

		Task Delete(string countryRegionCode);

		Task<DTOCountryRegionCurrency> Get(string countryRegionCode);

		Task<List<DTOCountryRegionCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOCountryRegionCurrency>> GetCurrencyCode(string currencyCode);
	}
}

/*<Codenesium>
    <Hash>116fed26dc10448c3c738eefd137700f</Hash>
</Codenesium>*/