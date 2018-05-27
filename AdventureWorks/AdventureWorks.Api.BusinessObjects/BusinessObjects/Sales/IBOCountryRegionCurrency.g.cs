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
		Task<CreateResponse<ApiCountryRegionCurrencyResponseModel>> Create(
			ApiCountryRegionCurrencyRequestModel model);

		Task<ActionResponse> Update(string countryRegionCode,
		                            ApiCountryRegionCurrencyRequestModel model);

		Task<ActionResponse> Delete(string countryRegionCode);

		Task<ApiCountryRegionCurrencyResponseModel> Get(string countryRegionCode);

		Task<List<ApiCountryRegionCurrencyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiCountryRegionCurrencyResponseModel>> GetCurrencyCode(string currencyCode);
	}
}

/*<Codenesium>
    <Hash>b414685418731dab49c1fa862b4a894c</Hash>
</Codenesium>*/