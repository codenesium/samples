using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiInvitationModelMapper
        {
                public virtual ApiInvitationResponseModel MapRequestToResponse(
                        string id,
                        ApiInvitationRequestModel request)
                {
                        var response = new ApiInvitationResponseModel();
                        response.SetProperties(id,
                                               request.InvitationCode,
                                               request.JSON);
                        return response;
                }

                public virtual ApiInvitationRequestModel MapResponseToRequest(
                        ApiInvitationResponseModel response)
                {
                        var request = new ApiInvitationRequestModel();
                        request.SetProperties(
                                response.InvitationCode,
                                response.JSON);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>efc1e3bf2c54527a7a318de18f2113e2</Hash>
</Codenesium>*/