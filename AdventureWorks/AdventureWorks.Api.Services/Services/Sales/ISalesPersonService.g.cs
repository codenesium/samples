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

		Task<List<ApiSalesPersonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiSalesPersonServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStoreServerResponseModel>> StoresBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3a12c24db076e541498c89025372aa91</Hash>
</Codenesium>*/