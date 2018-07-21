using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiInvitationModelMapper
        {
                ApiInvitationResponseModel MapRequestToResponse(
                        string id,
                        ApiInvitationRequestModel request);

                ApiInvitationRequestModel MapResponseToRequest(
                        ApiInvitationResponseModel response);

                JsonPatchDocument<ApiInvitationRequestModel> CreatePatch(ApiInvitationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>a43fd6cb0f33f44a08efbb7d9f2ca211</Hash>
</Codenesium>*/