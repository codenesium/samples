using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiTransactionHistoryArchiveRequestModel> CreatePatch(ApiTransactionHistoryArchiveRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiTransactionHistoryArchiveRequestModel>();
                        patch.Replace(x => x.ActualCost, model.ActualCost);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.ProductID, model.ProductID);
                        patch.Replace(x => x.Quantity, model.Quantity);
                        patch.Replace(x => x.ReferenceOrderID, model.ReferenceOrderID);
                        patch.Replace(x => x.ReferenceOrderLineID, model.ReferenceOrderLineID);
                        patch.Replace(x => x.TransactionDate, model.TransactionDate);
                        patch.Replace(x => x.TransactionType, model.TransactionType);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>7e656ac2c15bf65b0d0f583f1cc1e04e</Hash>
</Codenesium>*/