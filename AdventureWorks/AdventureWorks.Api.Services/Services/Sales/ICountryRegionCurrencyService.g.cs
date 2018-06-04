using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ICountryRegionCurrencyService
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
    <Hash>f598fa8c728ff34b3eb8b46bd2581417</Hash>
</Codenesium>*/