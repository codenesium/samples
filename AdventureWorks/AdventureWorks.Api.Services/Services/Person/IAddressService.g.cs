using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IAddressService
	{
		Task<CreateResponse<ApiAddressResponseModel>> Create(
			ApiAddressRequestModel model);

		Task<UpdateResponse<ApiAddressResponseModel>> Update(int addressID,
		                                                      ApiAddressRequestModel model);

		Task<ActionResponse> Delete(int addressID);

		Task<ApiAddressResponseModel> Get(int addressID);

		Task<List<ApiAddressResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiAddressResponseModel> ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode);

		Task<List<ApiAddressResponseModel>> ByStateProvinceID(int stateProvinceID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddressesByAddressID(int addressID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0906f00ee75ac65576370389035d94a2</Hash>
</Codenesium>*/