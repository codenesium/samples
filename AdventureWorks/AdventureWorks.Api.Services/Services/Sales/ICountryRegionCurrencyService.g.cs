using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface ICountryRegionCurrencyService
	{
		Task<CreateResponse<ApiCountryRegionCurrencyResponseModel>> Create(
			ApiCountryRegionCurrencyRequestModel model);

		Task<UpdateResponse<ApiCountryRegionCurrencyResponseModel>> Update(string countryRegionCode,
		                                                                    ApiCountryRegionCurrencyRequestModel model);

		Task<ActionResponse> Delete(string countryRegionCode);

		Task<ApiCountryRegionCurrencyResponseModel> Get(string countryRegionCode);

		Task<List<ApiCountryRegionCurrencyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCountryRegionCurrencyResponseModel>> ByCurrencyCode(string currencyCode);
	}
}

/*<Codenesium>
    <Hash>c65415b8a7f793a01303cd4ea7e0b591</Hash>
</Codenesium>*/