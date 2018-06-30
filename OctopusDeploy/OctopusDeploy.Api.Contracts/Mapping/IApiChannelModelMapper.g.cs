using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiChannelModelMapper
        {
                ApiChannelResponseModel MapRequestToResponse(
                        string id,
                        ApiChannelRequestModel request);

                ApiChannelRequestModel MapResponseToRequest(
                        ApiChannelResponseModel response);
        }
}

/*<Codenesium>
    <Hash>986478ba1a803db7abf48fa21b3cae62</Hash>
</Codenesium>*/