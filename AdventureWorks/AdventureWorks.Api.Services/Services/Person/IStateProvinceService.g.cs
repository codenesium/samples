using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IStateProvinceService
	{
		Task<CreateResponse<ApiStateProvinceResponseModel>> Create(
			ApiStateProvinceRequestModel model);

		Task<UpdateResponse<ApiStateProvinceResponseModel>> Update(int stateProvinceID,
		                                                            ApiStateProvinceRequestModel model);

		Task<ActionResponse> Delete(int stateProvinceID);

		Task<ApiStateProvinceResponseModel> Get(int stateProvinceID);

		Task<List<ApiStateProvinceResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiStateProvinceResponseModel> ByName(string name);

		Task<ApiStateProvinceResponseModel> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode);

		Task<List<ApiAddressResponseModel>> Addresses(int stateProvinceID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f3977f0d451b72d5c38e71b849dbd154</Hash>
</Codenesium>*/