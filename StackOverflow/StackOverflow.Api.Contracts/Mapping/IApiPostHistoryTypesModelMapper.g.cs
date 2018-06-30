using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiPostHistoryTypesModelMapper
        {
                ApiPostHistoryTypesResponseModel MapRequestToResponse(
                        int id,
                        ApiPostHistoryTypesRequestModel request);

                ApiPostHistoryTypesRequestModel MapResponseToRequest(
                        ApiPostHistoryTypesResponseModel response);
        }
}

/*<Codenesium>
    <Hash>629a4f22b9bea25ffe8f802b0fa06632</Hash>
</Codenesium>*/