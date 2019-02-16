using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesPersonService
	{
		Task<CreateResponse<ApiSalesPersonServerResponseModel>> Create(
			ApiSalesPersonServerRequestModel model);

		Task<UpdateResponse<ApiSalesPersonServerResponseModel>> Update(int businessEntityID,
		                                                                ApiSalesPersonServerRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiSalesPersonServerResponseModel> Get(int businessEntityID);

		Task<List<ApiSalesPersonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiSalesPersonServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStoreServerResponseModel>> StoresBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0d11ba10179d5c14ef21c80889b3ebb0</Hash>
</Codenesium>*/