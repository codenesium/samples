using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiTransactionHistoryModelMapper
        {
                ApiTransactionHistoryResponseModel MapRequestToResponse(
                        int transactionID,
                        ApiTransactionHistoryRequestModel request);

                ApiTransactionHistoryRequestModel MapResponseToRequest(
                        ApiTransactionHistoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>6f4487619ccc028d02a09305a38d65f2</Hash>
</Codenesium>*/