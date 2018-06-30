using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public interface IApiLinkStatusModelMapper
        {
                ApiLinkStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiLinkStatusRequestModel request);

                ApiLinkStatusRequestModel MapResponseToRequest(
                        ApiLinkStatusResponseModel response);
        }
}

/*<Codenesium>
    <Hash>1a6d3fdacc43dd91f64d23bf754748a5</Hash>
</Codenesium>*/