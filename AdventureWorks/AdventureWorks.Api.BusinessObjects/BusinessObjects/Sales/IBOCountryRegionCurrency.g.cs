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
		Task<CreateResponse<string>> Create(
			CountryRegionCurrencyModel model);

		Task<ActionResponse> Update(string countryRegionCode,
		                            CountryRegionCurrencyModel model);

		Task<ActionResponse> Delete(string countryRegionCode);

		POCOCountryRegionCurrency Get(string countryRegionCode);

		List<POCOCountryRegionCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>322e21bf6ccd0be462ead04f0b2de21d</Hash>
</Codenesium>*/