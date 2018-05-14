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

		POCOCountryRegionCurrency Get(string countryRegionCode);

		List<POCOCountryRegionCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountryRegionCurrency> GetCurrencyCode(string currencyCode);
	}
}

/*<Codenesium>
    <Hash>aed412f14adf9d8ae98ffbb69d2db96c</Hash>
</Codenesium>*/