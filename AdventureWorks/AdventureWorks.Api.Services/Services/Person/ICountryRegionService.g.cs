using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ICountryRegionService
	{
		Task<CreateResponse<ApiCountryRegionServerResponseModel>> Create(
			ApiCountryRegionServerRequestModel model);

		Task<UpdateResponse<ApiCountryRegionServerResponseModel>> Update(string countryRegionCode,
		                                                                  ApiCountryRegionServerRequestModel model);

		Task<ActionResponse> Delete(string countryRegionCode);

		Task<ApiCountryRegionServerResponseModel> Get(string countryRegionCode);

		Task<List<ApiCountryRegionServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiCountryRegionServerResponseModel> ByName(string name);

		Task<List<ApiStateProvinceServerResponseModel>> StateProvincesByCountryRegionCode(string countryRegionCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dd6eab0c4cbccdfdbc36fada63edb8d1</Hash>
</Codenesium>*/