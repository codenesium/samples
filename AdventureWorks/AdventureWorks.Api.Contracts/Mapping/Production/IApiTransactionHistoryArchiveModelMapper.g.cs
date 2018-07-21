using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiTransactionHistoryArchiveModelMapper
        {
                ApiTransactionHistoryArchiveResponseModel MapRequestToResponse(
                        int transactionID,
                        ApiTransactionHistoryArchiveRequestModel request);

                ApiTransactionHistoryArchiveRequestModel MapResponseToRequest(
                        ApiTransactionHistoryArchiveResponseModel response);

                JsonPatchDocument<ApiTransactionHistoryArchiveRequestModel> CreatePatch(ApiTransactionHistoryArchiveRequestModel model);
        }
}

/*<Codenesium>
    <Hash>5c0e3ed5a7cc06fcd363bbb1d0d8b40c</Hash>
</Codenesium>*/