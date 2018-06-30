using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public interface IApiChainStatusModelMapper
        {
                ApiChainStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiChainStatusRequestModel request);

                ApiChainStatusRequestModel MapResponseToRequest(
                        ApiChainStatusResponseModel response);
        }
}

/*<Codenesium>
    <Hash>1fa11f227aa7d4ba64fba9896966c237</Hash>
</Codenesium>*/