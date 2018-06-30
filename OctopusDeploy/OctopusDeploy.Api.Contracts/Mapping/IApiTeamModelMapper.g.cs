using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiTeamModelMapper
        {
                ApiTeamResponseModel MapRequestToResponse(
                        string id,
                        ApiTeamRequestModel request);

                ApiTeamRequestModel MapResponseToRequest(
                        ApiTeamResponseModel response);
        }
}

/*<Codenesium>
    <Hash>b8bc1a70df91efc062419d6fdaf8a358</Hash>
</Codenesium>*/