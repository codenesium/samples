using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IAddressService
	{
		Task<CreateResponse<ApiAddressServerResponseModel>> Create(
			ApiAddressServerRequestModel model);

		Task<UpdateResponse<ApiAddressServerResponseModel>> Update(int addressID,
		                                                            ApiAddressServerRequestModel model);

		Task<ActionResponse> Delete(int addressID);

		Task<ApiAddressServerResponseModel> Get(int addressID);

		Task<List<ApiAddressServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiAddressServerResponseModel> ByRowguid(Guid rowguid);

		Task<ApiAddressServerResponseModel> ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode);

		Task<List<ApiAddressServerResponseModel>> ByStateProvinceID(int stateProvinceID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1307cf211547d5e0f6f8c9dc649b6ecd</Hash>
</Codenesium>*/