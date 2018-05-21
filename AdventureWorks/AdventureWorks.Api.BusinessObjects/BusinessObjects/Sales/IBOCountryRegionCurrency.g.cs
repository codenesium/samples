using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCountryRegionCurrency
	{
		Task<CreateResponse<POCOCountryRegionCurrency>> Create(
			ApiCountryRegionCurrencyModel model);

		Task<ActionResponse> Update(string countryRegionCode,
		                            ApiCountryRegionCurrencyModel model);

		Task<ActionResponse> Delete(string countryRegionCode);

		Task<POCOCountryRegionCurrency> Get(string countryRegionCode);

		Task<List<POCOCountryRegionCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOCountryRegionCurrency>> GetCurrencyCode(string currencyCode);
	}
}

/*<Codenesium>
    <Hash>db72473b603c6f892b13a6f59b986db4</Hash>
</Codenesium>*/