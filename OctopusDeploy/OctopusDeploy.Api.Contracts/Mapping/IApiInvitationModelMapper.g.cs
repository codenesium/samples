using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiInvitationModelMapper
        {
                ApiInvitationResponseModel MapRequestToResponse(
                        string id,
                        ApiInvitationRequestModel request);

                ApiInvitationRequestModel MapResponseToRequest(
                        ApiInvitationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>e4ac1c03817d390231afec0918049d08</Hash>
</Codenesium>*/