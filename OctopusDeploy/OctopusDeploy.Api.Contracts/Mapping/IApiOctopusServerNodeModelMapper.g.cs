using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiOctopusServerNodeModelMapper
        {
                ApiOctopusServerNodeResponseModel MapRequestToResponse(
                        string id,
                        ApiOctopusServerNodeRequestModel request);

                ApiOctopusServerNodeRequestModel MapResponseToRequest(
                        ApiOctopusServerNodeResponseModel response);
        }
}

/*<Codenesium>
    <Hash>e9fe71978a5c443aa0ef979f00cff53d</Hash>
</Codenesium>*/