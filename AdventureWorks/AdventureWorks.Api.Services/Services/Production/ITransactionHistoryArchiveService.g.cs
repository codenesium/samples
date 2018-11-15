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

		Task<List<ApiTransactionHistoryArchiveServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryArchiveServerResponseModel>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionHistoryArchiveServerResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>23217c076ddb9abc0b85b75b7cc4acf1</Hash>
</Codenesium>*/