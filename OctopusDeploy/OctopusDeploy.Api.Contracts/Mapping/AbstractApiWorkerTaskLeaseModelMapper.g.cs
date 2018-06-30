using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiWorkerTaskLeaseModelMapper
        {
                public virtual ApiWorkerTaskLeaseResponseModel MapRequestToResponse(
                        string id,
                        ApiWorkerTaskLeaseRequestModel request)
                {
                        var response = new ApiWorkerTaskLeaseResponseModel();
                        response.SetProperties(id,
                                               request.Exclusive,
                                               request.JSON,
                                               request.Name,
                                               request.TaskId,
                                               request.WorkerId);
                        return response;
                }

                public virtual ApiWorkerTaskLeaseRequestModel MapResponseToRequest(
                        ApiWorkerTaskLeaseResponseModel response)
                {
                        var request = new ApiWorkerTaskLeaseRequestModel();
                        request.SetProperties(
                                response.Exclusive,
                                response.JSON,
                                response.Name,
                                response.TaskId,
                                response.WorkerId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>d440b6cfb6b972467f9899685116e07c</Hash>
</Codenesium>*/