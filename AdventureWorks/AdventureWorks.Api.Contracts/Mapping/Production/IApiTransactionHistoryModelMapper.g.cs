using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiTransactionHistoryModelMapper
        {
                ApiTransactionHistoryResponseModel MapRequestToResponse(
                        int transactionID,
                        ApiTransactionHistoryRequestModel request);

                ApiTransactionHistoryRequestModel MapResponseToRequest(
                        ApiTransactionHistoryResponseModel response);

                JsonPatchDocument<ApiTransactionHistoryRequestModel> CreatePatch(ApiTransactionHistoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f0d22e65858f7354991bedb57df0dc86</Hash>
</Codenesium>*/