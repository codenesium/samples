using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiTransactionHistoryArchiveModelMapper
        {
                ApiTransactionHistoryArchiveResponseModel MapRequestToResponse(
                        int transactionID,
                        ApiTransactionHistoryArchiveRequestModel request);

                ApiTransactionHistoryArchiveRequestModel MapResponseToRequest(
                        ApiTransactionHistoryArchiveResponseModel response);
        }
}

/*<Codenesium>
    <Hash>3696a1f274651d9bb35506d0af98d86f</Hash>
</Codenesium>*/