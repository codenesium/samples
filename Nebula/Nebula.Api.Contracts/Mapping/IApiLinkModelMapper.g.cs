using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public interface IApiLinkModelMapper
        {
                ApiLinkResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkRequestModel request);

                ApiLinkRequestModel MapResponseToRequest(
                        ApiLinkResponseModel response);
        }
}

/*<Codenesium>
    <Hash>95f792c47b5c5e9278708d945d7bc614</Hash>
</Codenesium>*/