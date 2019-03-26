using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ITransactionHistoryArchiveService
	{
		Task<CreateResponse<ApiTransactionHistoryArchiveServerResponseModel>> Create(
			ApiTransactionHistoryArchiveServerRequestModel model);

		Task<UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel>> Update(int transactionID,
		                                                                              ApiTransactionHistoryArchiveServerRequestModel model);

		Task<ActionResponse> Delete(int transactionID);

		Task<ApiTransactionHistoryArchiveServerResponseModel> Get(int transactionID);

		Task<List<ApiTransactionHistoryArchiveServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTransactionHistoryArchiveServerResponseModel>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryArchiveServerResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>61e06a18bd6bff9d951279b223b90869</Hash>
</Codenesium>*/