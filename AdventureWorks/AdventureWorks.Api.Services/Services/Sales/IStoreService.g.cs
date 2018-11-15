using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IStoreService
	{
		Task<CreateResponse<ApiStoreServerResponseModel>> Create(
			ApiStoreServerRequestModel model);

		Task<UpdateResponse<ApiStoreServerResponseModel>> Update(int businessEntityID,
		                                                          ApiStoreServerRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiStoreServerResponseModel> Get(int businessEntityID);

		Task<List<ApiStoreServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiStoreServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiStoreServerResponseModel>> BySalesPersonID(int? salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStoreServerResponseModel>> ByDemographic(string demographic, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCustomerServerResponseModel>> CustomersByStoreID(int storeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a6dd0ed4482aa270245f27ade83e34d0</Hash>
</Codenesium>*/