using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IVStateProvinceCountryRegionService
	{
		Task<CreateResponse<ApiVStateProvinceCountryRegionResponseModel>> Create(
			ApiVStateProvinceCountryRegionRequestModel model);

		Task<UpdateResponse<ApiVStateProvinceCountryRegionResponseModel>> Update(int stateProvinceID,
		                                                                          ApiVStateProvinceCountryRegionRequestModel model);

		Task<ActionResponse> Delete(int stateProvinceID);

		Task<ApiVStateProvinceCountryRegionResponseModel> Get(int stateProvinceID);

		Task<List<ApiVStateProvinceCountryRegionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiVStateProvinceCountryRegionResponseModel> ByStateProvinceIDCountryRegionCode(int stateProvinceID, string countryRegionCode);
	}
}

/*<Codenesium>
    <Hash>2799c54aab2b9b4cf3c4f044efc48427</Hash>
</Codenesium>*/