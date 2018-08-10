using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ITransactionHistoryArchiveService
	{
		Task<CreateResponse<ApiTransactionHistoryArchiveResponseModel>> Create(
			ApiTransactionHistoryArchiveRequestModel model);

		Task<UpdateResponse<ApiTransactionHistoryArchiveResponseModel>> Update(int transactionID,
		                                                                        ApiTransactionHistoryArchiveRequestModel model);

		Task<ActionResponse> Delete(int transactionID);

		Task<ApiTransactionHistoryArchiveResponseModel> Get(int transactionID);

		Task<List<ApiTransactionHistoryArchiveResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryArchiveResponseModel>> ByProductID(int productID);

		Task<List<ApiTransactionHistoryArchiveResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>ba8ba891601ba637043b410f7366d501</Hash>
</Codenesium>*/