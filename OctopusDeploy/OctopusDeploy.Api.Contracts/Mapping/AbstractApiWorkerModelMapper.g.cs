using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiWorkerModelMapper
        {
                public virtual ApiWorkerResponseModel MapRequestToResponse(
                        string id,
                        ApiWorkerRequestModel request)
                {
                        var response = new ApiWorkerResponseModel();
                        response.SetProperties(id,
                                               request.CommunicationStyle,
                                               request.Fingerprint,
                                               request.IsDisabled,
                                               request.JSON,
                                               request.MachinePolicyId,
                                               request.Name,
                                               request.RelatedDocumentIds,
                                               request.Thumbprint,
                                               request.WorkerPoolIds);
                        return response;
                }

                public virtual ApiWorkerRequestModel MapResponseToRequest(
                        ApiWorkerResponseModel response)
                {
                        var request = new ApiWorkerRequestModel();
                        request.SetProperties(
                                response.CommunicationStyle,
                                response.Fingerprint,
                                response.IsDisabled,
                                response.JSON,
                                response.MachinePolicyId,
                                response.Name,
                                response.RelatedDocumentIds,
                                response.Thumbprint,
                                response.WorkerPoolIds);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>0eb0ffb71ff53d903a5d48b9cb72dbaa</Hash>
</Codenesium>*/