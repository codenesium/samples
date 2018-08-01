using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface ITransactionHistoryService
	{
		Task<CreateResponse<ApiTransactionHistoryResponseModel>> Create(
			ApiTransactionHistoryRequestModel model);

		Task<UpdateResponse<ApiTransactionHistoryResponseModel>> Update(int transactionID,
		                                                                 ApiTransactionHistoryRequestModel model);

		Task<ActionResponse> Delete(int transactionID);

		Task<ApiTransactionHistoryResponseModel> Get(int transactionID);

		Task<List<ApiTransactionHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryResponseModel>> ByProductID(int productID);

		Task<List<ApiTransactionHistoryResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>fd06a7553fa0d0d1a23ce00aae9aca79</Hash>
</Codenesium>*/