using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiTransactionHistoryArchiveModelMapper
        {
                public virtual ApiTransactionHistoryArchiveResponseModel MapRequestToResponse(
                        int transactionID,
                        ApiTransactionHistoryArchiveRequestModel request)
                {
                        var response = new ApiTransactionHistoryArchiveResponseModel();
                        response.SetProperties(transactionID,
                                               request.ActualCost,
                                               request.ModifiedDate,
                                               request.ProductID,
                                               request.Quantity,
                                               request.ReferenceOrderID,
                                               request.ReferenceOrderLineID,
                                               request.TransactionDate,
                                               request.TransactionType);
                        return response;
                }

                public virtual ApiTransactionHistoryArchiveRequestModel MapResponseToRequest(
                        ApiTransactionHistoryArchiveResponseModel response)
                {
                        var request = new ApiTransactionHistoryArchiveRequestModel();
                        request.SetProperties(
                                response.ActualCost,
                                response.ModifiedDate,
                                response.ProductID,
                                response.Quantity,
                                response.ReferenceOrderID,
                                response.ReferenceOrderLineID,
                                response.TransactionDate,
                                response.TransactionType);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>f4287a986f07d43e35a8964ea2224e09</Hash>
</Codenesium>*/