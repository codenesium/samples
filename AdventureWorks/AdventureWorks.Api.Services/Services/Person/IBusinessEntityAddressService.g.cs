using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBusinessEntityAddressService
	{
		Task<CreateResponse<ApiBusinessEntityAddressResponseModel>> Create(
			ApiBusinessEntityAddressRequestModel model);

		Task<UpdateResponse<ApiBusinessEntityAddressResponseModel>> Update(int businessEntityID,
		                                                                    ApiBusinessEntityAddressRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiBusinessEntityAddressResponseModel> Get(int businessEntityID);

		Task<List<ApiBusinessEntityAddressResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBusinessEntityAddressResponseModel>> ByAddressID(int addressID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBusinessEntityAddressResponseModel>> ByAddressTypeID(int addressTypeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0cc8bcd612574e390cc370f48cfa1dfe</Hash>
</Codenesium>*/