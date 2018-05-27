using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOTransactionHistoryArchive
	{
		Task<CreateResponse<ApiTransactionHistoryArchiveResponseModel>> Create(
			ApiTransactionHistoryArchiveRequestModel model);

		Task<ActionResponse> Update(int transactionID,
		                            ApiTransactionHistoryArchiveRequestModel model);

		Task<ActionResponse> Delete(int transactionID);

		Task<ApiTransactionHistoryArchiveResponseModel> Get(int transactionID);

		Task<List<ApiTransactionHistoryArchiveResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiTransactionHistoryArchiveResponseModel>> GetProductID(int productID);
		Task<List<ApiTransactionHistoryArchiveResponseModel>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>95e1c8040e0bf3c5ece4080407d0864c</Hash>
</Codenesium>*/