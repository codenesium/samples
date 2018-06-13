using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ITransactionHistoryArchiveService
        {
                Task<CreateResponse<ApiTransactionHistoryArchiveResponseModel>> Create(
                        ApiTransactionHistoryArchiveRequestModel model);

                Task<ActionResponse> Update(int transactionID,
                                            ApiTransactionHistoryArchiveRequestModel model);

                Task<ActionResponse> Delete(int transactionID);

                Task<ApiTransactionHistoryArchiveResponseModel> Get(int transactionID);

                Task<List<ApiTransactionHistoryArchiveResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiTransactionHistoryArchiveResponseModel>> GetProductID(int productID);
                Task<List<ApiTransactionHistoryArchiveResponseModel>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID);
        }
}

/*<Codenesium>
    <Hash>314d99086a943565774b69baa1ebd627</Hash>
</Codenesium>*/