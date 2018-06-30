using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiProjectTriggerModelMapper
        {
                ApiProjectTriggerResponseModel MapRequestToResponse(
                        string id,
                        ApiProjectTriggerRequestModel request);

                ApiProjectTriggerRequestModel MapResponseToRequest(
                        ApiProjectTriggerResponseModel response);
        }
}

/*<Codenesium>
    <Hash>fd5a5a6d296a3e198c93e7dede61d7a7</Hash>
</Codenesium>*/