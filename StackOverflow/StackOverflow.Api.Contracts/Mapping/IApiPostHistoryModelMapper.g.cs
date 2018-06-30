using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public interface IApiPostHistoryModelMapper
        {
                ApiPostHistoryResponseModel MapRequestToResponse(
                        int id,
                        ApiPostHistoryRequestModel request);

                ApiPostHistoryRequestModel MapResponseToRequest(
                        ApiPostHistoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>5408f391b58e75aa23a7e9a10f9359be</Hash>
</Codenesium>*/