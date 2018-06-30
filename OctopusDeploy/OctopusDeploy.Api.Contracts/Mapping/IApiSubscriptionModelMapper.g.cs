using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiSubscriptionModelMapper
        {
                ApiSubscriptionResponseModel MapRequestToResponse(
                        string id,
                        ApiSubscriptionRequestModel request);

                ApiSubscriptionRequestModel MapResponseToRequest(
                        ApiSubscriptionResponseModel response);
        }
}

/*<Codenesium>
    <Hash>92550e44196248a95685b880a96800c3</Hash>
</Codenesium>*/