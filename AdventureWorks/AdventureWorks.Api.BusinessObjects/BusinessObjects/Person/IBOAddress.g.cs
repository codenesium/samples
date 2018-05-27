using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOAddress
	{
		Task<CreateResponse<ApiAddressResponseModel>> Create(
			ApiAddressRequestModel model);

		Task<ActionResponse> Update(int addressID,
		                            ApiAddressRequestModel model);

		Task<ActionResponse> Delete(int addressID);

		Task<ApiAddressResponseModel> Get(int addressID);

		Task<List<ApiAddressResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiAddressResponseModel> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode);
		Task<List<ApiAddressResponseModel>> GetStateProvinceID(int stateProvinceID);
	}
}

/*<Codenesium>
    <Hash>724304f17d4a03508873f3e16e8c147e</Hash>
</Codenesium>*/