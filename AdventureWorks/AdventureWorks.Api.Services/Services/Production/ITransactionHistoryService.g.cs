using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ITransactionHistoryService
        {
                Task<CreateResponse<ApiTransactionHistoryResponseModel>> Create(
                        ApiTransactionHistoryRequestModel model);

                Task<ActionResponse> Update(int transactionID,
                                            ApiTransactionHistoryRequestModel model);

                Task<ActionResponse> Delete(int transactionID);

                Task<ApiTransactionHistoryResponseModel> Get(int transactionID);

                Task<List<ApiTransactionHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiTransactionHistoryResponseModel>> ByProductID(int productID);
                Task<List<ApiTransactionHistoryResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID);
        }
}

/*<Codenesium>
    <Hash>fd7ff3ccb1ca16ed25b347cb86b19457</Hash>
</Codenesium>*/