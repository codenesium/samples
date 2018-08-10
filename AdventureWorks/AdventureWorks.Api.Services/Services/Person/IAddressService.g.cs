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

		Task<List<ApiAddressResponseModel>> ByStateProvinceID(int stateProvinceID);

		Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int addressID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>70cd0c9c539de858542e1876cbd3a41b</Hash>
</Codenesium>*/