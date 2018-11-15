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

		Task<List<ApiTransactionHistoryServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryServerResponseModel>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryServerResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8087c4ba1ca633b7162a0ff9d3b20afd</Hash>
</Codenesium>*/