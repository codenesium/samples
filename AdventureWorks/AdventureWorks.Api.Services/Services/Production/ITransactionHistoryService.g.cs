using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ITransactionHistoryService
	{
		Task<CreateResponse<ApiTransactionHistoryServerResponseModel>> Create(
			ApiTransactionHistoryServerRequestModel model);

		Task<UpdateResponse<ApiTransactionHistoryServerResponseModel>> Update(int transactionID,
		                                                                       ApiTransactionHistoryServerRequestModel model);

		Task<ActionResponse> Delete(int transactionID);

		Task<ApiTransactionHistoryServerResponseModel> Get(int transactionID);

		Task<List<ApiTransactionHistoryServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTransactionHistoryServerResponseModel>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryServerResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d4444f2e9b817c8e757c3af4d97860a1</Hash>
</Codenesium>*/