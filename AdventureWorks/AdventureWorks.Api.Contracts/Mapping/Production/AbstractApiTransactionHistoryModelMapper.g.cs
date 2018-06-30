using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiTransactionHistoryModelMapper
        {
                public virtual ApiTransactionHistoryResponseModel MapRequestToResponse(
                        int transactionID,
                        ApiTransactionHistoryRequestModel request)
                {
                        var response = new ApiTransactionHistoryResponseModel();
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

                public virtual ApiTransactionHistoryRequestModel MapResponseToRequest(
                        ApiTransactionHistoryResponseModel response)
                {
                        var request = new ApiTransactionHistoryRequestModel();
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
    <Hash>49db6f45676e78b4369ea9374d436ff4</Hash>
</Codenesium>*/