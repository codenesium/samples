using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiUserModelMapper
        {
                ApiUserResponseModel MapRequestToResponse(
                        string id,
                        ApiUserRequestModel request);

                ApiUserRequestModel MapResponseToRequest(
                        ApiUserResponseModel response);
        }
}

/*<Codenesium>
    <Hash>4caba95d75f8df14aa7929ca4f46126f</Hash>
</Codenesium>*/