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

		Task<List<ApiTransactionHistoryArchiveResponseModel>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryArchiveResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b9290bb262d3e65cba4d2473df6b79b0</Hash>
</Codenesium>*/