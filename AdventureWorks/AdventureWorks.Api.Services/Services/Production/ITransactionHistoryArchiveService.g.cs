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

                Task<List<ApiTransactionHistoryArchiveResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiTransactionHistoryArchiveResponseModel>> ByProductID(int productID);
                Task<List<ApiTransactionHistoryArchiveResponseModel>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID);
        }
}

/*<Codenesium>
    <Hash>ffec80d8eebf279f0f82213a2a44b200</Hash>
</Codenesium>*/