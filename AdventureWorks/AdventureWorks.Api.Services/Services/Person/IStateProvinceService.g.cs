using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IStateProvinceService
	{
		Task<CreateResponse<ApiStateProvinceServerResponseModel>> Create(
			ApiStateProvinceServerRequestModel model);

		Task<UpdateResponse<ApiStateProvinceServerResponseModel>> Update(int stateProvinceID,
		                                                                  ApiStateProvinceServerRequestModel model);

		Task<ActionResponse> Delete(int stateProvinceID);

		Task<ApiStateProvinceServerResponseModel> Get(int stateProvinceID);

		Task<List<ApiStateProvinceServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiStateProvinceServerResponseModel> ByName(string name);

		Task<ApiStateProvinceServerResponseModel> ByRowguid(Guid rowguid);

		Task<ApiStateProvinceServerResponseModel> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode);

		Task<List<ApiAddressServerResponseModel>> AddressesByStateProvinceID(int stateProvinceID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a5b9864f3d519464f5080bf5afb3e556</Hash>
</Codenesium>*/