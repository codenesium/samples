using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface ITransactionHistoryArchiveService
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
    <Hash>bc2e0fcd0da62c91619b9624b76fdc20</Hash>
</Codenesium>*/