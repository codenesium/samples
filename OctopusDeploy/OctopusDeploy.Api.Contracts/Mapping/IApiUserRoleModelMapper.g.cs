using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiUserRoleModelMapper
        {
                ApiUserRoleResponseModel MapRequestToResponse(
                        string id,
                        ApiUserRoleRequestModel request);

                ApiUserRoleRequestModel MapResponseToRequest(
                        ApiUserRoleResponseModel response);
        }
}

/*<Codenesium>
    <Hash>54da6f911e0c60dbd01c87ac95d922c2</Hash>
</Codenesium>*/