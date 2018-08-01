using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IAddressService
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
    <Hash>8d7ccd313d4fb450da03bac7d890df6e</Hash>
</Codenesium>*/