using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiProjectGroupModelMapper
        {
                ApiProjectGroupResponseModel MapRequestToResponse(
                        string id,
                        ApiProjectGroupRequestModel request);

                ApiProjectGroupRequestModel MapResponseToRequest(
                        ApiProjectGroupResponseModel response);
        }
}

/*<Codenesium>
    <Hash>f9af29b105cbd2e5db8197369f2ed84f</Hash>
</Codenesium>*/