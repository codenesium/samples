using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiProjectTriggerModelMapper
        {
                public virtual ApiProjectTriggerResponseModel MapRequestToResponse(
                        string id,
                        ApiProjectTriggerRequestModel request)
                {
                        var response = new ApiProjectTriggerResponseModel();
                        response.SetProperties(id,
                                               request.IsDisabled,
                                               request.JSON,
                                               request.Name,
                                               request.ProjectId,
                                               request.TriggerType);
                        return response;
                }

                public virtual ApiProjectTriggerRequestModel MapResponseToRequest(
                        ApiProjectTriggerResponseModel response)
                {
                        var request = new ApiProjectTriggerRequestModel();
                        request.SetProperties(
                                response.IsDisabled,
                                response.JSON,
                                response.Name,
                                response.ProjectId,
                                response.TriggerType);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>015e8bfa44c03ccbbcd5eb804c590f0a</Hash>
</Codenesium>*/